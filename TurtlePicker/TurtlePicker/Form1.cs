using System;
using System.Drawing;
using System.Windows.Forms;

namespace TurtlePicker
{

    /*
     * Directions: NW, NE, SW, SE
     * Depths: Orange, Black, White, Corner
     * 
     * Directional Values:
     * 1 = NW, 2 = NE, 3 = SW, 4 = SE
     * 
     * Depth Values:
     * 1 = Orange, 2 = Black, 3 = White, 4 = Corner
     * 
     * Colors:
     * 45-25 seconds - Green
     * 45-11 seconds - Orange
     * 10-0 seconds - Red
     */

    public partial class Form1 : Form
    {
        string[] directions = new string[] { "Northwest", "Northeast", "Southwest", "Southeast" };
        string[] depths = new string[] { "Orange", "Black", "White", "Corner" };

        Random random = new Random();
        public int seconds = 45;
        public int rounds = 1;

        int R = 30;
        int G = 30;
        int B = 30;
        bool maxRed = false;
        bool maxGreen = false;
        bool maxBlue = false;
        bool changeColors = true;

        public Form1()
        {
            InitializeComponent();
            string initLocation = directions[random.Next(0, 4)].ToString() + ", " + depths[random.Next(0, 4)].ToString();
            richTextBox1.AppendText(initLocation);
        }

        //When timer ticks:
        private void timer1_Tick(object sender, EventArgs e)
        {
            update();
        }

        //Updates the timer label:
        private void update()
        {
            timer.Text = seconds.ToString();
            seconds--;

            //Color Changing:
            if (seconds <= 45 && seconds >= 25)
            {
                timer.ForeColor = Color.Green;
            }

            if (seconds <= 24 && seconds >= 11)
            {
                timer.ForeColor = Color.Orange;
            }

            if (seconds <= 10 && seconds >= 0)
            {
                timer.ForeColor = Color.Red;
            }

            //Timer Reset:
            if (seconds == 0)
            {
                string direction = directions[random.Next(0, 4)];
                string depth = depths[random.Next(0, 4)];

                richTextBox1.AppendText("Round " + rounds.ToString() + ":  " + direction + ", " + depth + "\n");

                rounds++;
                seconds = 45;
            }
        }

        //Color Changing:
        private void timer2_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(R, G, B);

            if (!changeColors)
            {
                timer2.Enabled = false;
            }

            updateColors();
        }

        private void updateColors()
        {
            if (R == 255)
            {
                maxRed = true;
            }

            if (B == 255)
            {
                maxBlue = true;
            }

            if (G == 255)
            {
                maxGreen = true;
            }

            generateNewColors();
        }

        private void generateNewColors()
        {
            if (!maxRed)
            {
                R++;
                return;
            }

            if (!maxGreen)
            {
                G++;
                return;
            }

            if (!maxBlue)
            {
                B++;
                return;
            }

            if (maxRed && maxGreen && maxBlue)
            {
                R = 255;
                G = 255;
                B = 255;
                changeColors = false;
            }
        }









        //Ignore:
        private void timer_Click(object sender, EventArgs e)
        {

        }
    }
}