using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace rtorrent_rpc_test
{
    public class RTorrentRpc
    {
        private string _url;
        public RTorrentRpc(string url)
        {
            _url = url;
        }
        public string[] ListMethods()
        {
            List<string> methods = new List<string>();

            string xml = @"<methodCall><methodName>system.listMethods</methodName></methodCall>";

            string res = Post(xml);

            XElement x = XElement.Parse(res);
            //<methodResponse><params>< param >< value >< array >< data >
            var d = x.Element("params").Element("param").Element("value").Element("array").Element("data");
            foreach (var n in d.Elements("value"))
            {
                //<value><string>methodname</string></value>
                var m = n.Element("string").Value;
                methods.Add(m);

            }

            return methods.ToArray();
        }


        private string Post(string xml)
        {
            string res = "";
            using (WebClient wc = new WebClient())
            {

                try
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "text/xml");
                    wc.Headers.Add(HttpRequestHeader.Authorization, "Basic bWFob2dsYW5kOmxhemVyMTIz");
                    byte[] response = wc.UploadData(_url, "POST", Encoding.ASCII.GetBytes(xml));
                    if (response != null)
                    {
                        res = Encoding.ASCII.GetString(response);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }

            return res;
        }
    }
}
