using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    public class KAYFileManager
    {   
        public void KAY(string path)
        {
            string filepath;
            Directory.CreateDirectory(filepath = path + "\\" + "KAYInspect");

            string filepath2;
            FileInfo fileInfo = new FileInfo(filepath2 = path + "\\" + "KAYdirinfo.txt");

            using (FileStream fstream = new FileStream(filepath2, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(fstream);
                if (Directory.Exists(path))
                {
                    sw.WriteLine("Files");
                    string[] files = Directory.GetFiles(path);
                    foreach (string s in files)
                    {
                        sw.WriteLine(s);
                    }
                    sw.WriteLine();
                
                    sw.WriteLine("Folders");
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string s in dirs)
                    {
                        sw.WriteLine(s);
                    }
                }
                sw.Close();
            }

            string filepath3;
            FileInfo fileInfo3 = new FileInfo(filepath3 = path + "\\" + "KAYdirinfoCopy.txt");

            fileInfo.CopyTo(filepath3 + ".txt", true);
            fileInfo.Delete();

            string filecopydir;
            DirectoryInfo dInfo = new DirectoryInfo(filecopydir = path + "KAYFiles");
            dInfo.Create();

            string[] files2 = Directory.GetFiles(path);

            foreach (string s in files2)
            {
                File.Copy(s, filecopydir + "\\" + new FileInfo(s).Name);
            }
        }
    }
}