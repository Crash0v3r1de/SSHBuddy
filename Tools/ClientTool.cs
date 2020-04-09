using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using SSHBuddy.Lists;

namespace SSHBuddy.Tools
{
    public static class ClientTool
    {
        public static ClientDetails ParseClient(string ip,string nickName)
        {
            ClientDetails client = new ClientDetails();
            client.IP_DNS = ip;
            if (!String.IsNullOrWhiteSpace(nickName))
            {
                client.NickName = nickName;
            }
            else
            {
                client.NickName = "NONE";
            }

            return client;
        }

        public static bool ClientAlive(ClientDetails client)
        {
            // TODO: Maybe add error check for bad IP
            try
            {
                if (new Ping().Send(client.IP_DNS).Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<string> SendCommand(string command, SshClient client)
        {
            var newLines = command.Split('\n');
            List<string> allOutputs = new List<string>();
            SshCommand sc = null;
            TimeSpan span = TimeSpan.FromMinutes(5);
            sc.CommandTimeout = span;
            foreach (var com in newLines)
            {
                sc = client.CreateCommand(com);
            }
            sc.Execute();
            allOutputs.Add(sc.Result);
            if (!String.IsNullOrWhiteSpace(allOutputs.ToString()))
            {
                Debug.WriteLine("Command executed successfully!");
                return allOutputs;
            }
            else
            {
                return null;
            }
        }
    }
}
