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
    public partial class Form2 : Form
    {
        Random random = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string logicoString;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show("Assicurati che tutti i campi siano riempiti", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool isAnnoValid = int.TryParse(textBox1.Text, out int anno);
                bool isTfemmValid = float.TryParse(textBox3.Text, out float t_femm);
                bool isTmascValid = float.TryParse(textBox4.Text, out float t_masc);
                bool isTbothValid = float.TryParse(textBox5.Text, out float t_both);
                bool isValRandValid = int.TryParse(textBox6.Text, out int val_rand);
                bool isLogicoValid = bool.TryParse(textBox7.Text, out bool logico);

                if (isAnnoValid && isTfemmValid && isTmascValid && isTbothValid && isValRandValid && isLogicoValid)
                {
                    if (logico == false)
                        logicoString = "false";
                    else
                        logicoString = "true";

                    string regione = textBox2.Text;
                    ElaborazioneCSV.Azione5(anno.ToString(), regione, t_femm, t_masc, t_both, val_rand, logicoString);
                    MessageBox.Show("Azione eseguita correttamente", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Assicurati che tutti i dati in input siano nel formato corretto", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}