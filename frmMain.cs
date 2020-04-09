using System;
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
using Renci.SshNet;
using SSHBuddy.Enums;
using SSHBuddy.Tools;
using SSHBuddy.UI;

namespace SSHBuddy
{
    public partial class frmMain : Form
    {
        private Random rng = new Random();
        private SshClient sshClient = null;
        private string host = "";
        private string user = "";
        private string pass = "";
        private bool connected = false;
        private bool reset = false;
        private bool disconnect = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                ProcessQuickConnect();
            }
            else
            {
                var result =
                    MessageBox.Show(
                        "An active instance is present.\r\nDo you want to connect to another host instead?",
                        "Active Connection", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ProcessQuickConnect();
                }
            }
        }

        private void ProcessQuickConnect()
        {
            ConnectionUpdate(ConnectStatus.Connecting);
            host = txtHost.Text;
            user = txtUser.Text;
            pass = txtPassword.Text;
            txtPassword.Text = rng.Next(54646).ToString();

            sshClient = new SshClient(host, user, pass);
            sshClient.Connect();
            pass = null; // Clear out memory of password ?
            connected = true;
            ConnectionUpdate(ConnectStatus.Connected);
            // Simple connection checker
            new Thread(() => { ConnectionWatch(); }).Start();
        }

        private void ConnectionWatch()
        {
            while (sshClient.IsConnected)
            {
                if (!sshClient.IsConnected) ConnectionUpdate(ConnectStatus.Disconnected);
                if (disconnect)
                {
                    ConnectionUpdate(ConnectStatus.Disconnected);
                    sshClient.Disconnect();
                    break;
                }
                Thread.Sleep(rng.Next(2150));
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

        private void ConnectionUpdate(ConnectStatus conStat)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<ConnectStatus>(ConnectionUpdate), conStat);
                return;
            }

            switch (conStat)
            {
                case ConnectStatus.Disconnected:
                    lblConnectStatus.Text = "SSH: DISCONNECTED!";
                    lblConnectStatus.ForeColor = Color.Black;
                    lblConnectStatus.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                    break;
                case ConnectStatus.Connected:
                    lblConnectStatus.Text = "SSH: Connected!";
                    lblConnectStatus.ForeColor = Color.Green;
                    lblConnectStatus.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                    break;
                case ConnectStatus.Error:
                    lblConnectStatus.Text = "SSH: ERROR DURING SESSION!";
                    lblConnectStatus.ForeColor = Color.Red;
                    lblConnectStatus.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    break;
                case ConnectStatus.Connecting:
                    lblConnectStatus.Text = "SSH: Connecting...";
                    lblConnectStatus.ForeColor = Color.Black;
                    lblConnectStatus.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                    break;
            }
        }

        private void pingDNSIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnect = true;
            UpdateStatus("Client disconnecting...");
        }

        private void bulkProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ClientUI cUI = new ClientUI())
            {
                cUI.ShowDialog();
            }
        }

        private void assignMasterCredentialsperSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MasterPassUI passUI = new MasterPassUI())
            {
                passUI.ShowDialog();
            }
        }

        private void linuxToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                using (PingTargetUI pUI = new PingTargetUI())
                {
                    pUI.ShowDialog();
                    if (!String.IsNullOrWhiteSpace(pUI.target))
                    {
                        UpdateStatus("Sending Commands...");
                        SshCommand sc = sshClient.CreateCommand($"ping {pUI.target}");
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

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CustomScriptUI script = new CustomScriptUI())
            {
                script.ShowDialog();
                if (!String.IsNullOrWhiteSpace(script.CompleteScript))
                {
                    UpdateStatus("Running custom script...");
                    var output = ClientTool.SendCommand(script.CompleteScript,sshClient);
                    StringBuilder sb = new StringBuilder();
                    foreach (var line in output)
                    {
                        sb.Append(line);
                    }

                    txtConsole.Text = sb.ToString();
                    UpdateStatus("Script return completed!");
                }
            }
        }
    }
}
