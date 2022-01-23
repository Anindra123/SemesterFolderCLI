using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterFolderCreateCli
{
    public class Menu
    {
        string[] menuOptions;
        int selectedIndex;
        public Menu(string[] options)
        {
            menuOptions = options;
            selectedIndex = 0;
        }
        private void DisplayOptions()
        {
            Title();
            for (int i = 0; i < menuOptions.Length; i++)
            {

                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{menuOptions[i]}");
            }
            Console.ResetColor();
        }

        private void Title()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|\t\t\t\tSemester Manager\t\t\t\t|");
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        public int Run()
        {
            ConsoleKey keyPressed;

            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex > menuOptions.Length - 1)
                    {
                        selectedIndex = 0;
                    }
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = menuOptions.Length - 1;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}
