using System;

namespace ExcuseManager
{
    [System.ComponentModel.Localizable(false)]
    public interface IExcuse
    {
        string Description { get; set; }
        string ExcusePath { get; set; }
        DateTime LastUsed { get; set; }
        string Results { get; set; }

        void OpenFile(string excusePath);
        void Save(string fileName);
    }
}