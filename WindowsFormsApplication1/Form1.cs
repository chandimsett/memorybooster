using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
            Thread.Sleep(3000);
            MessageBox.Show("Memory Cleaned!!", "CHS Memory booster",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private StringBuilder initialScript() {
            StringBuilder sb = new StringBuilder();
            sb.Append("@echo on" + Environment.NewLine);
            return sb;
        }
        private StringBuilder postScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("msg * Your PC was serviced by CHS Memory Booster!" + Environment.NewLine);
            return sb;
        }
        private string memoryScript()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(initialScript());
            sb.Append("del /s /f /q c:\\windows\temp\\*.*" + Environment.NewLine);
            sb.Append(" rd /s /q c:\\windows\\temp" + Environment.NewLine);
            sb.Append(" md c:\\windows\\temp" + Environment.NewLine);
            sb.Append("del /s /f /q C:\\WINDOWS\\Prefetch" + Environment.NewLine);
            sb.Append(" del /s /f /q %temp%\\*.*" + Environment.NewLine);
            sb.Append(" rd /s /q %temp%" + Environment.NewLine);
            sb.Append(" md %temp%" + Environment.NewLine);
            sb.Append(postScript());

            return sb.ToString();
        }

        public void memoryExecute()
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                UseShellExecute = false,
                RedirectStandardInput = true
            };
            Process proc = new Process() { StartInfo = psi };

            proc.Start();

            proc.StandardInput.Write(memoryScript());

            proc.WaitForExit();
            proc.Close();
        }
        public void ExecuteCommand()
        {
            
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\clean.cmd";
            //process.StartInfo.Arguments = @"C:\myfolder\pepsi.txt";
            process.Start();

        }

        private string CommandScript()
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programmed by Chandim Sett.\nchandimsett@gmail.com\nCopyright © 2013", "CHS Memory booster- About",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\diskclean.cmd";            
            process.Start();
            Thread.Sleep(3000);
            MessageBox.Show("Disk Cleaned!!", "CHS Memory booster",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\def.cmd";
            process.Start();
            Thread.Sleep(3000);
            MessageBox.Show("Disks Defragmented!!", "CHS Memory booster",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\cookies.cmd";
            process.Start();
            Thread.Sleep(3000);
            MessageBox.Show("Cookies were removed!!", "CHS Memory booster",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"bin\debug\internet.cmd";
            process.Start();
            Thread.Sleep(3000);
            MessageBox.Show("Temporary internet files were removed!!", "CHS Memory booster",
MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int exe = formloc.X - cursloc.X + Cursor.Position.X; int eye = formloc.Y - cursloc.Y + Cursor.Position.Y; this.Location = new Point(exe, eye);
        }
        const int WS_CLIPCHILDREN = 0x2000000; const int WS_MINIMIZEBOX = 0x20000; const int WS_MAXIMIZEBOX = 0x10000; const int WS_SYSMENU = 0x80000; const int CS_DBLCLKS = 0x8; protected override CreateParams CreateParams { get { CreateParams cp = base.CreateParams; cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU; cp.ClassStyle = CS_DBLCLKS; return cp; } }
        Point formloc, cursloc = new Point(0, 0);
        private void setpositions() { formloc = this.Location; cursloc = Cursor.Position; }
        private void Form1_Load(object sender, EventArgs e)
        {
            
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
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.minimizeover;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.minimize;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.Image = Properties.Resources.minimizedown;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.oneclickover;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.oneclick;
        }

      

        

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.Image = Properties.Resources.oneclickdown;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form2 f2= new Form2();
            f2.ShowDialog();
        }
    }
}
