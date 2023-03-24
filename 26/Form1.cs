using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace _26
{
    public partial class Form1 : Form
    {
        public string path;

        public Form1()
        {
            InitializeComponent();
            path = Path.GetFullPath(".");
            path = Path.GetDirectoryName(path);
            Directory.CreateDirectory(path+"\\liste");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(path + "\\text.txt",true);
            sw.WriteLine("Prodotto: "+textBox1.Text+" "+"Prezzo: "+ textBox2.Text);
            sw.Close();
            Lista();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Elimina();




        }

        private void Lista()
        {
            listView1.Items.Clear();
            string[] lines = File.ReadAllLines(path + @"\text.txt");
            for(int i = 0; i < lines.Length; i++)
            {
                listView1.Items.Add(lines[i]);
            }
        }

        public void Elimina()
        {
            
            string line;
            

            if (File.Exists("text.txt"))
            {
                StreamWriter sw = new StreamWriter(path + @"\eliminazione.txt");
                StreamReader sr = new StreamReader(path + @"\text.txt");
                //leggo la prima riga
                line = sr.ReadLine();
                //controllo se i dati esistono
                while (line != null)
                {
                    //elabora i dati
                    line.Remove(line.Length - 1, 1);
                    line.Append('0');
                    /*
                    if (nome.Text != div[1])
                    {
                        sw.WriteLine(line);
                    }*/
                    //legge la linea successiva
                    line = sr.ReadLine();
                }
                sw.Close();
                sr.Close();
            }

            /*if (File.Exists("appoggio.csv"))
            {
                File.Replace("appoggio.csv", "prodotti.csv", "backup.csv");
            }*/
        }

    }
}
