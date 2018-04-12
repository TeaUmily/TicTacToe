using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_LV7_analiza
{
    public partial class TicTacToe : Form
    {
        TicTacToeGame TTTGame; 
        string player1;
        string player2;
        int index;
        Dictionary<PictureBox, int> pictureAndIndex = new Dictionary<PictureBox, int>();
        string onMove;
        int counter = 0;
        int tie = 0;
        int[] results = new int[] { 0, 0 };

        public TicTacToe()
        {
            InitializeComponent();
            pictureAndIndex.Add(pictureBox0, 0);
            pictureAndIndex.Add(pictureBox1, 1);
            pictureAndIndex.Add(pictureBox2, 2);
            pictureAndIndex.Add(pictureBox3, 3);
            pictureAndIndex.Add(pictureBox4, 4);
            pictureAndIndex.Add(pictureBox5, 5);
            pictureAndIndex.Add(pictureBox6, 6);
            pictureAndIndex.Add(pictureBox7, 7);
            pictureAndIndex.Add(pictureBox8, 8);

        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            

        }
       
        private void cleanPictureBoxes()
        {
            pictureBox0.Image = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
        }

        private void enablePictureBoxes()
        {
            pictureBox0.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
            pictureBox8.Enabled = true;
        }

        private void btn_newGame_Click(object sender, EventArgs e)
        {
            cleanPictureBoxes();
            results[0] = 0;
            results[1] = 0;
            tie = 0;
            tieLBL.Text = tie.ToString();
            PointsPlayer1.Text = results[0].ToString();
            PointsPlayer2.Text = results[1].ToString();
            counter = 0;
            player1 = txtB_player1.Text;
            player2 = txtB_player2.Text;

            if (player1 == string.Empty)
            {
                MessageBox.Show("Please, enter the player1's name!");

            }

            if (player2 == string.Empty)
            {

                MessageBox.Show("Please, enter the player2's name!");

            }


            if (!(player1 == string.Empty) && !(player2 == string.Empty))
            {
                
                TTTGame = new TicTacToeGame(player1, player2);
                onMove = TTTGame.OnMove;
                enablePictureBoxes();
                current_player.Text = "On move: "+player1;
            }


        }


        private void pictureBox0_Click(object sender, EventArgs e)
        {
            PictureBox currentPictureBox = (PictureBox)sender;
            counter++;
            currentPictureBox.Enabled = false;

            if (onMove == player1)
            {
                currentPictureBox.Image = Properties.Resources.tic_tac_toe_X;
            }
            else
            {
                currentPictureBox.Image = Properties.Resources.tic_tac_toe_O;
            }

            index = pictureAndIndex.FirstOrDefault(x => x.Key == currentPictureBox).Value;
            TTTGame.draw(index);

            if (TTTGame.checkWin())
            {
                MessageBox.Show("Winner is " + TTTGame.getWinner());
                addPoint();
                newMatch();
            }
            else if(counter == 9)
            {
                MessageBox.Show("Unresolved match");
                tie++;
                tieLBL.Text = tie.ToString();
                newMatch();
            }

            else {
                onMove = TTTGame.OnMove;
                current_player.Text = "On move: " + TTTGame.OnMove;
            }

           

        }
        
        public void newMatch()
        {
            TTTGame.newGame();
            cleanPictureBoxes();
            onMove = TTTGame.OnMove;
            current_player.Text = "On move: " + onMove;
            enablePictureBoxes();
            counter = 0;
            PointsPlayer1.Text = results[0].ToString();
            PointsPlayer2.Text = results[1].ToString();

        }
   
        public void addPoint()
        {
            if (TTTGame.getWinner() == player1)
            {
                results[0]++;
            }
            else { results[1]++; }
        }

        
    }
}
