using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/**
 * 
 * Note!!! Have not sorted out file permissions yet. 
 * So if you attempt to pass a path in which this program does not have 
 * permissions or access to it will break (i.e. Recycle Bin folders)...
 * still. it sorta works. 
 * 
 * */

namespace recursive_sep_file_folder
{
    class Program
    {
        static void recSepFF(string origPath)
        {
            LinkedList<string> ffList = new LinkedList<string>();

            int folderNum = 0;
            int fileNum = 0;

            foreach (string entry in Directory.GetDirectories(origPath))
            {
                ffList.AddLast(entry);
                folderNum++;
            }
            foreach (string entry in Directory.GetFiles(origPath))
            {
                ffList.AddLast(entry);
                fileNum++;
            }

            Console.WriteLine("====================================================");
            Console.WriteLine("For folder \"" + origPath + "\"");
            Console.WriteLine("====================================================");

            //Printing results out to screen;
            Console.WriteLine("The number of folders we have is " + folderNum + ". \nThe folders we recorded are: \n");

            displayFolders(ffList);

            Console.WriteLine("\n\nThe number of files we have is " + fileNum + ".\nThe files we recorded are: \n");

            displayFiles(ffList);

            Console.WriteLine("");

            if (folderNum >= 1)
            {
                foreach (string item in ffList)
                {
                    if (Directory.Exists(item))
                    {
                        recSepFF(item);
                    }
                }
            }
        }

        static string pathVerif()
        {
            string path = @"NULL";

            do
            {
                Console.WriteLine("Please specify path to use:>");
                path = Console.ReadLine();

                if (Directory.Exists(path))
                    Console.WriteLine("Path \"" + path + "\" exists! Continueing on..");
                else
                    Console.WriteLine("That path is not valid/exists.\nPlease try again:\n");

            } while (!Directory.Exists(path));

            return path;
        }


        static void displayFolders(LinkedList<string> inList)
        {
            Console.WriteLine("Folders recorded: \n>>");
            foreach (string item in inList)
            {
                if (Directory.Exists(item))
                {
                    Console.Write(">" + item);
                    Console.WriteLine("Is the directory valid? " + Directory.Exists(item));
                }
            }
            Console.WriteLine("\n\n");
        }

        static void displayFiles(LinkedList<string> inList)
        {
            Console.WriteLine("Files recorded: \n>>");
            foreach (string item in inList)
            {
                if (File.Exists(item))
                {
                    Console.Write(">" + item + "\n");
                    Console.WriteLine("is the file valid? " + File.Exists(item));
                }
            }
        }

        static void Main(string[] args)
        {
            string somePath = pathVerif();

            recSepFF(somePath);
        }


    }
}
