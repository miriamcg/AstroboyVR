using Astroboy.Utils;
using UnityEngine;

namespace Astroboy.ScoreSystem
{
    public class Score : Singleton<Score>
    {
        private int _score;
        public static int GetScore
        {
            get => Instance._score;
            set => Instance._score = value;
        }

        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }

        public static void AddScore(int amount) => GetScore += amount;
    }
}
