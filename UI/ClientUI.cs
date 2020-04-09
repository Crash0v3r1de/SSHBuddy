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
using SSHBuddy.IO;
using SSHBuddy.Lists;
using SSHBuddy.Tools;

namespace SSHBuddy.UI
{
    public partial class ClientUI : Form
    {
        private List<ClientDetails> clients = new List<ClientDetails>();
        private bool pingCheckDone = false;
        private bool pingCheckStarted = false;


        public ClientUI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientDetails client = new ClientDetails();
            if (!String.IsNullOrWhiteSpace(txtNickname.Text))
            {
                client = ClientTool.ParseClient(txtHostIPDNS.Text, txtNickname.Text);
            }
            else
            {
                client = ClientTool.ParseClient(txtHostIPDNS.Text, "NONE");
            }
            clients.Add(client);
            lstStored.Items.Clear();
            foreach (var c in clients)
            {
                lstStored.Items.Add(c);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler.SaveClients(clients);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (string) lstStored.SelectedItem;
            for (int i=0;i<clients.Count;i++)
            {
                if (clients[i].IP_DNS == item || clients[i].NickName == item)
                {
                    clients.Remove(clients[i]);
                }
            }
            lstStored.Items.Clear();
            foreach (var c in clients)
            {
                lstStored.Items.Add(c);
            }
        }

        private void exportListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler.SaveReport(clients);
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = lstStored.SelectedItems;
            for (int i = 0; i < clients.Count; i++)
            {
                foreach (var item in items)
                {
                    if (clients[i].IP_DNS == item.ToString() || clients[i].NickName == item.ToString())
                    {
                        clients.Remove(clients[i]);
                    }
                }
            }
            lstStored.Items.Clear();
            foreach (var c in clients)
            {
                lstStored.Items.Add(c);
            }
        }

        private void ClientUI_Load(object sender, EventArgs e)
        {
            clients = FileHandler.ReadClients();
            lstStored.Items.Clear();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].NickName != "NONE")
                {
                    lstStored.Items.Add(clients[i].NickName);
                }
                else
                {
                    lstStored.Items.Add(clients[i].IP_DNS);
                }
            }
        }
    }
}
