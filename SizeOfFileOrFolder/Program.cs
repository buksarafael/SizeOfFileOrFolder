using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeOfFileOrFolder
{
    class Program
    {
        public static decimal size = 0;
        static void Main(string[] args)
        {
            string[] measurments = { "Bytes", "Kb", "Mb", "Gb", "Tb" };
            int m = 0;
            string path = ".\\Test";
            var fi1 = new FileInfo(path);
            string[] files;

            if (File.Exists(path))
            {
                size = size + fi1.Length;
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine($"{path} is not a valid file or directory.");
            }

            if (size >= 1024)
            {
                m++;
                size = size / 1024;
            }
            Console.WriteLine($"{size} {measurments[m]}");
        }

        private static void ProcessDirectory(string path)
        {
            string temp;
            string[] files;
            files = Directory.GetFiles(path);
            foreach (string dir in files)
            {
                temp = dir;
                var fi1 = new FileInfo(temp);
                size = size + fi1.Length;
            }


            if (Directory.Exists(path))
            {
                files = Directory.GetDirectories(path);
                foreach (string dir in files)
                {
                    ProcessDirectory(dir);
                }
            }
        }
    }
}

