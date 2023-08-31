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
using Elaborazione_CSV;

namespace Mariani_ElaborazioneCSV
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private int Ricerca(string parola)
        {
            StreamReader reader = new StreamReader("mariani1.csv");
            string s;
            int i = 0;
            s = reader.ReadLine();
            while (s != null)
            {

                String[] split = s.Split(';');
                String[] split1 = split[Lunghezza() - 1].Split(' ');

                if (split1[0] == parola)
                {
                    reader.Close();
                    return i;
                }

                i++;
                s = reader.ReadLine();

            }
            reader.Close();
            return -1;
        }

        private int Lunghezza()
        {
            string s;
            int count = 0;
            StreamReader reader = new StreamReader("mariani1.csv");
            s = reader.ReadLine();
            reader.Close();
            return count = s.Split(';').Length;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string logicoString;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                // Message Box with title and icon
                MessageBox.Show("Assicurati che tutti i campi siano riempiti", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            bool isAnnoValid = int.TryParse(textBox1.Text, out int anno);
            bool isTfemmValid = float.TryParse(textBox3.Text, out float t_femm);
            bool isTmascValid = float.TryParse(textBox4.Text, out float t_masc);
            bool isTbothValid = float.TryParse(textBox5.Text, out float t_both);
            bool isValRandValid = int.TryParse(textBox6.Text, out int val_rand);
            bool isLogicoValid = bool.TryParse(textBox7.Text, out bool logico);
            bool isRigavalid = int.TryParse(textBox8.Text, out int riga);

            if (isAnnoValid && isTfemmValid && isTmascValid && isTbothValid && isValRandValid && isLogicoValid)
            {
                if (logico == false)
                    logicoString = "false";
                else
                    logicoString = "true";

                string regione = textBox2.Text;
                int rigaAsd = Ricerca(riga.ToString());
                ElaborazioneCSV.Azione8(anno, regione, t_femm, t_masc, t_both, val_rand, logicoString, riga);
                // Message Box with title and icon
                MessageBox.Show("Azione eseguita correttamente", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Assicurati che tutti i dati in input siano nel formato corretto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
