using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesLib
{
    internal class Speed : AnyValue
    {
        public Speed()
        {
            ValueName = "Скорость";
            CoefficientsAndMeasuresList = new Dictionary<string, double>()
            {
                {"Км в час", 0.27778 },
                {"Метры в секунду", 1 },
                {"Километры в секунду", 1000 },
            };
        }
    }
}