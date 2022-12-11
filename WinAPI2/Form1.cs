using ConverterLib;
using System;

namespace WinAPI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Converter converter = new Converter();
        
        /// <summary>
        /// Метод заполняет первый листбокс физическими величинами и на основе по умолчанию выбранной
        /// величины заполняте листбоксы конвертации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(converter.GetPhysicValuesList().ToArray());
            listBox1.SelectedIndex = 0;

            string str = listBox1.SelectedItem.ToString();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox2.Items.AddRange(converter.GetMeassureList(str).ToArray());
            listBox3.Items.AddRange(converter.GetMeassureList(str).ToArray());
        }

        /// <summary>
        /// Метод заполняет листбоксы конвертации соответствующими параметрами при изменении физической величины в первом листбоксе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox2.Items.AddRange(converter.GetMeassureList(str).ToArray());
            listBox3.Items.AddRange(converter.GetMeassureList(str).ToArray());
        }

      
        /// <summary>
        /// Метод конвертации на основе выбранных элементов в листбоксах и введенного значения в строке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string physicValue = listBox1.SelectedItem.ToString();
                double value = Convert.ToDouble(textBox1.Text);
                string from = listBox2.SelectedItem.ToString();
                string to = listBox3.SelectedItem.ToString();
                textBox2.Text = (converter.GetConvertedValue(physicValue, value, from, to)).ToString();
            }
            catch (Exception ex)
            {
                textBox2.Text = "Введите число";
            }
        }
    }
}