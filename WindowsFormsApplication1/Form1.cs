using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listBox1.Items.Add("test");
            //showselectedcustomer();
        }
        private void showselectedcustomer()
        {
            string selectedCustomerText = GetSelectedItem(listBox1);
            MessageBox.Show(selectedCustomerText);
        }

        private string GetSelectedItem(ListBox listBox1)
        {
            string selectedValue = string.Empty;
            if(listBox1.SelectedItem!= null)
            {
                selectedValue = listBox1.SelectedItem.ToString();
            }
            return selectedValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.InvokeRequired)
                {
                    textBox1.Text = " tet";
                }
                else
                {
                    textBox1.Text = "teeee";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
