using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        const int WS_CLIPCHILDREN = 0x2000000; const int WS_MINIMIZEBOX = 0x20000; const int WS_MAXIMIZEBOX = 0x10000; const int WS_SYSMENU = 0x80000; const int CS_DBLCLKS = 0x8; protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU; cp.ClassStyle = CS_DBLCLKS; return cp; } }
        Point formloc, cursloc = new Point(0, 0);
        private void setpositions() { formloc = this.Location; cursloc = Cursor.Position; }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.timer2.Start();
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\clean.cmd";
            process.Start();
            process.StartInfo.FileName = @"bin\debug\diskclean.cmd";
            process.Start();
            process.StartInfo.FileName = @"bin\debug\def.cmd";
            process.Start();
            process.StartInfo.FileName = @"bin\debug\internet.cmd";
            process.Start();
            process.StartInfo.FileName = @"bin\debug\cookies.cmd";
            process.Start();

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpositions();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            setpositions();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int exe = formloc.X - cursloc.X + Cursor.Position.X; int eye = formloc.Y - cursloc.Y + Cursor.Position.Y; this.Location = new Point(exe, eye);
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.closeover;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.close;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.Image = Properties.Resources.closedown;
            if (progressBar1.Value == 100)
            { this.Close(); }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(3);
            if(progressBar1.Value==100)
            {
                this.label1.Text = "MEMORY BOOSTED!!";
                
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Start();
            setpositions();
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            setpositions();
        }

       
        
        
    }
}
