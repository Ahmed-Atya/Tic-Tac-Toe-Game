using Draw.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        
        enum enPlayer
        {
            Player1, Player2
        }
        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }
        struct stGameStatus
        {
           public enWinner Winner;
           public bool GameOver;
           public short PlayCount;

        }
        void EndGame()
        {

            lbPlayer.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lbWinnerName.Text = "Ahmed";
                    break;

                case enWinner.Player2:

                    lbWinnerName.Text = "Mohamed";
                    break;

                default:

                    lbWinnerName.Text = "Draw";
                    break;

            }


            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }
        public bool CheckValues(PictureBox pictureBox1, PictureBox pictureBox2, PictureBox pictureBox3)
        {
            if (pictureBox1.Tag.ToString() != "?" && pictureBox1.Tag.ToString() == pictureBox2.Tag.ToString() && pictureBox1.Tag.ToString() == pictureBox3.Tag.ToString()) {

                pictureBox1.BackColor = Color.GreenYellow;
                pictureBox2.BackColor = Color.GreenYellow;
                pictureBox3.BackColor = Color.GreenYellow;

                if(pictureBox1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    DisableAllPictureBoxes();
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    DisableAllPictureBoxes();
                    EndGame();
                    return true;
                }

            }
            GameStatus.GameOver = false;
            return false;
        }
        void CheckWinner()
        {
            if (CheckValues(pictureBox1, pictureBox2, pictureBox3)) {
                return;
            }
            if(CheckValues(pictureBox4, pictureBox5, pictureBox6))
            {
                return;
            }

            if (CheckValues(pictureBox7, pictureBox8, pictureBox9))
            {
                return;
            }
            if (CheckValues(pictureBox1, pictureBox4, pictureBox7))
            {
                return;
            }
            if (CheckValues(pictureBox2, pictureBox5, pictureBox8))
            {
                return;
            }
            if (CheckValues(pictureBox3, pictureBox6, pictureBox9))
            {
                return;
            }
            if (CheckValues(pictureBox1, pictureBox5, pictureBox9))
            {
                return;
            }
            if (CheckValues(pictureBox3, pictureBox5, pictureBox7))
            {
                return;
            }
        }
        public void ChangeImage(PictureBox pictureBox)
        {
            if (pictureBox.Tag.ToString() == "?") {


                switch (PlayerTurn){
                    case enPlayer.Player1:
                        pictureBox.Image = Resources.X;
                        pictureBox.Tag = "X";
                        PlayerTurn = enPlayer.Player2;
                        GameStatus.PlayCount++;
                        lbPlayer.Text = "Mohamed";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        pictureBox.Image = Resources.O;
                        pictureBox.Tag = "O";
                        PlayerTurn = enPlayer.Player1;
                        GameStatus.PlayCount++;
                        lbPlayer.Text = "Ahmed";
                        CheckWinner();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Wrong Choices ", "You Clicked this before");

            }

            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }
        private void ResetPictureBox(PictureBox pictureBox)
        {
            lbPlayer.Text = "Ahmed";
            pictureBox.Image = Resources.question_mark_96;
            pictureBox.Tag = "?";
            pictureBox.BackColor = Color.Black;

        }
        private void RestartGame()
        {

            ResetPictureBox(pictureBox1);
            ResetPictureBox(pictureBox2);
            ResetPictureBox(pictureBox3);
            ResetPictureBox(pictureBox4);
            ResetPictureBox(pictureBox5);
            ResetPictureBox(pictureBox6);
            ResetPictureBox(pictureBox7);
            ResetPictureBox(pictureBox8);
            ResetPictureBox(pictureBox9);
            ReEnableAllPictureBoxes();
            PlayerTurn = enPlayer.Player1;
            lbPlayer.Text = "Ahmed";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lbWinnerName.Text = "In Progress";
        }
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            lbPlayer.Text = "Ahmed";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.FromArgb(255, 0, 0, 0);

            Pen Pen = new Pen(Black);
            Pen.Width = 10;

           // Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;



           
            e.Graphics.DrawRectangle(Pen, 200, 100, 200, 200);
            e.Graphics.DrawRectangle(Pen, 400, 100, 200, 200);
            e.Graphics.DrawRectangle(Pen, 600, 100, 200, 200);
            e.Graphics.DrawRectangle(Pen, 200, 300, 200, 200);
            e.Graphics.DrawRectangle(Pen, 400, 300, 200, 200);
            e.Graphics.DrawRectangle(Pen, 600, 300, 200, 200);
            e.Graphics.DrawRectangle(Pen, 200, 500, 200, 200);
            e.Graphics.DrawRectangle(Pen, 400, 500, 200, 200);
            e.Graphics.DrawRectangle(Pen, 600, 500, 200, 200);
        }
        private void pictureBox_Click(object sender, EventArgs e)
        {

            ChangeImage((PictureBox)sender);

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void DisableAllPictureBoxes()
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
        }
        private void ReEnableAllPictureBoxes()
        {
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
            pictureBox9.Enabled = true;
        }
    }
}
