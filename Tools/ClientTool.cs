using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
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
    }
}
