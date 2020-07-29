using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomoriCIP3Mapper.Services
{
    class KomoriUtil
    {

        public string FixFlatName(string fileName)
        {
            //186140 Bosch Thermotechnology Ltd!186140-30714_Bosch Thermotechnology Ltd_8 A .pdf[b].1A.CMYK
            int idx = fileName.LastIndexOf('_');
            string flatName ="";
            string jobNo = "";
            try
            {
                flatName=fileName.Substring(idx+1).Split('.')[0].Replace (" ","");
                jobNo = Path.GetFileName(fileName).Substring(0, 6);
            }
            catch (Exception)
            {
              
            
            }

          if (flatName !="" && idx>1)
            {

                //First make a copy
           File.Copy(fileName, $"c:/orig/{Path.GetFileName(fileName)}",true);
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[4] = $"Job={jobNo}-{flatName}" ;
            File.WriteAllLines(fileName, arrLine);
            }

            return $"Fixed File: {Path.GetFileName (fileName)} with flat code {flatName}";
        }

    } 
}
