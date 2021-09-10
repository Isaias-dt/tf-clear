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
                FilesAndFolders fifoSysPrefetch = new FilesAndFolders(sysPrefetchPath);
                FilesAndFolders fifoSysTemp = new FilesAndFolders(sysTempPath);

                Console.Write("]".PadRight(10, '*'));
                Console.Write("> " + localTempPath.ToUpper() + " <");
                Console.WriteLine("".PadLeft(10, '*') + "[");
                fifoLocalTemp.DeleteAllPath();

                Console.Write("]".PadRight(10, '*'));
                Console.Write("> " + localTempPath.ToUpper() + " <");
                Console.WriteLine("".PadLeft(10, '*') + "[");
                fifoSysPrefetch.DeleteAllPath();

                Console.Write("]".PadRight(10, '*'));
                Console.Write("> " + localTempPath.ToUpper() + " <");
                Console.WriteLine("".PadLeft(10, '*') + "[");
                fifoSysTemp.DeleteAllPath();

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
