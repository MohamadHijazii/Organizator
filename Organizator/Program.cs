using System;
using System.IO;
using System.Collections.Generic;
namespace Organizator
{
    class Program
    {
        static List<string> direc;
        static void organize(string path)
        {
            string[] ls = Directory.GetFiles(path);
            direc = new List<string>();

            foreach (string s in ls)
            {
                FileInfo f = new FileInfo(s);
                string[] splited = f.LastWriteTime.ToString().Split("-");
                string time = (splited[1] + "-20" + splited[2]).Split(" ")[0];
                if (direc.Contains(time))
                {
                    string newPath = path + "/" + time + "/" + f.Name;
                    File.Move(path + "/" + f.Name, newPath);
                }
                else
                {
                    Directory.CreateDirectory(path + "/" + time);
                    string newPath = path + "/" + time + "/" + f.Name;
                    File.Move(path + "/" + f.Name, newPath);
                    direc.Add(time);
                }
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter the full path: ");
            string path = Console.ReadLine();
            organize(path);
            Console.WriteLine("done!");
        }
    }
}
