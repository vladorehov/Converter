using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValuesLib
{
    internal class Time : AnyValue
    {
        public Time()
        {
            ValueName = "Время";
            CoefficientsAndMeasuresList = new Dictionary<string, double>()
            {
                { "Секунды",        1       },
                { "Милисекунды",    0.001   },
                { "Минуты",         60      },
                { "Часы",           60 * 60 },
            };
        }
    }
}