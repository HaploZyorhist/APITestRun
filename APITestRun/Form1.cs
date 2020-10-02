using Newtonsoft.Json.Linq;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APITestRun
{
    public partial class Form1 : Form
    {
        public static string searchNameVar;
        public Form1()
        {
            InitializeComponent();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            // update search
            searchNameVar = searchBox.Text;
            characterList.Text = "";

            // go get from http
            var target = new Uri($"https://swapi.dev/api/people/?search={searchNameVar}");
            var httpPost = CreateHttpRequest(target, "Get");
            
            string data = GetResponse(httpPost);

            List<string> names = new List<string>();
            JObject peop = JObject.Parse(data);
            JArray people = (JArray)peop["results"];
            foreach (var results in people)
            {
                var nameD = (string)results["name"];
                var massS = (string)results["mass"];
                names.Add($"{nameD}");
                characterList.Text = "";

                for (int i = names.Count(); i > 0; i--)
                {
                    int j = names.Count() - i;
                    characterList.Text += names[j] + "\r\n";
                    
                }
            }

            
        }

        private static string GetResponse(HttpWebRequest httpPost)
        {
            using (var response = httpPost.GetResponse())
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }


        private static HttpWebRequest CreateHttpRequest(Uri target, string method)
        {
            var request = WebRequest.CreateHttp(target);
            request.Method = method;
            return request;
        }
    }
}
