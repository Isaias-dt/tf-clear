using System;
using System.IO;
using ClearFileTemp.Entities;
using ClearFileTemp.Views;

namespace ClearFileTemp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sysPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string[] pathTempFolders = {
                    // temp folder of system and local
                    Path.GetTempPath(),
                    sysPath + @"\Prefetch",
                    sysPath + @"\Temp"
                };
                
                Print print = new Print();
                foreach (string p in pathTempFolders)
                {
                    print.AddPath(new TempFolder(p));
                }
                print.Show();
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
