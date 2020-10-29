using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExcuseManager
{
    [Serializable]
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
            string[] fileNames = Directory.GetFiles(path, "*.excuse");
            OpenFile(fileNames[random.Next(fileNames.Length)]);
        }


        // Set properties to be written to the form
        // Then close stream and dispose
        public void OpenFile(string excusePath)
        {
            this.ExcusePath = excusePath;
            BinaryFormatter formatter = new BinaryFormatter();
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
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream output = File.OpenWrite(fileName))
            {
                formatter.Serialize(output, this);
            }
        }
    }
}