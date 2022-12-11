using ConverterLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAPI
{
    public class Commands
    {
        public void Dialog()
        {
            bool running = true;
            while (running)
            {
                string commandString = Console.ReadLine();
                CommandParse(commandString);
                try
                {
                    switch (_command)
                    {
                        case "Clear":
                            Clear();
                            break;
                        case "Exit":
                            running = false;
                            break;
                        case "Help":
                            Help();
                            break;

                        case "Info":
                            Info();
                            break;
                        default:
                            Console.WriteLine(_converter.GetConvertedValue(_command, Convert.ToDouble(args[0]), args[1], args[2]));
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный ввод!");
                }
            }
        }

        string _command = "";
        string[] args = new string[3];
        Converter _converter = new Converter();

        /// <summary>
        /// Возвращает информацию о доступных списках 
        /// физических величин и о доступных методах конвертации
        /// </summary>
        void Info()
        {
            foreach (string value in _converter.GetPhysicValuesList())
            {
                Console.WriteLine(value + ":");
                foreach (string meassure in _converter.GetMeassureList(value))
                {
                    Console.WriteLine("\t" + meassure);
                }
            }
        }

        /// <summary>
        /// отчистка экрана
        /// </summary>
        void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Возвращает список команд
        /// </summary>
        void Help()
        {
            Console.WriteLine("Info - информация о доступных для перевода физических величинах");
            Console.WriteLine("Clear - отчистить экран");
            Console.WriteLine("Exit - выход из программы");

        }

        /// <summary>
        /// Разбивает строку на слова (команды)
        /// </summary>
        /// <param name="commandString"></param>
        void CommandParse(string commandString)
        {
            string command = "";
            string[] str = commandString.Split(' ');

            if (str.Length > 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    str[i].Replace(",", "");
                }
            }
            _command = str[0];
            if (str.Length > 1)
            {
                args[0] = str[1];
                args[1] = str[2];
                args[2] = str[3];
            }
        }

        List<string> _commands = new List<string>()
        {
            "Info",
            "Clear",
            "Exit",
            "Help",
        };
    }
}