using System;
using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;
        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;
        private Dictionary<int, string> scoreDic = new Dictionary<int, string>()
        {
            { 0, "Love" }, { 1, "Fifteen"}, { 2, "Thirty"}, { 3, "Forty"}
        };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";

            if (p1point == p2point && p1point > 2)
            {
                score = "Deuce";
            }
            else if (p1point >= 4 || p2point >= 4)
            {
                if ((p1point - p2point) >= 1 || (p1point - p2point) <= -1)
                {
                    score = $"Advantage {Getplayer()}";
                }

                if ((p1point - p2point) >= 2 || (p1point - p2point) <= -2)
                {
                    score = $"Win for {Getplayer()}";
                }
            }
            else
            {
                if (p1point == p2point)
                {
                    score = $"{GetSinglePoint(p1point)}-All";
                }
                else
                {
                    score = $"{GetSinglePoint(p1point)}-{GetSinglePoint(p2point)}";
                }
            }
            return score;
        }

        private string GetSinglePoint(int point)
        {
            
            if (point == 1 || point == 2 || point == 3 || point == 0)
            {
                return scoreDic[point];
            }
            else
            {
                return string.Empty;
            }
        }

        private string Getplayer()
        {
            return p1point > p2point ? "player1" : "player2";
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

