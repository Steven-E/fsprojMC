using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace recursive_sep_file_folder
{
    class Program
    {
        static void recSepFF(string origPath) 
        {
            string[] fileNfolders = Directory.GetFileSystemEntries(origPath);
            //alright, so getting rid of the RegEx bad idea :(
            //string fileExp = @"\.+\w+\w?\w?\w$";

            //string folderExp = @"\\[A-Z0-9]$";

            string[] files = new string[50];

            string[] folders = new string[50];

            int fileSize = 0;
            int folderSize = 0;

            foreach (string s in fileNfolders)
            {
                if (!Directory.Exists(s))
                {
                    files[fileSize] = s.Substring(s.LastIndexOf('\\') + 1);
                    fileSize++;
                }
                else if (Directory.Exists(s))
                {
             
                    folders[folderSize] = s;
                    folderSize++;
                
                }

                //if the above is not true, then i have no worries. continue. 
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("For folder \"" + origPath + "\"");
            Console.WriteLine("====================================================");

            //Printing results out to screen;
            Console.WriteLine("The number of folders we have is " + folderSize + ". \nThe folders we recorded are: \n");

            for (int i = 0; i < folderSize; i++)
                Console.WriteLine("\t" + folders[i]);

            Console.WriteLine("\n\nThe number of files we have is " + fileSize + ".\nThe files we recorded are: \n");

            for (int i = 0; i < fileSize; i++)
                Console.WriteLine("\t" + files[i]);

            Console.WriteLine("");


            if (folderSize >= 1)
            {
                for (int i = 0; i < folderSize; i++)
                    recSepFF(folders[i]);
            }            
        }

        static string getPathFromUser() 
        {
            string userPath;
            Console.WriteLine("Please specify the path you would like to use:\n>");

            userPath = Console.ReadLine();

            while (!Directory.Exists(userPath)) 
            {
                Console.WriteLine("Sorry...That directory does not exits.\nPlease enter another VALID directory:\n>");
                userPath = Console.ReadLine();
            }

            return userPath;
        }

        static void Main(string[] args)
        {
            string somePath = getPathFromUser();

            recSepFF(somePath);
        }


    }
}
