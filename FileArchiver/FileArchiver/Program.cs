using System;
using System.Collections.Generic;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace FileArchiver
{
    class Program
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();//log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            log.Debug("Start of Program Main");
            #region DB Config stuff
            var myDB = new DatabaseAccess(args[0]);
            var myconfigList = new List<FileCleanupConfiguration>();
            myconfigList = myDB.RetrieveConfigSettings();
            #endregion
            #region File Management
            var manageFiles = new FileManagement(myconfigList);
            manageFiles.ProcessFiles();

            #endregion
            log.Debug("Stop of Program Main");
        }
    }
}
