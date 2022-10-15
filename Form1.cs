using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        int e = 0;
        bool d=true;
        bool next = false;
        bool back = false;
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            label1.Text = e + "%";
        }

        void Bar()
        {
            
            int b = 0;
            if (checkBoxSlowly.Checked)
            {
                b = 200;
            }
            else if(checkBoxMidle.Checked)
            {
                b = 100;
            }
            else if(checkBoxFast.Checked)
            {
                b = 10;
            }
            if(b != 0)
            {
                if (d)
                {
                    while (progressBar1.Value != 100)
                    {
                        if (!next)
                        {
                            break;
                        }
                        progressBar1.Value++;
                        e++;
                        label1.Text = e + "%";
                        Thread.Sleep(b);
                    }
                }
                else
                {
                    while (progressBar1.Value != 0)
                    {
                        if (!back)
                        {
                            break;
                        }
                        progressBar1.Value--;
                        e--;
                        label1.Text = e + "%";
                        Thread.Sleep(b);
                    }
                }
                
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Bar);
            d = true;
            next = true;
            back = false;
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Bar);
            d = false;
            next = false;
            back = true;

            th.Start();
        }
    }
}
