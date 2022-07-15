using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Dance_Ico
{
    public partial class UserControl1 : UserControl
    {
        private Random _random;
        private System.Timers.Timer _myTimer = new System.Timers.Timer();
        private int startDelay = 10;
        public UserControl1()
        {
            InitializeComponent();
            this.MouseHover += LabelControl_MouseHover;
            this.MouseClick += LabelControl_MouseClick;
        }
        private void LabelControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void LabelControl_MouseHover(object sender, EventArgs e)
        {
            //_random = new Random();
            //int posX = _random.Next(0, 1600);
            //int posY = _random.Next(0, 900);
            //this.Location = new Point(posX, posY);
        }

        public void StartJumping(object obj, ElapsedEventArgs e)
        {
            _random = new Random();
            int posX = _random.Next(0, 1600);
            int posY = _random.Next(0, 900);
            this.Location = new Point(posX, posY);
        }

        private void StartTimer()
        {
            _myTimer.Interval = 1000;
            _myTimer.Elapsed += new ElapsedEventHandler(StartJumping);
            _myTimer.Start();
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            startDelay--;
            if (startDelay == 0)
            {
                StartTimer();
            }

        }
    }
}
