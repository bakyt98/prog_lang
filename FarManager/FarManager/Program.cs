using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Program
    {
        static void print(int pos, DirectoryInfo dir)
        {
            Console.SetCursorPosition(0, 0);
            int line = 0;
            Console.Clear();
            foreach(Object i in dir.GetFileSystemInfos() )
            {
                if (line == pos)
                    Console.BackgroundColor = ConsoleColor.White;
                else Console.BackgroundColor = ConsoleColor.Black;
                line++;
                if (i is DirectoryInfo)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(((DirectoryInfo)i).Name);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(((FileInfo)i).Name);
                }
            }


        }
        
        static void Main(string[] args)
        {
            int pos = 0;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\user\Desktop");
          
              
            print(pos,dir);
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (pos == 0)
                        pos = dir.GetFileSystemInfos().Length - 1;
                    else pos--;
                }
                else if (info.Key == ConsoleKey.DownArrow)
                {
                    if (pos == dir.GetFileSystemInfos().Length - 1)
                        pos = 0;
                    else pos++;
                }
                else if (info.Key == ConsoleKey.Enter)
                {


                    FileSystemInfo fs = dir.GetFileSystemInfos()[pos];
                    pos = 0;
                    if (fs.GetType() == typeof(DirectoryInfo))
                    {

                        dir = new DirectoryInfo(fs.FullName);


                    }
                    else
                    {
                        Process.Start(fs.FullName);
                    }

                }
                else if (info.Key == ConsoleKey.Escape)
                    dir = dir.Parent;
                print(pos, dir);
            }



            }

        }
    }

