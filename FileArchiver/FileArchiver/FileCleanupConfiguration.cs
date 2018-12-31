using System.Data;
using System;
namespace FileArchiver
{
    class FileCleanupConfiguration
    {

        public FileCleanupConfiguration(DataRow dataRow)
        {
            CleanUpType = dataRow[0].ToString().ToLower();
            ServerName = dataRow[1].ToString();
            SourceFolderPath = dataRow[2].ToString().Trim() + (!dataRow[2].ToString().EndsWith("\\") && dataRow[2].ToString().Length > 0 ? "\\" : "");
            SourceFilePattern = dataRow[3].ToString();
            RetentionDays = Convert.ToInt32(dataRow[4]);
            DestinationFolderPath = dataRow[5].ToString().Trim() + (!dataRow[5].ToString().EndsWith("\\") && dataRow[5].ToString().Length > 0 ? "\\" : "");
            if (DestinationFolderPath == "")
                DestinationFolderPath = SourceFolderPath;
            Compress = Convert.ToBoolean(dataRow[6]);
            OrderofExecution = Convert.ToInt32(dataRow[7]);
        }
        public string CleanUpType { get; private set; }
        public string ServerName { get; private set; }
        public string SourceFolderPath { get; private set; }
        public string SourceFilePattern { get; private set; }
        public int RetentionDays { get; private set; }
        public string DestinationFolderPath { get; private set; }
        public bool Compress { get; private set; }
        public int OrderofExecution { get; set; }

        public static string threadName(string _sourceFolderPath)
        {
            string builder="..\\";
            string init = "\\";
            char[] separator = { '\\' } ;
            var reducedstring = _sourceFolderPath.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = reducedstring.Length*2/3; i < reducedstring.Length; i++)
                builder += reducedstring[i] + init;
            return builder;
        }
    }
}