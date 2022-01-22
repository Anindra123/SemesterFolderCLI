using FolderClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterFolderCreateCli
{
    class Program
    {

        static void Main(string[] args)
        {
            ApplicationUI applicationUI = new ApplicationUI();
            applicationUI.Start();
            Console.ReadKey();
        }
    }
}
