using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()  
        {   
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal security = numericUpDown1.Value;
            int i = 0;
            while (i < security)
            {
                textBox1.Text = EncryptDecrypt.Encrypt(textBox1.Text);
                i = i + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal security = numericUpDown1.Value;
            int i = 0;
            while (i < security)
            {
                textBox1.Text = EncryptDecrypt.Decrypt(textBox1.Text);  
                i = i + 1;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0)
            {
                numericUpDown1.Value = 1;
            }
            if (numericUpDown1.Value > 5)
            {
                if(numericUpDown1.Value <= 7)
                {
                    MessageBox.Show("Using a security level above 5 REQUIRES a large amount of memory or errors will occur!");
                }
                
            }
        }
    }
    #region Class
    #region EncryptDecryt
    public class EncryptDecrypt
    {
        public EncryptDecrypt()
        {
        }

        public static string Encrypt(string text_to_Encrypt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = Encoding.ASCII.GetBytes(text_to_Encrypt);
            checked
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    byte value = bytes[i];
                    stringBuilder.Append(Convert.ToString(value, 2).PadLeft(8, '0'));
                    stringBuilder.Append(" ");
                }
                string text = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 1);
                string text_to_convert = text;
                return EncryptDecrypt.converttoline(text_to_convert);
            }
        }

        public static string Decrypt(string Text_to_Decrypt)
        {
            string input = EncryptDecrypt.converttoline(Text_to_Decrypt);
            string text = Regex.Replace(input, "[^01]", "");
            checked
            {
                byte[] array = new byte[(int)Math.Round(unchecked((double)text.Length / 8.0 - 1.0)) + 1];
                int arg_4F_0 = 0;
                int num = array.Length - 1;
                int num2 = arg_4F_0;
                while (true)
                {
                    int arg_77_0 = num2;
                    int num3 = num;
                    if (arg_77_0 > num3)
                    {
                        break;
                    }
                    array[num2] = Convert.ToByte(text.Substring(num2 * 8, 8), 2);
                    num2++;
                }
                return Encoding.ASCII.GetString(array);
            }
        }

        private static string converttoline(string text_to_convert)
        {
            bool flag = text_to_convert.Contains("|");
            string text;
            if (flag)
            {
                text = text_to_convert.Replace(" || ", "0");
                text = text.Replace(" | ", "1");
            }
            else
            {
                text = text_to_convert.Replace("0", " || ");
                text = text.Replace("1", " | ");
            }
            return text;
        }
    }
    #endregion
    #endregion

}

