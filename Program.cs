using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtorrent_rpc_test
{
    class Program
    {
        static void Main(string[] args)
        {
            RTorrentRpc r = new RTorrentRpc("http://imp.seedboxes.cc/mahogland/RPC");
            r.ListMethods();
        }
    }
}
