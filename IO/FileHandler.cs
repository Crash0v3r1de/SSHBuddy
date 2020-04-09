using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Newtonsoft.Json;
using SSHBuddy.Lists;

namespace SSHBuddy.IO
{
    public static class FileHandler
    {
        private static string LogPath = @"Logs\";
        private static string LogFolderName = "Logs";
        private static string ConfigPath = @"Config\";
        private static string ConfigFolderName = "Config";

        private static void CheckDirs()
        {
            if (!Directory.Exists(LogFolderName))
            {
                try { Directory.CreateDirectory(LogFolderName); } catch { }
            }
            if (!Directory.Exists(ConfigFolderName))
            {
                try { Directory.CreateDirectory(ConfigFolderName); } catch { }
            }
        }

        public static void SaveClients(List<ClientDetails> clients)
        {
            CheckDirs();
            string json = JsonConvert.SerializeObject(clients);
            using (StreamWriter sw = File.AppendText(ConfigPath + "Clients.json"))
            {
                sw.WriteLine(json);
            }
        }

        public static List<ClientDetails> ReadClients()
        {
            List<ClientDetails> clients = new List<ClientDetails>();
            try
            {
                using(StreamReader reader = new StreamReader(ConfigPath + "Clients.json"))
                {
                    string raw = reader.ReadToEnd();
                    var rawClients = JsonConvert.DeserializeObject<List<ClientDetails>>(raw);
                    for (int i = 0; i < rawClients.Count; i++)
                    {
                        ClientDetails client = new ClientDetails();
                        client.IP_DNS = rawClients[i].IP_DNS;
                        client.NickName = rawClients[i].NickName;
                        clients.Add(client);
                    }
                }
            }
            catch (Exception ex)
            {
                // File missing or corrupt json stream
                //TODO: Handle this or report it
            }

            return clients;
        }

        public static void SaveReport(List<ClientDetails> clients)
        {
            FileDialog fD = new SaveFileDialog();
            fD.Filter = "Text Files|*.txt";
            fD.Title = "Select report save location...";
            fD.ShowDialog();
            string fullPath = fD.FileName;
            try
            {
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    foreach (var c in clients)
                    {
                        sw.WriteLine(c.IP_DNS);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: Handle IO errors
            }
        }

    }
}
