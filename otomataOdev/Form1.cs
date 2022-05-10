using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Nakov.TurtleGraphics;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otomataOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();
            //file.Filter = "Excel Dosyası |*.txt| Txt Dosyası|*.txt";  
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Excel Dosyası Seçiniz..";
            file.ShowDialog();

            string DosyaYolu = file.FileName;
            // seçilen dosyanın tüm yolunu verir
            string DosyaAdi = file.SafeFileName;
            // seçilen dosyanın adını verir.

            label1.Text = DosyaAdi;
            label2.Text = DosyaYolu;
            okunanDeger = DosyaYolu;

        }
        string okunanDeger;

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(okunanDeger);

            // Display the file contents by using a foreach loop.
            label3.Text = "";
            foreach (string line in lines)
            {
                label3.Text += line;
            }
            

        }

      
    }
}
