using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypingPractice
{
    public partial class select : Form
    {
        private bool intended = false;

        public select()
        {
            InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                this.FormClosing += (s, e) =>
                {
                    if (intended)
                    {
                        return;
                    }
                    Main mainForm = Application.OpenForms["Main"] as Main;
                    if (mainForm != null)
                    {
                        mainForm.Show();
                    }
                };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(1);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(2);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(3);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(4);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(5);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(6);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(7);
            typeForm.Show();
            intended = true;
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CPALANHAE2 typeForm = new CPALANHAE2(8);
            typeForm.Show();
            intended = true;
            this.Close();
        }
    }
}
