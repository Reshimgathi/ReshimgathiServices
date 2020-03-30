using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ReshimgathiServices
{
    public class FileUtility
    {
        public string Path = @"C:\E\VS-Programs\Organizations\Reshimgathi\ReshimgathiServices\ReshimgathiServices\Logs\";
        public string Name = "ReshimgathiMatrimony-DailyLog-{0}.txt";

        public void CreateFile(string path, string content)
        {
            StreamWriter f1 = null;
            try
            {
                if (!File.Exists(path))
                    File.Create(path);

                f1 = new StreamWriter(path, true);
                f1.WriteLine(content);
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                f1.Close();
            }
        }
    }
}