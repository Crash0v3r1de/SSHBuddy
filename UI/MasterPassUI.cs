using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SSHBuddy.Static;

namespace SSHBuddy.UI
{
    public partial class MasterPassUI : Form
    {
        public MasterPassUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPass.Text) & !String.IsNullOrWhiteSpace(txtUser.Text))
            {
                bool allSet = BulkCred.SetValues(txtUser.Text, txtPass.Text);
                if(allSet) this.Close();
                else
                {
                    MessageBox.Show("Error assigning class credentials.\r\nContact developer for help.");
                }
            }
            else
            {
                MessageBox.Show("Missing required field!");
            }
        }
    }
}
