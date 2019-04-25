using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace DirectoryReplicate.Utility
{
    public static class LogHandler
    {
        public static readonly log4net.ILog Log
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static FileAppender FileAppender = ((Hierarchy) LogManager.GetRepository())
                                                                            .Root.Appenders.OfType<FileAppender>()
                                                                            .FirstOrDefault();
    }
}
