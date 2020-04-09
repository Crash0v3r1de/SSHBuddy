using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace SSHBuddy
{
    public partial class Form1 : Form
    {
        private Random rng = new Random();
        private SshClient sshClient = null;
        private string host = "";
        private string user = "";
        private string pass = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UpdateStatus("Connecting...");
            host = txtHost.Text;
            user = txtUser.Text;
            pass = txtPassword.Text;
            txtPassword.Text = rng.Next(54646).ToString();


            sshClient = new SshClient(host, user, pass);
            sshClient.Connect();
            UpdateStatus("Connected!");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            UpdateStatus("Sending Commands...");
            SshCommand sc = sshClient.CreateCommand("ping google.com -c 5");
            sc.Execute();
            string answer = sc.Result;
            if (!String.IsNullOrWhiteSpace(answer))
            {
                UpdateStatus("Command Completed!");
                txtConsole.Text = "";
                txtConsole.Text = answer;
            }
            else
            {
                UpdateStatus("Command Failed!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateStatus), status);
                return;
            }

            lblStatus.Text = "Status: "+status;
        }
    }
}
