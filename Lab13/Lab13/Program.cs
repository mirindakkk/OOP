using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                KAYDiskInfo diskInfo = new KAYDiskInfo();
                diskInfo.DiskInfo();

                KAYFileInfo file = new KAYFileInfo();
                file.FileData("E:\\2 курс\\1 сем\\ООП\\Lab13\\Lab13\\KAYFileInfo.txt");

                KAYDirInfo dirInfo = new KAYDirInfo();
                dirInfo.DirInfo("E:\\2 курс\\1 сем\\ООП\\Lab13\\Lab13\\KAYNewCatalog");

                KAYFileManager fileManager = new KAYFileManager();
                fileManager.KAY("E:\\2 курс\\1 сем\\ООП\\Lab13\\Lab13");

                KAYArchive ar = new KAYArchive();
                ar.GetArchive("E:\\2 курс\\1 сем\\ООП\\Lab13");

                KAYLog test = new KAYLog();
                test.Search();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}