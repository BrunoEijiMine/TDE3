using System;
using System.IO; 
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
        static String path = "C:/git/Banco De Dados";
        static String file = path + "/Banco.txt";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            mtbTell.Text = "";
            mtbCpf.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int Banco = 0;

            if(txtEmail.Text == "")
            {
                //Validação Convêncional
                //MessageBox.Show("Email Obrigatório");
                errorProvider.SetError(txtEmail, "Mandatory Email");

                Banco = 1;
            }
            else
            {
                errorProvider.SetError(txtEmail, "");

                Banco = 0;
            }
            if(txtName.Text == "")
            {
                errorProvider.SetError(txtName, "Name Required");

                Banco = 1;
            }
            else
            {
                errorProvider.SetError(txtName, "");

                Banco = 0;

            }
            if (txtPassword.Text == "")
            {
                errorProvider.SetError(txtPassword, "Password Required");

                Banco = 1;
            } 
           else
            {
             errorProvider.SetError(txtPassword, "");

                Banco = 0;

            }

            if(Banco == 1)
            {
                MessageBox.Show("Please fill in the required fields !");
            }

            else
            {
                bool checkDirExist = Directory.Exists(path);
                if (!checkDirExist)
                {
                    Directory.CreateDirectory(path);
                }

                bool checkFileExist = File.Exists(file);

                String line = txtEmail.Text + "|" + txtName.Text + "|" + mtbCpf.Text + "|" + txtPassword.Text + "|" + mtbTell.Text + "|";

                if (!checkFileExist)
                {
                    using (StreamWriter sw = File.CreateText(file))
                    {
                        sw.WriteLine(line);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(line);
                    }
                }
            }

            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
    }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(file))
            {
                dgvBanco.Rows.Clear();
                using (StreamReader sr = new StreamReader(file))
                {
                    int line = 0;
                    string In;

                    while ((In = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(In);

                        //MessageBox.Show(In);
                        string[] fields = In.Split('|');

                        dgvBanco.Rows.Add(fields[0], fields[1], fields[2], fields[3]);

                        line++;
                    }
                    sr.Close();

                }
            }
            /*
            else
            {
                MessageBox.Show("Nenhum Arquivo encontrado");
            }
            */
        }
    }
}
