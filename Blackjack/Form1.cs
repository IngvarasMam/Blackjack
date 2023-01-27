using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Blackjack
{
    public partial class Form1 : Form
    {
        string profit = "0";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (int.Parse(balanceText.Text) < Convert.ToInt32(Math.Round(betAmount.Value, 0)))
            {
                MessageBox.Show("Insufficient Balance");
            }
            else
            {
                balanceText.Text = (int.Parse(balanceText.Text) - Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();

                btnStartGame.Visible = false;
                betAmount.Enabled = false;
                btnHit.Enabled = true;
                dealNumber.Visible = true;
                plrNumber.Visible = true;
                btnStand.Enabled = true;
                Random rnd = new Random();
                dealNumber.Text = rnd.Next(1, 11).ToString();
                int firstNumber = rnd.Next(1, 11);
                int secondNumber = rnd.Next(1, 11);
                plrNumber.Text = (firstNumber + secondNumber).ToString();
            }

        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            if (int.Parse(plrNumber.Text) <= 21)
            {
                plrNumber.Text = (int.Parse(plrNumber.Text) + rnd.Next(1, 11)).ToString();
                if (int.Parse(plrNumber.Text) > 21)
                {
                    MessageBox.Show($"YOU LOSE. YOUR NUMBER : {plrNumber.Text},DEALER NUMBER : {dealNumber.Text}");
                    profit = (int.Parse(profit) - Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();
                    betAmount.Enabled = true;
                    btnStartGame.Visible = true;
                    btnHit.Enabled = false;
                    dealNumber.Visible = false;
                    dealNumber.Text = "0";
                    plrNumber.Visible = false;
                    plrNumber.Text = "0";
                    btnStand.Enabled = false;
                }
            }

        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            btnHit.Enabled = false;
            bool restart = false;
            while (!restart)
            {
                
                if (int.Parse(dealNumber.Text) <= 16)
                {
                    
                    dealNumber.Text = (int.Parse(dealNumber.Text) + rnd.Next(1, 11)).ToString();                    

                }
                if (int.Parse(dealNumber.Text) >= 17 && int.Parse(dealNumber.Text) <= 21)
                {
                    restart = true;
                    if (int.Parse(dealNumber.Text) > int.Parse(plrNumber.Text))
                    {
                        MessageBox.Show($"You Lost! Dealer's Number : {dealNumber.Text}, Your Number : {plrNumber.Text}");
                        profit = (int.Parse(profit) - Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();
                    }
                    else if (int.Parse(dealNumber.Text) < int.Parse(plrNumber.Text))
                    {
                        MessageBox.Show($"You Won! Dealer's Number : {dealNumber.Text}, Your Number : {plrNumber.Text}");
                        balanceText.Text = (int.Parse(balanceText.Text) + Convert.ToInt32(Math.Round(betAmount.Value, 0)) * 2).ToString();
                        profit = (int.Parse(profit) + Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();
                    }
                    else if (int.Parse(dealNumber.Text) == int.Parse(plrNumber.Text))
                    {
                        MessageBox.Show($"Tie! Dealer's Number : {dealNumber.Text}, Your Number : {plrNumber.Text}");
                        balanceText.Text = (int.Parse(balanceText.Text) + Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();
                    }
                    betAmount.Enabled = true;
                    btnStartGame.Visible = true;
                    btnHit.Enabled = false;
                    dealNumber.Visible = false;
                    dealNumber.Text = "0";
                    plrNumber.Visible = false;
                    plrNumber.Text = "0";
                    btnStand.Enabled = false;

                }
                if (int.Parse(dealNumber.Text) > 21)
                {
                    restart = true;
                    MessageBox.Show($"You Won! Dealer Busted. Dealer's Number : {dealNumber.Text}, Your Number : {plrNumber.Text}");
                    profit = (int.Parse(profit)+ Convert.ToInt32(Math.Round(betAmount.Value, 0))).ToString();
                    balanceText.Text = (int.Parse(balanceText.Text) + Convert.ToInt32(Math.Round(betAmount.Value, 0)) * 2).ToString();
                    betAmount.Enabled = true;
                    btnStartGame.Visible = true;
                    btnHit.Enabled = false;
                    dealNumber.Visible = false;
                    dealNumber.Text = "0";
                    plrNumber.Visible = false;
                    plrNumber.Text = "0";
                    btnStand.Enabled = false;
                }
            }


        }

        private void balanceText_Click(object sender, EventArgs e)
        {
            balanceText.Text = (int.Parse(balanceText.Text) + 500).ToString();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Each participant attempts to beat the dealer by getting a count as close to 21 as possible, without going over 21.");
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Ingvaras");
        }
        private void totalSeasonWinsToolStripMenuItem_Click(object sender, EventArgs e) // Profit
        {
            MessageBox.Show($"{profit}");
        }
        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
