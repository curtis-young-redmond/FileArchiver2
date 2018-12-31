using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecompressorUI
{
    class DTFile
    {
        public DTFile(DateTime dateTime, string strPath)
        {
            this.dateTime = dateTime;
            this.strPath = strPath;
        }
        public DateTime dateTime { get; set; }
        public string strPath { get; set; }

    }
}
