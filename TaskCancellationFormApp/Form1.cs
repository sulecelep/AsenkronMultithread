using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskCancellationFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Uzun Operasyon https://localhost:44307/api/home

            CancellationTokenSource ct = new CancellationTokenSource(); //bu class üzerinden bir cancellation token üreteceğiz
            Task<HttpResponseMessage> mytask;

            mytask = new HttpClient().GetAsync("https://localhost:44307/api/home", ct.Token);


            await mytask;

            var content = await mytask.Result.Content.ReadAsStringAsync();

            richTextBox1.Text = content;
        
        }
    }
}
