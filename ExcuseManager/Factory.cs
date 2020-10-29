using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManager
{
    public static class Factory
    {
        public static IExcuse CreateExcuse()
        {
            return new Excuse(CreateFormatter());
        }

        public static IExcuse CreateExcuse(string path)
        {
            return new Excuse(path, CreateFormatter());
        }

        public static IFormatter CreateFormatter()
        {
            IFormatter formatter = new BinaryFormatter();
            return formatter;
        }

        public static IExcuse CreateExcuse(Random randomFile, string selectedFolder)
        {
            return new Excuse(randomFile, selectedFolder, CreateFormatter());
        }
    }
}
