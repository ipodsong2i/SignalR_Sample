using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox3.Text != "")
            {
                Form1 fdr = (Form1)Owner;
                fdr.ip = textBox1.Text;
                fdr.name = textBox3.Text;


                this.Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("전부 입력해주세요.");
            }

            
        }
    }
}
