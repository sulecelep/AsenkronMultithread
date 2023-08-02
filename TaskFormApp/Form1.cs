using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void BtnReadFile_Click(object sender, EventArgs e) //senkronda bu
        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            //string data = ReadFile();
            string data = String.Empty;
            //Yanii eğer arada farklı işlem yapmak istiyorsam await burada aldığım okuma bilgisini o işlemden sonrasında bekletirim.
            //orada alırım.
            //Task<string> okuma = ReadFileAsync(); //5sn sürsün  alttakiyle aynı aslında sadece birinin metodunda async await yok
            Task<string> okuma = ReadFileAsync2(); //5sn sürsün
            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com"); //1 sn sürsün 
            data = await okuma;  //bize söz vermiş olduğu Stringi burada aldık //4 sn bekleyecek
            //string data = await ReadFileAsync();
            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }
        private string ReadFile()  //Senkron Kod
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000); //5 saniye bekleyecek ekranı dondurup dondurmadığına bakcaz
                data = s.ReadToEnd(); //baştan sona kadar oku anlamına geliyor
            }
            return data;
        }
        //Senkron metottaki void ile asenkron'daki Task ifadesi aynı anlama gelir
        //Senkron metottaki string ile asenkron'daki Task<string> ifadesi aynı anlama gelir
        private async Task<string> ReadFileAsync() //Best Practice açısından async metodun adının sonu Async keyword'ü eklenir
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Task<string> mytask = s.ReadToEndAsync(); //Task taahhüttür
                //burada 10 sn süren farklı işlemler de yapabilirim
                //new HttpClient().GetAsync("");
                await Task.Delay(5000); //5 saniye boyunca asenkron istek yapmışız gibi davranacak, burada diyoruz ki sen 5 saniye bekle o sırada biz bir alt satıra geçelim
                //Thread.Sleep'ten farklı blocklama yapmaz 
                data = await mytask;
                return data;
            }

        }
        //Eğer asenkron bir metodun içinde başka bir asenkron metodu çağıracaksak async-await keywordu kullanılmalıdır.

        private Task<string> ReadFileAsync2()
        {
            StreamReader s = new StreamReader("dosya.txt");
            return s.ReadToEndAsync();
            //direkt geriye döndüğümüz zaman async-await ikilisini kullanmaya gerek yok
            //yani burada ekstra başka işlem de yapmadığımız için async-await kullanmadık

        }
    }
}
