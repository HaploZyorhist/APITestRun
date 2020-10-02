using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;

namespace APITestRun
{
    static class Program
    {

        // Goals;
        // The search box should do a character search api from swapi website
        // the left hyperlink box should display the search result names
        // when clicked, or if there is only 1 viable result, the right box populates
        // with the details on the result


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
