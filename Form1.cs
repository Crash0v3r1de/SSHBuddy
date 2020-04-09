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
using SSHBuddy.UI;

namespace SSHBuddy
{
    public partial class Form1 : Form
    {
        private Random rng = new Random();
        private SshClient sshClient = null;
        private string host = "";
        private string user = "";
        private string pass = "";
        private bool connected = false;
        private bool reset = false;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                UpdateStatus("Connecting...");
                host = txtHost.Text;
                user = txtUser.Text;
                pass = txtPassword.Text;
                txtPassword.Text = rng.Next(54646).ToString();

                sshClient = new SshClient(host, user, pass);
                sshClient.Connect();
                UpdateStatus("Connected!");
                pass = null; // Clear out memory of password ?
                connected = true;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            
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

        private void pingDNSIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                using (PingTargetUI pUI = new PingTargetUI())
                {
                    pUI.ShowDialog();
                    if (!String.IsNullOrWhiteSpace(pUI.target))
                    {
                        UpdateStatus("Sending Commands...");
                        SshCommand sc = sshClient.CreateCommand($"ping {pUI.target} -c 5");
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
                    else
                    {
                        UpdateStatus("Input Missing!");
                    }
                }
            }
            else
            {
                MessageBox.Show("SSH client is NOT connected!");
            }
        }

        private void spanningTreeRapidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatus("Sending Commands...");
                SshCommand sc = sshClient.CreateCommand("en");
                sc.Execute();
                sc = sshClient.CreateCommand("conf t");
                sc.Execute();
                sc = sshClient.CreateCommand("spanning-tree mode rapid-pvst");
                sc.Execute();
                UpdateStatus("Command Completed!");
            }
            catch(Exception ex)
            {
                UpdateStatus("Command Failed!");
                txtConsole.Text = "";
                txtConsole.Text = "ERROR: "+ex.Message;
            }
        }

        private void iPRoutingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatus("Sending Commands...");
                SshCommand sc = sshClient.CreateCommand("en");
                sc.Execute();
                sc = sshClient.CreateCommand("conf t");
                sc.Execute();
                sc = sshClient.CreateCommand("ip routing");
                sc.Execute();
                UpdateStatus("Command Completed!");
            }
            catch (Exception ex)
            {
                UpdateStatus("Command Failed!");
                txtConsole.Text = "";
                txtConsole.Text = "ERROR: " + ex.Message;
            }
        }
    }
}
