using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Entry point
namespace KomoriCIP3Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(args[0],Convert.ToInt32 (args[1]));
        }

        static void Run(string scanDir,int daysToProcess)
        {
            var komirServ = new Services.KomoriUtil();
            string[] files = Directory.GetFiles(scanDir, "*.PQ4", SearchOption.AllDirectories);

            foreach (string PQ4File in files)
            {
              var fileCreated=  File.GetCreationTime(PQ4File);

                if (fileCreated> DateTime .Now.AddDays (-daysToProcess))
                {
                    var resultingFlat = komirServ.FixFlatName(PQ4File);
                    Console.WriteLine(resultingFlat);
                }
              
            }
        }

    }
}
