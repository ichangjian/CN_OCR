using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNOCR;
namespace TestOCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RECG recg = new RECG();
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "图片(jpg)|*.jpg;*.jpeg";


            if (opf.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(opf.FileName);
                pictureBox1.Image = Image.FromHbitmap(bmp.GetHbitmap());
                pictureBox1.Refresh();
                
                BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptrbitmap = (bitmapdata.Scan0);
                List<String> cnts=new List<string>();

                if (recg.setImage(ptrbitmap, bmp.Width, bmp.Height, (int)bmp.PixelFormat, cnts) < 0)
                    MessageBox.Show("图片加载失败！");

                bmp.UnlockBits(bitmapdata);

                Bitmap bitmap = bmp;
                Graphics gp = Graphics.FromImage(bitmap);

                Font font = new Font("KaiTi", bitmap.Width / 30, FontStyle.Bold);
                SolidBrush sbrush = new SolidBrush(Color.Red);
                String s = "";
                for (int i = 0; i < cnts.Count(); i++)
                {
                    s += cnts[i]+"  ";
                    int x = bitmap.Width / 10;
                    int y = (i+1)*bitmap.Height / (cnts.Count()+1);
                    gp.DrawString(cnts[i], font, sbrush, x, y);
                }
                pictureBox2.Image = Image.FromHbitmap(bitmap.GetHbitmap());
                pictureBox2.Refresh();
                textBox1.Text = s;
                textBox1.Refresh();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
