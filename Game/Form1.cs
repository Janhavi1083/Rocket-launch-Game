using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_over.Hide();
        }

        //private const string V = "stars";
        bool right, left;
        Random rnd = new Random();  
        int x,distance,y,fq=1000,score;


        void Game_logic()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "rocks")
                {
                    if (player.Bounds.IntersectsWith(j.Bounds))
                    {
                        timer1.Stop();
                        player.Image = Properties.Resources.Explosion_img;
                        lbl_over.Show();
                    }
                }
            }
        }

        void Update_fuel()
        {
            if(fuel.Top>400)
            {
                y = rnd.Next(0, 300);
                fuel.Location = new Point(y, 0);
            }
            if(player.Bounds.IntersectsWith(fuel.Bounds))
            {
                fuel.Top = -300;
                y = rnd.Next(0, 300);
                fuel.Location=new Point(y, 0);  
                if(fq<900)
                {
                    fq += 100;
                    lbl_fuel.Text = "Fuel : " + fq + "/Ltr";

                }
            }

            if(fq>0)
            {
                fq -= 1;
                lbl_fuel.Text = "Fuel : " + fq + "/Ltr";
            }
            if(fq<1)
            {
                timer1.Stop();
            }

            fuel.Top += 3;

        }

        void  Rocks()
        {
            foreach(Control i in this.Controls)
            {
                if(i is PictureBox && i.Tag=="rocks")
                {
                    i.Top += 4;
                    if(i.Top>500)
                    {
                        x = rnd.Next(0, 500);
                        i.Location = new Point(x, 0);
                    }
                }
            }
        }
        void key_move()
        {
            if (right==true)
            {
                if(player.Left<450)
                {
                    player.Left += 2;
                }

            }
            if(left==true)

            if(player.Left>0)
            {
                    player.Left -= 2;
            }
        }
        void Launch_pad()
        {
            if (player.Top <= 400)
            {
                player.Top -= 1;
                launch_pad.Top += 1;
                bg.Top += 1;
                if (player.Top <= 250)
                {
                    player.Top = 250;
                }

            }
        }
       void Stars()
        {
            foreach (Control j in this.Controls)
            {
                if (j is Label && j.Tag == "stars")
                {

                    j.SendToBack();
                    j.Top += 10;
                    if (j.Top > 400)
                    {
                        j.Top = 0;
                        distance += 2;
                        lbl_distance.Text = "Distance:" + distance + "/KM";
                        score += 1;
                        lbl_score.Text = "Score: " + score;
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Launch_pad();
            Stars();
            key_move();
            Rocks();
            Update_fuel();
            Game_logic();

        }

        private void btn_launch_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btn_launch.Hide();
        }

      private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                right = true;
            }
            if(e.KeyCode==Keys.Left) 
            { 
                left = true; 
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
        }
    }
}
