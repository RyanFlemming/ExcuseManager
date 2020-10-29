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


        // Create array of files from path, then open random file
        public Excuse(Random random, string path, IFormatter formatter)
        {
            this.formatter = formatter;
            string[] fileNames = Directory.GetFiles(path, "*.excuse");
            OpenFile(fileNames[random.Next(fileNames.Length)]);
        }


        // Set path of the excuse, then create a temp excuse
        // Use our instance of formatter to deserialize our unicode file
        // Finally, set object properties
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


        // Serialize excuse object to specified path
        public void Save(string fileName)
        {
            using (Stream output = File.OpenWrite(fileName))
            {
                formatter.Serialize(output, this);
            }
        }
    }
}