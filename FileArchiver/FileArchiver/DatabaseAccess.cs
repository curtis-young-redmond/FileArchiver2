using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FileArchiver
{
    class DatabaseAccess
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        protected SqlConnection sqlConnection { get; set; }
        public CmdLineParser cmdLineArgs { get; private set; }
        public DatabaseAccess() { }
        /// <summary>
        /// DatabaseAccess constructor
        /// </summary>
        /// <param name="cmdLineParser">commandline arguments args</param>
        /// <remarks>
        ///Set database name in app config
        ///Command - line parameters: DB server name, [optional] local server name
        ///In code, set local server name to current machine name.Can be overridden by local server name parameter
        /// </remarks>
        public DatabaseAccess(CmdLineParser cmdLineParser)
        {
            cmdLineArgs = cmdLineParser;

            log.Debug("Start of DatabaseAccess constructor");

            StringBuilder connectionBuilder = new StringBuilder();
            System.Data.Common.DbConnectionStringBuilder.AppendKeyValuePair(connectionBuilder, "Data Source", cmdLineArgs.DBServerName);
            System.Data.Common.DbConnectionStringBuilder.AppendKeyValuePair(connectionBuilder, "Initial Catalog", cmdLineArgs.DBName);
            System.Data.Common.DbConnectionStringBuilder.AppendKeyValuePair(connectionBuilder, "Integrated Security", "True");
            System.Data.Common.DbConnectionStringBuilder.AppendKeyValuePair(connectionBuilder, "Timeout", "60");

            sqlConnection = new SqlConnection(connectionBuilder.ToString());
            log.Debug("Stop of DatabaseAccess constructor");
        }
        public List<FileCleanupConfiguration> RetrieveConfigSettings()
        {
            log.Debug("Start of DatabaseAccess RetrieveConfigSettings");
            try
            {
                DataTable configtbl = new DataTable("FileCleanupConfiguration");
                using (var conn = sqlConnection)
                {
                    string command = String.Format("select distinct * from FileCleanupConfiguration Where  lower(CleanUpType) in ('archive','delete') and  ServerName= '{0}' order by OrderofExecution", cmdLineArgs.FileServerName);
                    using (var cmd = new SqlCommand(command, conn))
                    {
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        conn.Open();
                        adapt.Fill(configtbl);
                        conn.Close();
                        if (configtbl.Rows.Count == 0) throw new FAException("Your File Server is not configured");
                        List<FileCleanupConfiguration> list = new List<FileCleanupConfiguration>();

                        for (int i = 0; i < configtbl.Rows.Count; i++)
                        { list.Add(new FileCleanupConfiguration(configtbl.Rows[i])); }

                        var groupbyType = list
                            .GroupBy(u => u.CleanUpType)
                            .Select(n => new
                            {
                                Type = n.Key,
                                TypeCount = n.Count()
                            }
                            ).OrderBy(n => n.Type);
                        var cutlen = list.OrderByDescending(s => s.CleanUpType.Length).First().CleanUpType.Length;
                        var splen = list.OrderByDescending(s => s.SourceFolderPath.Length).First().SourceFolderPath.Length;
                        var patlen = list.OrderByDescending(s => s.SourceFilePattern.Length).First().SourceFilePattern.Length;
                       
                        StringBuilder sb = new StringBuilder(string.Format("\r\n\r\nThe number of configuration rows for {0} is {1}\r\n", cmdLineArgs.FileServerName, configtbl.Rows.Count));
                        sb.Append("\r\nConfiguration Summary:");
                        foreach (var test in groupbyType)
                            sb.Append(string.Format("\r\n {0}={1}", test.Type, test.TypeCount));
                        //log.Debug(sb.ToString());
                        sb.Append("\r\nDetails\r\n");
                        foreach (var test in list)
                            sb.Append(string.Format("Type:{0} Compress:{4} Retention:{5} Source Pattern:{2}  SourcePath: {1} DestinationPath: {3}\r\n", test.CleanUpType.PadRight(cutlen, ' '), test.SourceFolderPath.PadRight(splen, ' '), test.SourceFilePattern.PadRight(patlen, ' '), test.DestinationFolderPath, Convert.ToString(Convert.ToInt16(test.Compress) == 0 ? false : true).PadRight(5, ' '),test.RetentionDays.ToString().PadRight(2,' ')));
                        log.Debug(sb.ToString());

                        return list;
                    }
                }
            }
            catch (FAException faex)
            {
                throw faex;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("{0}", ex.Message));
                return null;
            }
        }

    }
}
