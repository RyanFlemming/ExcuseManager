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
        // These methods mirror the 3 constructors on Excuse
        // An excuse and an instance of BinaryFormatter is newed up in each
        public static IExcuse CreateExcuse()
        {
            return new Excuse(CreateFormatter());
        }

        public static IExcuse CreateExcuse(string path)
        {
            return new Excuse(path, CreateFormatter());
        }
        public static IExcuse CreateExcuse(Random randomFile, string selectedFolder)
        {
            return new Excuse(randomFile, selectedFolder, CreateFormatter());
        }

        public static IFormatter CreateFormatter()
        {
            IFormatter formatter = new BinaryFormatter();
            return formatter;
        }
    }
}
