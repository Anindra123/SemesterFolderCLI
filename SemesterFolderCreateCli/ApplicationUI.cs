using FolderClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterFolderCreateCli
{
    public class ApplicationUI
    {
        DataAcess dataAcess = new DataAcess();
        public void Start()
        {
            RunMainMenu();
        }

        private void ExitApplication()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress Enter to Exit Application");
            Console.ResetColor();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Environment.Exit(0);
                    break;
                }
            }

        }
        private void MenuBack()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("<< Go Back ");
            Console.ReadKey();
            Console.ResetColor();
        }
        private void RunMainMenu()
        {
            string[] options = { "1.Create new semester folder", "2.Check if MID/FINAL complete", "3.Exit" };
            Menu menu = new Menu(options);
            int selectedIndex = 0;
            do
            {
                selectedIndex = menu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        CreatFolder();
                        CreateSubFolder();
                        MenuBack();
                        break;
                    case 1:
                        MenuBack();
                        break;
                }
            } while (selectedIndex != 2);

            if (selectedIndex == 2)
            {
                ExitApplication();
            }
        }

        private void CreatFolder()
        {

            Console.Write("Enter your current semester: ");
            string currentSemester = Console.ReadLine();
            try
            {
                dataAcess.CreateNewSemesterDirectory(currentSemester);
                SucessMessage("Semester Directory Created Sucesfully...");

            }
            catch (ArgumentException e)
            {
                ErrorMessage(e.Message);
            }
            catch (IOException)
            {
                ErrorMessage("Bad Data Given");
            }
        }

        private void CreateSubFolder()
        {
            Console.WriteLine(@"Enter all the courses names sperated by a comma ',' :");
            string[] coursesName = Console.ReadLine().Trim().Split(',');
            for (int i = 0; i < coursesName.Length; i++)
            {
                if (!dataAcess.CheckCourseFolderExists(coursesName[i]))
                {
                    dataAcess.GetCoureseFoldersNames(coursesName[i]);
                    SucessMessage($"Folder created for {coursesName[i]}");
                }
                else
                {
                    ErrorMessage($"Folder already exist for {coursesName[i]}");
                    continue;
                }
            }
            try
            {
                dataAcess.CreateCouresDirectories();
                SucessMessage("All Course directory created sucessfully...");
            }
            catch (ArgumentException e)
            {
                ErrorMessage(e.Message);
            }
            catch (IOException)
            {
                ErrorMessage("Bad Data Given");
            }
        }

        private void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private void SucessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
