using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LV7_analiza
{
    public class TicTacToeGame
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public string OnMove { get; private set; }
        private string firstPlayer;


        private char[] gameArray = new char[9];

        public TicTacToeGame(string pl1, string pl2)
        {
            this.Player1 = pl1;
            this.Player2 = pl2;
            this.OnMove = Player1;
            this.firstPlayer = Player1;

        }

        public string getWinner()
        {
            if (OnMove == Player1) return Player2;
            else return Player1;
        }


        public void draw(int index)
        {

            if (OnMove == Player1)
            {
                gameArray[index] = 'X';
            }

            else if (OnMove == Player2)
            {
                gameArray[index] = 'O';
            }

            changePlayer();


        }
        public void newGame()
        {
            if (firstPlayer == Player1)
            {
                firstPlayer = Player2;
            }
            else { firstPlayer = Player1; }
            OnMove = firstPlayer;
            for (int i = 0; i < 9; i++)
            {
                gameArray[i] = ' '; // "clean the game array"
            }

        }

        private void changePlayer()
        {
            if (OnMove == Player1) { OnMove = Player2; }
            else { OnMove = Player1; }

        }

        public bool checkWin()
        {
            if (checkAllMoves())
            {
                return true;
            }
            else return false;
        }

        private bool checkAllMoves()
        {
            return threeEqual(0, 1, 2) || threeEqual(3, 4, 5) || threeEqual(6, 7, 8) || threeEqual(0, 3, 6) || threeEqual(1, 4, 7) || threeEqual(2, 5, 8) || threeEqual(0, 4, 8) || threeEqual(2, 4, 6);
        }

        private bool threeEqual(int a, int b, int c)
        {

            if (gameArray[a] == gameArray[b] && gameArray[a] == gameArray[c] && (gameArray[a] == 'X' || gameArray[a] == 'O'))
            {
                return true;
            }
            return false;
        }


    }
}
