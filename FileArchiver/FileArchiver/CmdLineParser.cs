using System;
using System.Text.RegularExpressions;
using System.Configuration;
using log4net;

namespace FileArchiver
{
    class CmdLineParser
    {

        private string dbname;

        public string DBName
        {
            get
            {
                if (dbname == null)
                    dbname = ConfigurationManager.AppSettings["DBName"];
                return dbname;
            }
            set { dbname = value; }
        }

        public string DBServerName { get; private set; }
        //public string FileServer { get; private set; }
        private string fileServerName;
        private ILog log;

        public string FileServerName
        {
            get
            {
                if (fileServerName == null)
                    fileServerName = System.Environment.MachineName;
                return fileServerName;
            }
            private set { fileServerName = value; }
        }
        public bool RunMode { get; private set; }
        public bool TestMode { get; private set; }
        public bool DIRMode { get; private set; }

        //private AppMode RunTestApp { get; }

        public CmdLineParser(string[] args, ILog ilog)
        {
            log = ilog;
            const string Patternserver = "[-/]{1}[DF]{1}[:][A-Za-z0-9]+";
            Regex rxserver = new Regex(Patternserver);
            const string Patternflag = "[-/][BRT]{1}";
            Regex rxflag = new Regex(Patternflag);
            Console.WriteLine("Current Command line settings:");
            foreach (var arg in args)
            {
                if (rxserver.IsMatch(arg))
                {
                    Console.Write(rxserver.Match(arg) + " ");
                    switch (Convert.ToChar(rxserver.Match(arg).ToString().Substring(1, 1).ToUpper()))
                    {
                        case 'D':
                            DBServerName = arg.Substring(3).ToUpper();
                            break;
                        case 'F':
                            FileServerName = arg.Substring(3).ToUpper();
                            break;
                    }
                }
                if (rxflag.IsMatch(arg))
                {
                    switch (Convert.ToChar(rxflag.Match(arg).ToString().Substring(1).ToUpper()))
                    {
                        case 'R':
                            //RunTestApp = RunTestApp == AppMode.test ? AppMode.test : AppMode.run;
                            if (TestMode)
                            {
                                log.Warn("Test flag detected in cmd line arguments; Forcing run flag to false.");
                                RunMode = false;
                            }
                            else
                                RunMode = true;
                            break;
                        case 'T':
                            //RunTestApp = AppMode.test;
                            TestMode = true;
                            if (TestMode)
                            {
                                log.Warn("Test flag detected in cmd line arguments; Forcing run flag to false.");
                                RunMode = false;
                            }
                            break;
                        case 'B':
                            DIRMode = true;
                            break;
                    }
                    Console.Write(rxflag.Match(arg) + " ");
                }
            }
            var msg = string.Format(" DB server:{0}, FileServer:{1}, Test Flag:{2}, Run Flag:{3}, DIR Flag:{4} ", DBServerName, FileServerName, TestMode, RunMode, DIRMode);
            log.Info("\r\n" + msg + "\r\n");
        }

        public void TryDisplayBasicInstructions()
        {
            if (!(RunMode || TestMode))
            {
                ShowUserInstructions();
                throw new ControlException("");
            }
            if (RunMode && DIRMode)
                throw new ControlException("");
        }

        protected void ShowUserInstructions()
        {
            Console.Write("\r\n\r\n");
            Console.WriteLine("App          - FileArchiver");
            Console.WriteLine("Definition   - deletes, moves and/or archives files on Servers to reduce the need for storage.\r\n");
            Console.WriteLine(" Arguments:");
            Console.WriteLine("           -D: followed by the Database server name is where the configurations are stored for all.\r\n");
            Console.WriteLine("           -F: followed by the FileServer name where files to be managed are located.\r\n");
            Console.WriteLine("           -R this flag enables the application to run normally; without it the app won't run.\r\n");
            Console.WriteLine("           -T this flag tests the commandline arguments and configuration values.");
            Console.WriteLine("              the R and T flag are mutually exclusive, if both are used the T flag shall take precedent.\r\n");
            Console.WriteLine("           -B this directory flag (DIR flag) in conjunction with the -T flag will build the directory if it does not exist.");
        }
    }
}

