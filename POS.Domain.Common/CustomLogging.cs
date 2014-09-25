using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Common
{
    public class CustomLogging
    {
        public static void Log(string logType, string description)
        {
            string logfilename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

           // string logdrive = ConfigurationManager.AppSettings["FolderPath"];
            string logdrive = @"C:\POS\RETAIL\Logs\";
            string isLogEnabledFromConfig = "true";
            bool isLogEnabled = false;
            bool.TryParse(isLogEnabledFromConfig, out isLogEnabled);

            if (isLogEnabled)
            {
                DirectoryInfo folder = new DirectoryInfo(logdrive);

                if (folder.Exists == false)
                {
                    folder.Create();
                    logType = "Warning";
                    description = "The logs folder was deleted, hence the process has re-created";
                }

                StreamWriter streamwriter = new StreamWriter(File.Open(logdrive + logfilename, FileMode.Append));
                streamwriter.WriteLine(DateTime.Now + " | " + logType + " | " + description + " | ");
                streamwriter.Flush();
                streamwriter.Close();
            }
        }
    }
}
