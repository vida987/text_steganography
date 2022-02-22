using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public string ToReadableByteArray(byte[] bytes)
        {
            return string.Join(", ", bytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox2.Text;
            byte[] bytes = Encoding.ASCII.GetBytes(a);
            char[] c = a.ToCharArray();
            textBox3.Text = encode2(c)+ textBox1.Text;
           //textBox3.Text = decode2(textBox2.Text).ToString();
        }

        public string encode2( char[] c)
        {
            string result = "";
            for(int i=0; i < c.Length; i++)
            {
                result += encode(c[i]);
            }
            return result;
        }
        public string encode(int b)
        {
            string result="";
            int d= b;
            for(int i = 0; i < 8; i++)
            {
                if (d % 2 == 1) result += "\u200B";
                else result += "\u200C";
                d = d / 2;
            }
            return result; 
        }

        public string decode2(string x)
        {
            string result = "";
            int l = x.Length / 8;
            for(int i=0; i < l; i++)
            {   string tmp = "";
                for(int j = 0; j < 8; j++)
                {
                    tmp += x[i * 8 + j];
                }
                result += decode(tmp);
            }
            return result;
        }

        public string decode(string x)
        {
            string tmp = x;
            double z = 0;
            int j = -1;
            for(int i=0; i<8; i++)
            {   if (tmp[i] == '\u200B') j = 1;
                else j = 0;
               
                z = z+j* Math.Pow(2, i);
            }
            int z2 = Convert.ToInt32(z);
            char result = Convert.ToChar(z2);
            string result2 = Convert.ToString(result);
            return result2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox4.Text;
            string c = "";
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] == '\u200B' || a[i] == '\u200C') c += a[i];
            }
            textBox5.Text = decode2(c).ToString();
        }
    }
}
