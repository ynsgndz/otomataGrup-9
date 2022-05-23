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
using sly.parser;
using sly.parser.generator;
using sly.lexer;

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
       
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Dosya Seçiniz..";
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
            Turtle.ShowTurtle = false;

            if (okunanDeger != null)
            {
                string[] lines = System.IO.File.ReadAllLines(okunanDeger);

                label1.Text = "";
            
                Turtle.Delay = 200;
                Turtle.Init(groupBox2);
                Turtle.ShowTurtle = false;
                label3.Text = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    // if (lines[i] != null) { Console.WriteLine(lines[i]); }
                    lines[i].Trim();
                    if (lines[i] == "COLOR S" || lines[i] == "COLOR S ") { Turtle.PenColor = Color.Black; Console.WriteLine("Pencolor : Siyah"); label15.Text += "Kalem Rengi Siyah \n"; }
                    if (lines[i] == "COLOR K" || lines[i] == "COLOR K ") { Turtle.PenColor = Color.Red; Console.WriteLine("Pencolor : Kırmızı"); label15.Text += "Kalem Rengi Kırmızı \n"; }
                    if (lines[i] == "COLOR Y" || lines[i] == "COLOR Y ") { Turtle.PenColor = Color.Green; Console.WriteLine("Pencolor : Yeşil"); label15.Text += "Kalem Rengi Yeşil \n"; }
                    if (lines[i] == "COLOR M" || lines[i] == "COLOR M ") { Turtle.PenColor = Color.Blue; Console.WriteLine("Pencolor : Mavi"); label15.Text += "Kalem Rengi Mavi \n"; }
                
                    for (int k = 0; k < 10; k++) { if (lines[i] == "PEN " + k) { Turtle.PenSize = k; Console.WriteLine("PenSize : " + k); label15.Text += " Kalem Kalınlığı " + k+ "\n"; }  }

                    for (int k = 0; k < 10000; k++) { if (lines[i] == "F " + k) { Turtle.Forward(k); Console.WriteLine("Forward : " + k); label15.Text += k + "\t Adım ileri \n"; } }

                    for (int k = 0; k < 10000; k++) { if (lines[i] == "R " + k) { Turtle.Rotate(k); Console.WriteLine("Rotate : " + k); label15.Text += k + "\t Derece sağa dön \n"; } }

                    for (int k = 0; k < 10000; k++) { if (lines[i] == "L " + k) {  Console.WriteLine("loop : " + k); label15.Text += k + " kere yap \n"; }
                    }

                    if (lines[i] == "Hata") {
                        Console.WriteLine("[");
                        label3.Text += "Tanımlanmayan Syntax";
                        label15.Text += "Tanımlanmayan Syntax \n";

                        if (comboBox1.Text == "Hata verince dursun") {   break;}
                    }
                    if (lines[i] == "[") { Console.WriteLine("["); label15.Text += "( \n"; }
                    if (lines[i] == "]") { Console.WriteLine("]"); label15.Text += " )\n"; }
                    label1.Text += lines[i]+" ";
                }
               
                


            }
           
        }

  
       
      
        private void button4_Click(object sender, EventArgs e)
        {
            Turtle.Dispose();
            label15.Text = "";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
           
        }
    }
}
