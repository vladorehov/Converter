using IValueLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesLib
{
    internal class AnyValue : IValue
    {
        // Поля
        private string _valueName = "Default";     // Имя физической величины

        // Словарь единиц измерения и переводных коэффициентов
        private Dictionary<string, double> _coeff = new Dictionary<string, double>()
        {
            { "Default1",    1   }
        };

        // Свойства
        protected string ValueName { get; set; }

        protected Dictionary<string, double> CoefficientsAndMeasuresList { get; set; }

        // Методы IValue
        public Dictionary<string, double> GetCoefficients() => CoefficientsAndMeasuresList;

        public string GetValueName() => ValueName;
    }
}
