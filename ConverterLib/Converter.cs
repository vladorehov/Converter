using IValueLib;
using System.Reflection;

namespace ConverterLib
{
    public class Converter
    {
        public Converter()
        {
            SetValuesList();
        }

        /// <summary>
        /// Список физических величин
        /// </summary>
        private static List<IValue> _physicValues = new List<IValue>();

        private static void SetValuesList()
        {
            Assembly asm = Assembly.LoadFrom("ValuesLib.dll");
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                if ((type.IsInterface == false) && (type.IsAbstract == false) && (type.Name != ("AnyValue")) && (type.GetInterface("IValue") != null))
                {
                    IValue value = (IValue)Activator.CreateInstance(type);
                    _physicValues.Add(value);
                }
            }
        }

        /// <summary>
        /// Метод возвращает список физических величин, реализованных в приложении
        /// </summary>
        /// <returns>Списко физических величин</returns>
        public List<string> GetPhysicValuesList()
        {
            List<string> physicValueList = new List<string>();
            foreach (IValue value in _physicValues)
            {
                physicValueList.Add(value.GetValueName());
            }
            return physicValueList;
        }

        private IValue _value;

        private void SetIValue(string valueName)
        {
            foreach (var value in _physicValues)
            {
                if (value.GetValueName() == valueName)
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <param name="physicValue">Наименовани физической величены</param>
        /// <returns>список единиц измерения</returns>
        public List<string> GetMeassureList(string physicValue)
        {
            SetIValue(physicValue);
            List<string> list = new List<string>();
            foreach (var str in _value.GetCoefficients())
                list.Add(str.Key);
            return list;
        }

        /// <summary>
        /// Возвращает конвертированное значение
        /// </summary>
        /// <param name="physicValue">Физическая величина</param>
        /// <param name="value">Значение</param>
        /// <param name="from">Из каких ед измерения</param>
        /// <param name="to">в какие ед измерения</param>
        /// <returns>конвертированное значение</returns>
        public double GetConvertedValue(string physicValue, double value, string from, string to)
        {
            SetIValue(physicValue);
            value *= _value.GetCoefficients()[from];
            value /= _value.GetCoefficients()[to];
            return value;
        }
    }
}