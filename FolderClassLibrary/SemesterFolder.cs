using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderClassLibrary
{
    public class SemesterFolder
    {
        public string FolderName { get; set; }

        public string GetRootFolderPath(string rootPathName)
        {
            return $@"{rootPathName}\{FolderName}";
        }
    }
}
