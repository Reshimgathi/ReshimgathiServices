using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace ReshimgathiServices
{
    public class RAuthFilter : AuthorizeAttribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get { return false;  }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParameter = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization; 

            if(authorization == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Authorization Header", request);
                return;
            }
            else if(authorization != null && authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid Authorization Scheme", request);
                return;
            }
            else if (string.IsNullOrWhiteSpace(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing token", request);
                return;
            }

            context.Principal = TokenManager.GetPrincipal(authorization.Parameter);
            return;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var result = await context.Result.ExecuteAsync(cancellationToken);

            if(result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic", "realm=localhost"));
            }

            context.Result = new ResponseMessageResult(result);

        }
    }

    public class AuthenticationFailureResult : IHttpActionResult
    {
        public string ReasonPhrase;

        public HttpRequestMessage Request { get; set; }

        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            ReasonPhrase = reasonPhrase;
            Request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(ExecuteAsync());
        }

        public HttpResponseMessage ExecuteAsync()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPhrase;

            return responseMessage;
        }
    }
}