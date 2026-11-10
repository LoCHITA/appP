using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class FormCheckRequest : Form
    {
        string exChar = @"[#@$%]";

        MyHTTP myHttp = new MyHTTP();

        public FormCheckRequest()
        {
            InitializeComponent();
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = await myHttp.Listen();
                if (Regex.IsMatch(textBox1.Text, exChar))
                {
                    MessageBox.Show("Error");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }
    }

    internal class MyHTTP
    {
        public async Task<string> Listen()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string jsonResponse = await httpClient.GetStringAsync("http://localhost:5243");

                return jsonResponse;
            }
        }
    }

}
