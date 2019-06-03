using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string player1 = "player1";
        private TennisPlayer tennisPlayer1;
        private TennisPlayer tennisPlayer2;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.tennisPlayer1 = new TennisPlayer() { Name = player1Name };
            this.tennisPlayer2 = new TennisPlayer() { Name = player2Name };
        }

        public void WonPoint(TennisPlayer tennisPlayer)
        {
            tennisPlayer.Score++;
        }

        public void WonPoint(string playerName)
        {
            TennisPlayer player = GetPlayer(playerName);
            this.WonPoint(player);
        }

        private TennisPlayer GetPlayer(string playerName)
        {
            return tennisPlayer1.Name == playerName ? tennisPlayer1 : tennisPlayer2;
        }

        public string GetScore()
        {
            int m_score1 = tennisPlayer1.Score;
            int m_score2 = tennisPlayer2.Score;

            string score = "";
            if (IsDeuce(m_score1, m_score2))
            {
                score = GetDeuce(m_score1, m_score2);
            }
            else if (IsAdvanture(m_score1, m_score2))
            {
                score = GetAdvantage(m_score1, m_score2);
            }
            else if (IsReadyToWon(m_score1, m_score2))
            {
                score = GetReadyToWon(m_score1, m_score2);
            }
            else
            {
                score = GetInitial(m_score1, m_score2);
            }
            return score;
        }

        private static string GetDeuce(int score1, int score2)
        {
            return "Deuce";
        }

        private static string GetReadyToWon(int score1, int score2)
        {
            return "Win for" + " " + (score1 > score2 ? "player1" : "player2");
        }

        private static string GetAdvantage(int score1, int score2)
        {
            return "Advantage" + " " + (score1 > score2 ? "player1" : "player2");
        }

        private string GetInitial(int score1, int score2)
        {
            string[] scores = new string[] { "Love", "Fifteen", "Thirty", "Forty" };

            if (IsTie(score1, score2))
            {
                return scores[score1] + "-All";
            }

            return scores[score1] + '-' + scores[score2];
        }

        private static bool IsTie(int score1, int score2)
        {
            return score1 == score2;
        }

        private static bool IsDeuce(int score1, int score2)
        {
            return IsTie(score1, score2) && score1 >= 3;
        }

        private static bool IsReadyToWon(int score, int score2)
        {
            return (score >= 4 || score2 >= 4) && Math.Abs(score - score2) >= 2;
        }

        private static bool IsAdvanture(int score, int score2)
        {
            return (score >= 4 || score2 >= 4) && Math.Abs(score - score2) == 1;
        }

    }

    public class TennisPlayer
    {
        public string Name { get; set; }

        public int Score { get; set; }
    }

    ///1. isInitial
    ///2. isDeuce
    ///3. isWon
    ///4. isAdvanture
}

