using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class KAYArchive
    {
        public void GetArchive(string path)
        {
            ZipFile.CreateFromDirectory(path, "D:\\Лабы\\2 курс\\1 сем\\Labs3Sem\\C#\\Лабораторные\\Lab13\\Archive.gz");
        }
    }
}
