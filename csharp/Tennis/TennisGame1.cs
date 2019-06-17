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

        private bool IsDeuce() => IsTie() && m_score1 >= 3;

        private static string GetDeuce() => "Deuce";
        private string GetGameOver() => $"Win for {GetLeadingPlayer()}";
        private string GetAdvantage() => $"Advantage {GetLeadingPlayer()}";
        private string GetNormal() => IsTie() ? GetScore(m_score1) + "-All" : GetScore(m_score1) + "-" + GetScore(m_score2);



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
                score = GetDeuce();
            }
            else if (IsAdvantage())
            {
                score = GetAdvantage();
            }
            else if (IsGameOver())
            {
                score = GetGameOver();
            }
            else
            {
                score = GetNormal();
            }

            return score;
        }

        private string GetScore(int tempScore)
        {
            Dictionary<int, string> scoreDic = new Dictionary<int, string>()
            {
                { 0, "Love" }, { 1, "Fifteen" }, { 2, "Thirty" }, { 3, "Forty" }
            };

            if (tempScore > 3)
            {
                return string.Empty;
            }

            return scoreDic[tempScore];
        }


        private bool IsTie()
        {
            return m_score1 == m_score2;
        }


        private bool IsGameOver()
        {
            return IsReadyToWon() && Math.Abs(GetPointDiff()) >= 2;
        }

        private bool IsAdvantage()
        {
            return IsReadyToWon() && Math.Abs(GetPointDiff()) == 1;
        }

        private string GetLeadingPlayer()
        {
            return GetPointDiff() > 0 ? "player1" : "player2";
        }

        private int GetPointDiff()
        {
            return m_score1 - m_score2;
        }

        private bool IsReadyToWon()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }
    }
}

