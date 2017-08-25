using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string baseAddress = "http://localhost:9000/";

            HttpClient client = new HttpClient();

            var response = client.GetAsync(baseAddress + "api/values").Result;

           // Console.WriteLine(response);
            MessageBox.Show(response.Content.ReadAsStringAsync().Result);
        }
    }
}
