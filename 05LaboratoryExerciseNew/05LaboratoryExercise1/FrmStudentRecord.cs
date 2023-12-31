﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _05LaboratoryExercise1
{
    
    public partial class FrmStudentRecord : Form
    {
        frmRegistration Register = new frmRegistration();
        public FrmStudentRecord()
        {
            InitializeComponent();
           
        }
        private void btnRegister_Click(object sender, EventArgs e) {

            this.Hide();
            frmRegistration frmRegistration = new frmRegistration();
            frmRegistration.ShowDialog();
            

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
         MessageBox.Show("Successfully Uploaded!", "Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
         lvList.Items.Clear();


        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            DisplayListView();
        }
            void DisplayListView()
            {
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
                openFileDialog1.DefaultExt = "txt";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.ShowDialog();
                string path = openFileDialog1.FileName;
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string _getText = "";
                    while ((_getText = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(_getText);
                        lvList.Items.Add(_getText);
                    }
                }

            }

        private void FrmStudentRecord_Load(object sender, EventArgs e)
        {

        }
    }
    }



