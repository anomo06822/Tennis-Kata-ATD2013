using System;
using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";

            if (IsDeuce())
            {
                score = GetReuce();
            }

            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = GetPointDiff();
                if (IsAdvantage(minusResult))
                {
                    score = GetAdvantage(minusResult);
                }
                else if (IsWin(minusResult))
                {
                    score = GetWin(minusResult);
                }
                else score = "Win for player2";
            }
            else
            {
                if (IsSameScore())
                {
                    score = $"{ GetScore(m_score1)}-All";
                }

                score = GetScore(m_score1) + "-" + GetScore(m_score2);
            }

            return score;
        }

        private static string GetAdvantage(int minusResult)
        {
            return minusResult > 0 ? "Advantage player1" : "Advantage player2";
        }

        private int GetPointDiff()
        {
            return Math.Abs(m_score1 - m_score2);
        }

        private string GetWin(int minusResult)
        {
            return minusResult > 0 ? "Win for player1" : "Win for  player2";
        }

        private  bool IsWin(int minusResult)
        {
            return GetPointDiff() >= 2;
        }

        private  bool IsAdvantage(int minusResult)
        {
            return GetPointDiff() == 1;
        }

        private  string GetReuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return IsSameScore() && m_score1 >= 3;
        }

        private bool IsSameScore()
        {
            return m_score1 == m_score2;
        }

        private static string GetScore(int tempScore)
        {
            Dictionary<int, string> scoreDic = new Dictionary<int, string>()
            {
                { 0, "Love" }, { 1, "Fifteen" }, { 2, "Thirty" }, { 3, "Forty" }
            };

            return scoreDic[tempScore];
        }
    }
}

