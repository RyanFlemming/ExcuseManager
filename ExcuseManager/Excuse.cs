using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManager
{
    class Excuse
    {
        public string Description { get; set; }
        public string Results { get; set; }
        public DateTime LastUsed { get; set; }
        public string ExcusePath { get; set; }

        // Default to be used when initialising form
        public Excuse()
        {
            ExcusePath = "";
        }

        // Create new instance, open file
        public Excuse(string excusePath)
        {
            OpenFile(excusePath);
        }

        // Open random file
        // Create array of files from path with .txt ext
        // Then choose random element in array and open file
        public Excuse(Random random, string path)
        {
            string[] fileNames = Directory.GetFiles(path, "*.txt");
            OpenFile(fileNames[random.Next(fileNames.Length)]);
        }


        // Set properties to be written to the form
        // Then close stream and dispose
        public void OpenFile(string excusePath)
        {
            this.ExcusePath = excusePath;
            using (StreamReader sr = new StreamReader(ExcusePath))
            {
                Description = sr.ReadLine();
                Results = sr.ReadLine();
                LastUsed = Convert.ToDateTime(sr.ReadLine());
            }
        }


        // Persist changes, close stream and dispose
         public void Save(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(Description);
                sw.WriteLine(Results);
                sw.WriteLine(LastUsed.ToShortDateString());
            }
        }
    }
}