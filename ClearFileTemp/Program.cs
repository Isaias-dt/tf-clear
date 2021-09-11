using System;
using System.IO;
using ClearFileTemp.Entities;

namespace ClearFileTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sysPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                // temp folder of system and local
                string localTempPath = Path.GetTempPath();
                string sysPrefetchPath = sysPath + @"\Prefetch";
                string sysTempPath = sysPath + @"\Temp";

                FilesAndFolders fifoLocalTemp = new FilesAndFolders(localTempPath);
                //FilesAndFolders fifoSysPrefetch = new FilesAndFolders(sysPrefetchPath);
                //FilesAndFolders fifoSysTemp = new FilesAndFolders(sysTempPath);

                Console.Write("Info: Esta aplicação foi feita para limpeza de arquivos temporários.\n" +
                    "As seguintes pastas serão limpas:\n" +
                    $"[{localTempPath}]\n" +
                    $"[{sysPrefetchPath}]\n" +
                    $"[{sysTempPath}]\n" +
                    "\nDeseja continuar com processo? (y/n): ");

                while (true)
                {
                    char op = char.Parse(Console.ReadLine());
                    if (op == 'y' || op == 'Y')
                    {
                        Console.Write("]".PadRight(10, '*'));
                        Console.Write("> " + localTempPath.ToUpper() + " <");
                        Console.WriteLine("".PadLeft(10, '*') + "[");
                        fifoLocalTemp.DeleteAllPath();

                        //Console.Write("]".PadRight(10, '*'));
                        //Console.Write("> " + localTempPath.ToUpper() + " <");
                        //Console.WriteLine("".PadLeft(10, '*') + "[");
                        //fifoSysPrefetch.DeleteAllPath();

                        //Console.Write("]".PadRight(10, '*'));
                        //Console.Write("> " + localTempPath.ToUpper() + " <");
                        //Console.WriteLine("".PadLeft(10, '*') + "[");
                        //fifoSysTemp.DeleteAllPath();

                        break;
                    }
                    else if (op == 'n' || op == 'N')
                    {
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
