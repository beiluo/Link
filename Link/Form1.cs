using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Link
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Draw();
        }

        private void Draw()
        {
            List<Image> li=new List<Image>();
            var path = AppDomain.CurrentDomain.BaseDirectory + @"Img\";
            li.Add(Image.FromFile(path+"fruit_01.jpg"));
            li.Add(Image.FromFile(path + "fruit_02.jpg"));
            li.Add(Image.FromFile(path + "fruit_03.jpg"));
            li.Add(Image.FromFile(path + "fruit_04.jpg"));
            li.Add(Image.FromFile(path + "fruit_05.jpg"));
            li.Add(Image.FromFile(path + "fruit_06.jpg"));
            li.Add(Image.FromFile(path + "fruit_07.jpg"));
            li.Add(Image.FromFile(path + "fruit_08.jpg"));
            li.Add(Image.FromFile(path + "fruit_09.jpg"));
            li.Add(Image.FromFile(path + "fruit_10.jpg"));
            var data = new LinkData().buildmatrix(10, 8);
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < data.Count; i++)
            {
             
            }
        }
    }
}
