using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_game
{
    public partial class Normaali : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "icon1.jpg", "icon1.jpg", "icon2.jpg", "icon2.jpg", "icon3.jpg", "icon3.jpg", "icon4.jpg", "icon4.jpg",
            "icon5.jpg", "icon5.jpg", "icon6.jpg", "icon6.jpg", "icon7.jpg", "icon7.jpg", "icon8.jpg", "icon8.jpg",
            "icon9.jpg", "icon9.jpg", "icon10.jpg", "icon10.jpg", "icon11.jpg", "icon11.jpg", "icon12.jpg", "icon12.jpg",
            "icon13.jpg", "icon13.jpg", "icon14.jpg", "icon14.jpg", "icon15.jpg", "icon15.jpg", "icon16.jpg", "icon16.jpg",
            "icon18.jpg", "icon18.jpg", "icon18.jpg", "icon18.jpg"
        };

        Label firstClicked = null;

        Label secondClicked = null;

        int seconds = 0;
        int tenSeconds = 0;
        int minutes = 0;

        int parit = 0;
        public Normaali()
        {
            InitializeComponent();

            AssingIconsToSquares();
            timer2.Start();
        }

        private void AssingIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber].ToString();
                    icons.RemoveAt(randomNumber);
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is showing, the player clicked
                // an icon that's already been revealed --
                // ignore the click
                if (clickedLabel.Image != null)
                    return;

                // If firstClicked is null, this is the first icon
                // in the pair that the player clicked, 
                // so set firstClicked to the label that the player 
                // clicked, change it to visible, and return
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.Image = Image.FromFile("images/" + firstClicked.Text);
                    return;
                }

                // If the player gets this far, the timer isn't
                // running and firstClicked isn't null,
                // so this must be the second icon the player clicked
                // Set it to be visible
                secondClicked = clickedLabel;
                secondClicked.Image = Image.FromFile("images/" + secondClicked.Text);


                CheckForWinner();

                // If the player clicked two matching icons, keep them 
                // visible and reset firstClicked and secondClicked 
                // so the player can click another icon
                if (firstClicked.Text == secondClicked.Text)
                {
                    parit++;
                    pisteet.Text = parit.ToString();

                    firstClicked = null;
                    secondClicked = null;
                    return;
                }


                // If the player gets this far, the player 
                // clicked two different icons, so start the 
                // timer (which will wait three quarters of 
                // a second, and then hide the icons)
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            firstClicked.Image = null;
            secondClicked.Image = null;

            // Reset firstClicked and secondClicked 
            // so the next time a label is
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }

        private void CheckForWinner()
        {
            // Check if you got all the pairs and end the game
            if (parit == 7)
            {
                End_Game();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            seconds = seconds + 1;
            if (seconds >= 10)
            {
                tenSeconds = tenSeconds + 1;
                seconds = 0;
                if (tenSeconds >= 6)
                {
                    tenSeconds = 0;
                    minutes = minutes + 1;
                }
            }
            timeLabel.Text = minutes.ToString() + ":" + tenSeconds.ToString() + seconds.ToString();
        }

        private void Normaali_Load(object sender, EventArgs e)
        {

        }

        private void End_Game()
        {
            timer2.Stop();
            // If the loop didn’t return, it didn't find
            // any unmatched icons
            // That means the user won. Show a message and close the form
            MessageBox.Show("Löysit kaikki parit!", "Hienoa!");

            AloitusRuutu aloitus = new AloitusRuutu();
            this.Hide();
            aloitus.Show();
        }
    }
}
