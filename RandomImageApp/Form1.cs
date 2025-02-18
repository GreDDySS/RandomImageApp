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

namespace RandomImageApp
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string currentImageUrl;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                int width = new Random().Next(200, 800);
                int height = new Random().Next(200, 800);

                currentImageUrl = $"https://picsum.photos/{width}/{height}";

                byte[] imageBytes = await client.GetByteArrayAsync(currentImageUrl);
                using (var ms = new System.IO.MemoryStream(imageBytes))
                {
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
        }
    }
}
