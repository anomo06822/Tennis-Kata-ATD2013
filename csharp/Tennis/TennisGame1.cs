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
        private Dictionary<int, string> scoreDic = new Dictionary<int, string>()
        {
            { 0, "Love" },
            { 1, "Fifteen"},
            { 2, "Thirty"},
            { 3, "Forty"}
        };

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
            List<KeyValuePair<Func<bool>, Func<string>>>handles = new List<KeyValuePair<Func<bool>, Func<string>>>()
            {
                new KeyValuePair<Func<bool>, Func<string>>(IsDeuce, GetDeuce),
                new KeyValuePair<Func<bool>, Func<string>>(IsAdvantage, GetAdvantage),
                new KeyValuePair<Func<bool>, Func<string>>(IsWin, GetWin),
                new KeyValuePair<Func<bool>, Func<string>>(IsInitial, GetNormalScore),
            };

            foreach(var handle in handles)
            {
                if (handle.Key())
                {
                    return handle.Value();
                }
            }

            return string.Empty;
        }

        private bool IsInitial() => true;

        private bool IsDeuce() => IsSameScore() && m_score1 >= 3;
        private bool IsSameScore() => m_score1 == m_score2;
        private bool IsAdvantage() => IsReadyToWin() && AbsScore() == 1;
        private bool IsWin() => IsReadyToWin() && AbsScore() >= 2;
        private bool IsReadyToWin() => m_score1 >= 4 || m_score2 >= 4;

        private static string GetDeuce() => "Deuce";
        private string GetAdvantage() => $"Advantage { GetPlayer() }";
        private string GetWin() => $"Win for { GetPlayer() }";
        private string GetPlayer() => (m_score1 - m_score2 > 0 ? "player1" : "player2");
        private string GetNormalScore() => IsSameScore() ? GetPlayerScore(m_score1) + "-All" : $"{ GetPlayerScore(m_score1) }-{ GetPlayerScore(m_score2) }";
        private string GetPlayerScore(int tempScore) => scoreDic[tempScore];

        private int AbsScore() => System.Math.Abs(m_score1 - m_score2);
    }
}

