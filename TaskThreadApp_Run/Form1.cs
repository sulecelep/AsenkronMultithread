using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThreadApp_Run
{
    public partial class Form1 : Form
    {
        public static int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       



        private async void btnStart_Click(object sender, EventArgs e)
        {
            //Go(progressBar1);
            //Go(progressBar2);
            var atask = Go(progressBar1);
            var btask = Go(progressBar2);

            await Task.WhenAll(atask, btask );
        }
        public async Task Go(ProgressBar pb)
        {
            await Task.Run(() =>
            {
                Enumerable.Range(1, 100).ToList().ForEach(x =>
                {
                    Thread.Sleep(100);
                    //pb.Value = x;
                    pb.Invoke((MethodInvoker)delegate { pb.Value = x; });
                });
            });
            //Enumerable.Range(1, 100).ToList().ForEach(x =>
            //{
            //    Thread.Sleep(100);
            //    pb.Value = x;
            //});
        }
        private void btnCounter_Click(object sender, EventArgs e)
        {
            btnCounter.Text = Counter++.ToString();
        }
    }
}
