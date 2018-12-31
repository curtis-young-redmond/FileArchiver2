using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace FileArchiver
{
    class FileArchiverStartUp
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();
        //private static readonly log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            CmdLineParser cmdline = null;
            try
            {

                #region log4net informational
                // Get app version
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string versionfull = String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                string versionshort = String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build);
                log.Info("Application Version (Major, Minor, Build, Revision): " + versionfull);
                log.Info("Start of FileArchiverStartUp Main*********************************************");
                #endregion

                #region File Management
                cmdline = new CmdLineParser(args, log);
                cmdline.TryDisplayBasicInstructions();
                (new FileManagement((new DatabaseAccess(cmdline)).RetrieveConfigSettings(), cmdline)).ProcessFilesInParallel();
                #endregion

            }
            catch (FAException)
            {
                log.Error(string.Format("ERROR: most likely cause is {0} is not configured on {1}", cmdline.FileServerName, cmdline.DBServerName));
                Console.WriteLine(string.Format("ERROR: most likely cause is {0} is not configured on {1}", cmdline.FileServerName, cmdline.DBServerName));
                if (!cmdline.RunMode)
                {
                    Console.WriteLine("\r\n\r\n\r\n Press any key");
                    Console.ReadKey();
                }
            }
            catch (ControlException cx)
            {
                if (cmdline.RunMode && cmdline.DIRMode)
                    log.Error(string.Format("You can't create directories with the -B flag while the -R flag is set.{0}", cx.Message));
                if (cmdline.TestMode && cmdline.DIRMode)
                    log.Info(string.Format("FileArchiver is stopping {0}", cx.Message));
                if (!cmdline.RunMode)
                {
                    Console.WriteLine("Press anykey to exit");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("FileArchiver is stopping {0}", ex.Message));
            }

            log.Info("FileArchiver is stopping*********************************************");
        }
    }
}
