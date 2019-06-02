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
            if (IsSameScore(m_score1, m_score2))  
            {
                score = GetScoreForSameScore(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                score = GetScore(m_score1, m_score2);
            }
            return score;
        }

        private string GetScore(int score1, int score2)
        {
            return GetScoreBySingle(score1) + '-' + GetScoreBySingle(score2);
        }

        private bool IsSameScore(int score1, int score2)
        {
            return score1 == score2;
        }

        private static string GetScoreBySingle(int score)
        {
            string[] scores = new string[] { "Love", "Fifteen", "Thirty", "Forty" };
            return GetScoreWithDefault(scores, string.Empty, score);
        }

        private string GetScoreForSameScore(int score)
        {
            string[] scores = new string[] { "Love-All", "Fifteen-All", "Thirty-All", "Deuce" };
            return GetScoreWithDefault(scores, scores[scores.Length-1], score);
        }

        private static string GetScoreWithDefault(string[] scores, string defaultValue, int score)
        {
            if (scores == null)
                throw new System.ArgumentNullException(nameof(scores));

            if (score >= scores.Length)
                return defaultValue;

            return scores[score];
        }
    }

    public class TennisPlayer
    {
        public string Name { get; set; }

        public int Score { get; set; }
    }
}

