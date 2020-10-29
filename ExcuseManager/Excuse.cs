using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExcuseManager
{
    [Serializable]
    public class Excuse : IExcuse
    {
        [NonSerializedAttribute]
        private readonly IFormatter formatter;

        public string Description { get; set; }
        public string Results { get; set; }
        public DateTime LastUsed { get; set; }
        public string ExcusePath { get; set; }

        // Default to be used when initialising form
        public Excuse(IFormatter formatter)
        {
            ExcusePath = "";
            this.formatter = formatter;
            LastUsed = DateTime.Now;
        }

        // Create new instance, open file
        public Excuse(string excusePath, IFormatter formatter)
        {
            this.formatter = formatter;
            OpenFile(excusePath);
        }

        // Open random file
        // Create array of files from path with .txt ext
        // Then choose random element in array and open file
        public Excuse(Random random, string path, IFormatter formatter)
        {
            this.formatter = formatter;
            string[] fileNames = Directory.GetFiles(path, "*.excuse");
            OpenFile(fileNames[random.Next(fileNames.Length)]);
        }


        // Set properties to be written to the form
        // Then close stream and dispose
        public void OpenFile(string excusePath)
        {
            ExcusePath = excusePath;
            Excuse tempExcuse;

            using (Stream input = File.OpenRead(excusePath))
            {
                tempExcuse = (Excuse)formatter.Deserialize(input);
            }
            Description = tempExcuse.Description;
            Results = tempExcuse.Results;
            LastUsed = tempExcuse.LastUsed;
        }


        // Persist changes, close stream and dispose
        public void Save(string fileName)
        {
            using (Stream output = File.OpenWrite(fileName))
            {
                formatter.Serialize(output, this);
            }
        }
    }
}