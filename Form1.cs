using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Утилита_создания_файлов
{
    public partial class Form1 : Form
    {
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        OpenFileDialog open = new OpenFileDialog();
        Random rand = new Random();
        public string messege;

        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            open.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void DevolopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Собственность Паши Razor_Z_Pi",
                            "Developer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.Create(filename).Close();
            MessageBox.Show("Файл сохранен");
            label1.Text = filename;
            messege = filename;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int n = Int32.Parse(comboBox1.Text);
            for (int i = 0; i < n; i++)
            {
                textBox1.Text += rand.Next(1, 10).ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Push();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (open.ShowDialog() == DialogResult.Cancel)
                return;
            messege = open.FileName;
            label1.Text = open.FileName;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                string S_T = label1.Text;
                System.IO.File.Create(messege).Close();
                MessageBox.Show($"Файл {S_T} полностью очищен!!!",
                                "Внимание",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Файл не выбран, пожалуйста выберите его",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Hand);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void Push()
        {
            int number = 100;

            if (messege != "")
            {
                if (textBox1.Text != "")
                {
                    for (int i = 0; i < number; i++)
                    {
                        progressBar1.Value++;
                    }
                }
                try
                {
                    // сохраняем текст в файл
                    System.IO.File.AppendAllText(messege, textBox1.Text + "\n");
                    MessageBox.Show("Запись выполнена!!!",
                                    "Ура",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                    progressBar1.Value = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Поле не должно быть пустым!!!",
                                    "Внимание",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Push();
            }
        }
    }
}
