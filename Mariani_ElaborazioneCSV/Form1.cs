using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mariani_ElaborazioneCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Azione1();
        }

        public string fileName1 = @"mariani1.csv";
        public string fileName2 = @"mariani.csv";
        public Random r = new Random();

        private void Azione1() 
        {
            string s;
            int i = 0;
            StreamWriter writer = new StreamWriter(fileName1, append: false);
            
            
            if (File.Exists(fileName2))
            {
                StreamReader reader = new StreamReader(fileName2);
                s = reader.ReadLine();
                while (s != null)
                {
                    if (i == 0)
                    {
                        writer.WriteLine(s + ";Valore Randomico;Campo Cancellazione Logica;Campo Univoco" );
                    }
                    else
                    {
                        int valore = r.Next(10, 21);
                        writer.WriteLine(s + ";" + valore + ";false;" + i);
                    }
                    i++;
                    s = reader.ReadLine();
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Caricare il file csv in bin/debug");
            }
            writer.Close();
            
        }

        private int Azione2() 
        {
            string s;
            int count;
            StreamReader reader = new StreamReader(fileName1);
            s = reader.ReadLine();
            reader.Close();
            return count = s.Split(';').Length;
            
        }

        private int Azione3()
        {
            StreamReader reader = new StreamReader(fileName1);
            int lunghezzaStringa = 0, lunghezzaMax = 0, i = 0;
            string s;

            s = reader.ReadLine();
            while (s != null)
            {
                lunghezzaStringa = s.Length;
                if (i != 0)
                {
                    if (lunghezzaMax < lunghezzaStringa)
                    {
                        lunghezzaMax = s.Length;
                    }
                }
                s = reader.ReadLine();
                i++;
            }
            reader.Close();
            return lunghezzaMax;
        }

        private int[] Azione3Avanzato()
        {
            StreamReader reader = new StreamReader(fileName1);
            string s = reader.ReadLine();
            int[] lunghezzaMax = new int[Azione2()];
            int asd = 0;
            s = reader.ReadLine();

            while (s != null)
            {
                string[] split = s.Split(';');
                string[] array = new string[Azione2()];
                
                for (int i = 0; i < Azione2(); i++)
                {
                    reader.DiscardBufferedData();
                    reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                    s = reader.ReadLine();
                    asd = 0;
                    while (s != null)
                    {
                        string[] stringaSplit = s.Split(';');
                        if (asd != 0)
                        {
                            if (lunghezzaMax[i] < stringaSplit[i].Length)
                            {
                                lunghezzaMax[i] = stringaSplit[i].Length;
                            }

                        }
                        s = reader.ReadLine();
                        asd++;
                    }
                }
            }
            reader.Close();
            return lunghezzaMax;
        }

        private void Azione4()
        {
            string s;
            int i = 0;
            StreamReader reader = new StreamReader(fileName1);
            StreamWriter writer = new StreamWriter("temporaneo.csv");

            s = reader.ReadLine();
            while (s != null)
            {
                if (i != 0)
                {
                    writer.WriteLine(s.PadRight(70));
                }
                else
                {
                    writer.WriteLine(s);
                }

                s = reader.ReadLine();
                i++;
            }

            

            reader.Close();
            writer.Close();

            File.Replace("temporaneo.csv", fileName1, "backup.csv");
        }
        
        private void Azione6()
        {
            string s;
            int i = 0;
            StreamReader reader = new StreamReader("mariani1.csv");

            s = reader.ReadLine();

            while (s != null)
            {
                String[] split = s.Split(';');
                if (split[6] == "false")
                {
                    listView2.Items.Add($"{split[0]};{split[1]};{split[4]}");
                }
     
                i++;
                s = reader.ReadLine();
            }

            reader.Close();
        }

        private int Azione7(string parola)
        {
            StreamReader reader = new StreamReader(fileName1);
            string s;
            int i = 0;
            s = reader.ReadLine();
            while (s != null)
            {

                String[] split = s.Split(';');
                String[] split1 = split[Azione2()-1].Split(' ');

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

        private int Azione9(string ricerca)
        {
            int riga = Azione7(ricerca);
            int i = 0;
            int successo = 0;
            StreamReader reader = new StreamReader(fileName1);
            StreamWriter writer = new StreamWriter("temporaneo.csv");


            string s = reader.ReadLine();
            while (s != null)
            {
                String[] split = s.Split(';');
                String[] split1= split[7].Split(' ');


                if (split1[0] == riga.ToString())
                {
                    

                    writer.WriteLine($"{split[0]};{split[1]};{split[2]};{split[3]};{split[4]};{split[5]};true;{split[7]}");
                    successo = 1;
                    break;
                }
                else
                {
                    writer.WriteLine(s);
                    successo = -1;
                }
                
                i++;
                s = reader.ReadLine();
            }


            writer.Close();
            reader.Close();

            File.Replace("temporaneo.csv", fileName1, "backup.csv");

            return successo;
        }

        private void azione1_Click(object sender, EventArgs e)
        {
            Azione1();
            MessageBox.Show("Azione eseguita correttamente", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void azione2_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Information;
            MessageBox.Show("In un Record ci sono " + Azione2() + " Campi", "Azione 2", MessageBoxButtons.OK, icon);
        }

        private void azione3_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            listView1.Clear();
            int[] ints = new int[Azione2()];
            int temp;
            ints = Azione3Avanzato();

            StreamWriter writer = new StreamWriter("temp.txt", append: false);
            writer.WriteLine("In un Record ci sono massimo " + Azione3() + " caratteri\n");
            for (int i = 0; i < Azione2(); i++)
            {
                temp = i + 1;
                writer.WriteLine("Nel " + temp + " campo ci sono massimo " + ints[i] + " caratteri");
            }
            writer.Close();
            StreamReader reader = new StreamReader("temp.txt");
            string s = "";
            while ((s = reader.ReadLine()) != null)
            {
                listView1.Items.Add(s);
            }
            reader.Close();
            
        }

        private void azione4_Click(object sender, EventArgs e)
        {
            Azione4();
            MessageBox.Show("Azione eseguita correttamente", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void azione5_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void azione6_Click(object sender, EventArgs e)
        {
            Azione6();
            groupBox2.Show();
        }

        private void azione_7_Click(object sender, EventArgs e)
        {
            groupBox3.Show();

        }

        private void azione7_invia_Click(object sender, EventArgs e)
        {
            int linea = Azione7(textBox1.Text);
            groupBox3.Hide();
            if (linea != -1)
            {
                MessageBox.Show("La tua ricerca è stata individuata nella riga " + linea, "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La tua ricerca non ha avuto risultati", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void azione8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void azione9_Click(object sender, EventArgs e)
        {
            groupBox4.Show(); 
        }

        private void azioneInvia9_Click(object sender, EventArgs e)
        {
            int successo = Azione9(textBox2.Text);
            groupBox4.Hide();
            if (successo == 1)
            {
                MessageBox.Show("La tua ricerca è stata individuata e cancellata", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (successo == -1)
            {
                MessageBox.Show("La tua ricerca non ha avuto risultati", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Errore", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void closeGroupBox1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            groupBox1.Hide();
        }

        private void closeGroupBox2_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            groupBox2.Hide();
        }

        private void aiuto1_Click(object sender, EventArgs e)
        {
            MessageBoxIcon icon = MessageBoxIcon.Question;
            MessageBox.Show("Start: Aggiungere, in coda ad ogni record, un campo chiamato \"miovalore\", contenente un numero casuale compreso tra 10<=X<=20 ed un campo per marcare la cancellazione logica;\n\nConta Campi: contare il numero dei campi che compongono il record;\n\nMax Length: calcolare la lunghezza massima dei record presenti indicando anche la lunghezza massima di ogni campo;\n\nDim Fissa: inserire in ogni record un numero di spazi necessari a rendere fissa la dimensione di tutti i record, senza perdere informazioni;\n\nAggiunta: Aggiungere un record in coda;\n\nVisualizza: Visualizzare dei dati mostrando tre campi significativi;\n\nRicerca: Ricercare un record per campo chiave a scelta;\n\nModifica: Modificare  un record;\n\nCancella: Cancellare logicamente un record;", "Aiuto", MessageBoxButtons.OK, icon);
        }

        private void aggiuntaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione5_Click(sender, e);
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione8_Click(sender, e);
        }

        private void cancellazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione9_Click(sender, e);
        }

        private void mioValoreECampoCancellazioneLogicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione1_Click(sender, e);
        }

        private void dimensioneFissaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione4_Click(sender, e);
        }

        private void conteggioCampiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione2_Click(sender, e);
        }

        private void lunghezzaMassimaRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione3_Click(sender, e);
        }

        private void ricercaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            azione7_invia_Click(sender, e);
        }
    }
}