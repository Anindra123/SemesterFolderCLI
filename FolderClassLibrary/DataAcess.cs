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
        //Check whether a course folder already exist
        public bool CheckCourseFolderExists(string courseName,string rootpath)
        {
            string fullpath = $@"{rootpath}\{courseName}";
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

        //check if directory exist
        public string CheckSemesterDirectory(string semesterName)
        {
            semesterFolder.FolderName = semesterName;
            path = semesterFolder.GetRootFolderPath(@"E:\");
            try
            {
                if (Directory.Exists(path))
                {
                    return path;
                }
                else
                {
                    throw new ArgumentException("Semester folder not created.Please try again");
                }
            }
            catch
            {
                throw;
            }
        }


        //Add a new course folder on currrent semester folder
        public void AddCourseDirectory(string rootpath,List<CoursesFolder> folders)
        {
            if(folders.Count > 0)
            {
                foreach (var folder in folders)
                {
                    try
                    {
                        if (!Directory.Exists(folder.GetDirectoryPath(rootpath)))
                        {
                            Directory.CreateDirectory(folder.GetDirectoryPath(rootpath));
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
