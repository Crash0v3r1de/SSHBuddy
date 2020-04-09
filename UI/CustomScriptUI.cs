using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHBuddy.UI
{
    public partial class CustomScriptUI : Form
    {
        public string CompleteScript = "";
        public CustomScriptUI()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtScript.Text))
            {
                CompleteScript = txtScript.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Nothing is in the script/command box.\r\nPlease input some sort of command to attempt.");
            }
        }
    }
}
