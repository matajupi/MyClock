using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyClock
{
    public partial class Form1 : Form
    {
        private ButtonState Button1State;
        private DateTime MyTime;
        private TimeSpan Difference;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetData();   
        }

        private void SetData()
        {
            var tl = Program.SettingsFile.DefaultTime.Split('/').Select(x => int.Parse(x)).ToArray();
            var today = DateTime.Now;
            this.MyTime = new DateTime(today.Year, today.Month, today.Day, tl[0], tl[1], tl[2]);

            this.timer1.Interval = 500;

            this.button1.Text = "Start";
            this.Button1State = ButtonState.Start;

            this.label1.Text = string.Format("{0:00}:{1:00}:{2:00}", this.MyTime.Hour, this.MyTime.Minute, this.MyTime.Second);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Button1State == ButtonState.Start)
            {
                this.Button1State = ButtonState.Reset;
                this.button1.Text = "Reset";

                this.Difference = DateTime.Now - this.MyTime;
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
                this.SetData();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var nowTime = DateTime.Now - this.Difference;
            this.label1.Text = string.Format("{0:00}:{1:00}:{2:00}", nowTime.Hour, nowTime.Minute, nowTime.Second);
        }
    }

    public enum ButtonState
    {
        Start,
        Reset,
    }
}
