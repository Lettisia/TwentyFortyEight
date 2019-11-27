using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwentyFortyEight;

namespace TwentyFortyEightApp
{
    public partial class Form1 : Form
    {
        GameBoard gb = new GameBoard();
        public Form1()
        {
            InitializeComponent();
            displayBoard(gb.Initialise());
            txtScore.Text = gb.Score.ToString();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            displayBoard(gb.Move(GameBoard.Direction.Up));
            UpdateGame();
        }

        private void UpdateGame()
        {
            txtScore.Text = gb.Score.ToString();
            if (gb.IsTwentyFortyEight())
            {
                lblStatus.Text = "You win!!!";
            }
            if (gb.IsGameOver())
            {
                lblStatus.Text = "You lose!!!";
            }
            displayBoard(gb.AddRandomTileToEmptySpace());
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            displayBoard(gb.Move(GameBoard.Direction.Left));
            UpdateGame();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            displayBoard(gb.Move(GameBoard.Direction.Right));
            UpdateGame();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            displayBoard(gb.Move(GameBoard.Direction.Down));
            UpdateGame();
        }

        private void displayBoard(int[,] board)
        {
            label00.Text = board[0, 0].ToString();
            label01.Text = board[0, 1].ToString();
            label02.Text = board[0, 2].ToString();
            label03.Text = board[0, 3].ToString();
            label10.Text = board[1, 0].ToString();
            label11.Text = board[1, 1].ToString();
            label12.Text = board[1, 2].ToString();
            label13.Text = board[1, 3].ToString();
            label20.Text = board[2, 0].ToString();
            label21.Text = board[2, 1].ToString();
            label22.Text = board[2, 2].ToString();
            label23.Text = board[2, 3].ToString();
            label30.Text = board[3, 0].ToString();
            label31.Text = board[3, 1].ToString();
            label32.Text = board[3, 2].ToString();
            label33.Text = board[3, 3].ToString();
        }
    }
}
