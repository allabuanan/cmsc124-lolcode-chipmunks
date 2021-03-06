﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLCode_Interpret
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            EventHandler handler = (s, e) => {  //Event Handler for synchronizing scroll on both list boxes
                if (s == lexemeListBox)
                    classificationListBox.TopIndex = lexemeListBox.TopIndex;
                if (s == classificationListBox)
                    lexemeListBox.TopIndex = classificationListBox.TopIndex;
            };

            this.lexemeListBox.MouseCaptureChanged += handler;
            this.classificationListBox.MouseCaptureChanged += handler;
            this.lexemeListBox.SelectedIndexChanged += handler;
            this.classificationListBox.SelectedIndexChanged += handler;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lexer.readPerLine(Lexer.filePath);
            lexemeListBox.DataSource = Lexer.keyMatch;
            classificationListBox.DataSource = Lexer.classification;
            codeListBox.DataSource = Lexer.code;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            {
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "LOL Files (*.lol)|*.lol";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Lexer.filePath = openFileDialog1.FileName.ToString();
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                    }
                }
            }
        }
    }
}
