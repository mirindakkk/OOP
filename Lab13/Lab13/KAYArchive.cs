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
            ZipFile.CreateFromDirectory(path, "E:\\2 курс\\1 сем\\ООП\\Lab13\\Archive.gz");
        }
    }
}
