﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class KAYLog
    {
        public void Search()
        {
            DateTime lastChanged = File.GetLastWriteTime(@"E:\\2 курс\\1 сем\\ООП\Lab13\NEWFile.txt");
            string curTimeLong = DateTime.Now.ToLongTimeString();
            using (StreamWriter sw = new StreamWriter(@"E:\\2 курс\\1 сем\\ООП\Lab13\NEWFile.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("File created time : " + curTimeLong);
                sw.WriteLine("File created time : " + lastChanged);
            }
        }
    }
}