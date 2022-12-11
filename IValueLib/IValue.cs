using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValueLib
{
    public interface IValue
    {
        #region Методы для API

        /// <summary>
        /// Метод получения словаря с коэффициентами
        /// </summary>
        /// <returns></returns>
        Dictionary<string, double> GetCoefficients();
        /// <summary>
        /// Метод возвращает название физичской величины
        /// </summary>
        /// <returns></returns>
        string GetValueName();

        #endregion
    }
}