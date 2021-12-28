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
                file.FileData("D:\\Лабы\\2 курс\\1 сем\\Labs3Sem\\C#\\Лабораторные\\Lab13\\Lab13\\KAYFileInfo.txt");

                KAYDirInfo dirInfo = new KAYDirInfo();
                dirInfo.DirInfo("D:\\Лабы\\2 курс\\1 сем\\Labs3Sem\\C#\\Лабораторные\\Lab13\\Lab13\\KAYNewCatalog");

                KAYFileManager fileManager = new KAYFileManager();
                fileManager.KAY("D:\\Лабы\\2 курс\\1 сем\\Labs3Sem\\C#\\Лабораторные\\Lab13\\Lab13");

                KAYArchive ar = new KAYArchive();
                ar.GetArchive("D:\\Лабы\\2 курс\\1 сем\\Labs3Sem\\C#\\Лабораторные\\Lab13");

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