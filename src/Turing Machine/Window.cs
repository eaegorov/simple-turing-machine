using System;
using System.Windows.Forms;
using System.Drawing;

namespace Turing_Machine
{
    class Window
    {
        Form form;
        PictureBox pb;
        TextBox inputBox;
        Timer mainTimer;
        Timer renderTimer;
        
        public Window()
        {
            Init();
        }

        public Form getFormReference()
        {
            return form;
        }

        public void Init()
        {
            form = new Form();
            form.Size = new Size(800, 800);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = "Turing Machine";

            inputBox = new TextBox();
            inputBox.Size = new Size(300, 60);
            inputBox.Location = new Point((form.Size.Width - inputBox.Size.Width) / 2, form.Size.Height * 8 / 10);
            inputBox.Font = new System.Drawing.Font("Arial", 16);
            inputBox.AppendText("Input here");


            pb = new PictureBox();
            pb.Size = new Size(form.Size.Width, 120);
            pb.BackColor = Color.Blue;

            mainTimer = new Timer();
            renderTimer = new Timer();

            


            form.Controls.Add(inputBox);
            form.Controls.Add(pb);
        }
    }
}
