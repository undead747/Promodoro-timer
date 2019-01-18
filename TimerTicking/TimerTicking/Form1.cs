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

namespace TimerTicking
{
    public partial class Form1 : Form
    {
        int hours1 = 0, minutes1 = 0, seconds1 = 0;
        int hours, minutes, seconds;
        bool click = false, turn;
        int cur_template = 0;
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase+"\\sound\\bee.wav");
        string path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase + "\\sound\\beep-08b.wav");

        List<Dictionary<string, Color>> templates = new List<Dictionary<string, Color>>();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C: \Users\Asus\Desktop\beep.wav");
        System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(@"C: \Users\Asus\Desktop\beep-08b.wav");

        public Form1()
        {
            InitializeComponent();

            loader.Dock = DockStyle.Fill;
            //lets add asome templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(255, 192, 128));
            template.Add("bottomright", Color.FromArgb(251, 97, 122));
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.FromArgb(251, 97, 122));

            templates.Add(template);


            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(192, 0, 192));
            template.Add("bottomright", Color.Black);
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.FromArgb(251, 97, 122));

            templates.Add(template);

            template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.Black);
            template.Add("bottomright", Color.Black);
            template.Add("topleft", Color.FromArgb(251, 97, 122));
            template.Add("topright", Color.DarkTurquoise);

            templates.Add(template);

            //init fist theme
            load_theme(templates[cur_template]);
        }

            

        
        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            if (TextboxSR.Text.Equals("00") && TextboxMR.Text.Equals("00") && TextboxHR.Text.Equals("00") || TextboxHS.Text.Equals("00") && TextboxMS.Text.Equals("00") && TextboxSS.Text.Equals("00"))//here we check if the textboxes are empty
            {
                MessageBox.Show("No correct inputs");
            }
            else
            {
                TextboxHR.Enabled = false;
                TextboxMR.Enabled = false;
                TextboxSR.Enabled = false;
                TextboxHS.Enabled = false;
                TextboxMS.Enabled = false;
                TextboxSS.Enabled = false;
                if (bunifuThinButton21.ButtonText.Equals("Start"))
                {
                    bunifuThinButton21.ButtonText = "Stop";
                    timer3.Start();
                    if (click == false)
                    {
                        hours = int.Parse(TextboxHS.Text);
                        minutes = int.Parse(TextboxMS.Text);
                        seconds = int.Parse(TextboxSS.Text);

                        timer1.Start();
                        click = true;
                    }
                    else
                    {
                        hours = int.Parse(labelH.Text);
                        minutes = int.Parse(labelM.Text);
                        seconds = int.Parse(labelS.Text);
                        if (turn == false)
                            timer1.Start();
                        else timer2.Start();
                    }
                }
                else
                {
                    bunifuThinButton21.ButtonText = "Start";
                    timer3.Stop();
                    timer1.Stop();
                    timer2.Stop();
                }
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void load_theme(Dictionary<string, Color> theme)
        {
            this.Opacity = 0.9;
            loader.Visible = true;
            bunifuGradientPanel1.GradientBottomLeft = theme["bottomleft"];
            bunifuGradientPanel1.GradientBottomRight = theme["bottomright"];
            bunifuGradientPanel1.GradientTopLeft = theme["topleft"];
            bunifuGradientPanel1.GradientTopRight = theme["topright"];

            hideloader.Start();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            //lets add asome templates
            Dictionary<string, Color> template = new Dictionary<string, Color>();

            template.Add("bottomleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("bottomright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topleft", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));
            template.Add("topright", Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)));

            bunifuThinButton21.BackColor = Color.Transparent;
            bunifuThinButton22.BackColor = Color.Transparent;

            load_theme(template);


            //safe theme
            templates.Add(template);
        }
      
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            player.Stop();
            player1.Stop();
        }

        Boolean flag;
        int x, y;
        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            flag = true;
            x = e.X;
            y = e.Y;
        }

        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            flag = false;
        }

        private void bunifuGradientPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
               if(flag == true)
            {
                this.SetDesktopLocation(Cursor.Position.X - x, Cursor.Position.Y - y);

            }
        }

        private void hideloader_Tick_1(object sender, EventArgs e)
        {
            hideloader.Stop();
            loader.Visible = false;
            this.Opacity = 0.9;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (seconds1 == 59)
            {
                seconds1 = 0;
                if (minutes1 == 59)
                {
                    minutes1 = 0;
                    hours1 += 1; ;
                }
                else minutes1 += 1;

            }
            else seconds1 += 1;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            bunifuThinButton21.ButtonText = "Start";

            TextboxHR.Text = "00";
            TextboxMR.Text = "00";
            TextboxSR.Text = "00";

            TextboxHS.Text = "00";
            TextboxMS.Text = "00";
            TextboxSS.Text = "00";

            if (hours1 > 9)
                labelH.Text = hours1.ToString();
            else labelH.Text = "0" + hours1.ToString();
            if (minutes1 > 9)
                labelM.Text = minutes1.ToString();
            else labelM.Text = "0" + minutes1.ToString();
            if (seconds1 > 9)
                labelS.Text = seconds1.ToString();
            else labelS.Text = "0" + seconds1.ToString();

            if (hours1 >= 3) popup.Text = "You did it great !";

            hours1 = 0;
            minutes1 = 0;
            seconds1 = 0;
            click = false;

            TextboxHR.Enabled = true;
            TextboxMR.Enabled = true;
            TextboxSR.Enabled = true;

            TextboxHS.Enabled = true;
            TextboxMS.Enabled = true;
            TextboxSS.Enabled = true;


        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            if (hours == 0 && minutes == 0 && seconds == 0)
                {
                    hours = int.Parse(TextboxHR.Text);
                    minutes = int.Parse(TextboxMR.Text);
                    seconds = int.Parse(TextboxSR.Text);
                    turn = true;
                    timer1.Stop();
                    player.Play();
                    timer2.Start();
                }
                else
                {
                    if (seconds < 1)
                    {
                        seconds = 59;
                        if (minutes < 1)
                        {
                            minutes = 59;
                            if (hours != 0)
                                hours -= 1;;
                        }
                        else minutes -= 1;

                    }
                    else seconds -= 1;
                    if (hours > 9)
                        labelH.Text = hours.ToString();
                    else labelH.Text = "0" + hours.ToString();
                    if (minutes > 9)
                        labelM.Text = minutes.ToString();
                    else labelM.Text = "0" + minutes.ToString();
                    if (seconds > 9)
                        labelS.Text = seconds.ToString();
                    else labelS.Text = "0" + seconds.ToString();

                 
                }
            }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (hours == 0 && minutes == 0 && seconds == 0)
                {
                    hours = int.Parse(TextboxHS.Text);
                    minutes = int.Parse(TextboxMS.Text);
                    seconds = int.Parse(TextboxSS.Text);
                    turn = false;
                    timer2.Stop();
                    player1.Play();
                    timer1.Start();

                }
                else
                {
                    if (seconds < 1)
                    {
                        seconds = 59;
                        if (minutes < 1)
                        {
                            minutes = 59;
                            if (hours != 0)
                                hours -= 1;
                        }
                        else minutes -= 1;

                    }
                    else seconds -= 1;
                    if (hours > 9)
                        labelH.Text = hours.ToString();
                    else labelH.Text = "0" + hours.ToString();
                    if (minutes > 9)
                        labelM.Text = minutes.ToString();
                    else labelM.Text = "0" + minutes.ToString();
                    if (seconds > 9)
                        labelS.Text = seconds.ToString();
                    else labelS.Text = "0" + seconds.ToString();

                    
                }
            }
        
    }
    }


