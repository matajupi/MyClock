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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var tl = Program.SettingsFile.DefaultTime.Split('/').Select(x => int.Parse(x)).ToArray();
            this.numericUpDown1.Value = tl[0];
            this.numericUpDown1.Maximum = 23;
            this.numericUpDown1.Minimum = 0;

            this.numericUpDown2.Value = tl[1];
            this.numericUpDown2.Maximum = 59;
            this.numericUpDown2.Minimum = 0;

            this.numericUpDown3.Value = tl[2];
            this.numericUpDown3.Maximum = 59;
            this.numericUpDown3.Minimum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dtime = $"{this.numericUpDown1.Value.ToString()}/{this.numericUpDown2.Value.ToString()}/{this.numericUpDown3.Value.ToString()}";
            Program.SettingsFile.DefaultTime = dtime;
            this.Close();
        }
    }
}
