﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rockpaperscissors
{
    public partial class Form1 : Form
    {
        //declaring the variables for this game

        public int rounds = 3; // 3 rounds per game
        public int timePerRound = 6; // 5 seconds per rounds
        //enemy choice options stored inside an array for easy access
        string[] AIchoice = { "rock", "paper", "scissor", "rock", "scissor", "paper" };
        public int randomNumber;
        string command;
        Random rnd = new Random();
        string playerChoice;
        int playerWins = 0;
        int AIwins = 0;

        // end of declaring variables
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            playerChoice = "none";
        }
        private void decisionEngine()
        {
            if (playerWins > AIwins)
            {
                label3.Text = label1.Text + " Wins the game";
            }
            else
            {
                label3.Text = "AI Wins the game";
            }
        }
        private void nextRound()
        {
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.qq;
            timer1.Enabled = true;
            pictureBox2.Image = Properties.Resources.qq;

        }
        private void checkGame()
        {
            if (playerChoice == "rock" && command == "paper")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "rock")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "scissor")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissor" && command == "paper")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissor" && command == "rock")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "rock" && command == "scissor")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show(label1.Text + " Make a choice");
                nextRound();
            }
            else
            {
                MessageBox.Show("Draw");
                nextRound();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(rounds);
            timePerRound--; // reduce the time by 1
            label4.Text = Convert.ToString(timePerRound); // show the time on the screen
            if (timePerRound < 1) // if the time is less then one second 
            {

                timer1.Enabled = false; // we disable the timer if less then one second left 

                timePerRound = 6; // set the timer back to 6 seconds 
                randomNumber = rnd.Next(0, 5); // randomize the number again 
                command = AIchoice[randomNumber];
                // we set up the AI choice according to the random number 

                // the switch statement below will show the AI choice and change the picture box images 

                switch (command)

                {

                    case "rock":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;

                    case "paper":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;

                    case "scissor":
                        pictureBox2.Image = Properties.Resources.scissors;
                        break;

                    default:
                        break;

                }

                // if we have more rounds to the play then we run the check game function 

                if (rounds > 1)
                {
                    checkGame();
                }
                // if we dont have any more rounds to play then we go to the final decision engine
                else
                {
                    decisionEngine();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            pictureBox1.Image = Properties.Resources.rock;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            pictureBox1.Image = Properties.Resources.paper;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            pictureBox1.Image = Properties.Resources.scissors;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helpScreen help = new helpScreen();
            help.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
