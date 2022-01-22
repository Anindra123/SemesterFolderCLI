using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderClassLibrary
{
    public class CoursesFolder
    {
        public string FolderName { get; set; }

        public string GetDirectoryPath(string rootPathName)
        {
            return $@"{rootPathName}\{FolderName}";
        }
    }
}
