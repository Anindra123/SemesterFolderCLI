using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderClassLibrary
{
    public class DataAcess
    {
        SemesterFolder semesterFolder = new SemesterFolder();
        List<CoursesFolder> coursesFolderNames = new List<CoursesFolder>();
        string path = "";
        //Creates a new base directory with the current name of the semester
        public void CreateNewSemesterDirectory(string semesterName)
        {

            semesterFolder.FolderName = semesterName;
            path = semesterFolder.GetRootFolderPath(@"E:\");
            try
            {
                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);
                }
                else
                {
                    throw new ArgumentException("Directory Already Exists");
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        //Check whether a course folder already exist
        public bool CheckCourseFolderExists(string courseName)
        {
            string fullpath = $@"{path}\{courseName}";
            if (Directory.Exists(fullpath))
            {
                return true;
            }
            return false;
        }

        //Give a list of folder names to create folders from
        public void GetCoureseFoldersNames(string courseName)
        {
            CoursesFolder coursesFolder = new CoursesFolder();
            coursesFolder.FolderName = courseName;
            coursesFolderNames.Add(coursesFolder);
        }

        //Create the directories from the folder name list
        public void CreateCouresDirectories()
        {
            if (coursesFolderNames.Count > 0)
            {
                foreach (var item in coursesFolderNames)
                {
                    try
                    {
                        if (!Directory.Exists(item.GetDirectoryPath(path)))
                        {
                            Directory.CreateDirectory(item.GetDirectoryPath(path));
                        }

                    }
                    catch (IOException)
                    {
                        throw;
                    }

                }
            }
        }

    }
}
