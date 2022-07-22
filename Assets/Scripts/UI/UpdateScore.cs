using Astroboy.Asteroid;
using UnityEngine;
using TMPro;
using Astroboy.ScoreSystem;
using Astroboy.Utils;

namespace Astroboy.UI
{
    public class UpdateScore : Singleton<UpdateScore>
    {
        [SerializeField] private TextMeshProUGUI _pointsText;

        [SerializeField] public Point _point;

        #region Singleton
        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

        }
        #endregion Singleton

        private void UpdateCoins()
        {
            _pointsText.text = $"{Score.GetScore}";
        }

        public void ResetScore()
        {
            _pointsText.text = $"{0}";
        }

        void OnEnable()
        {
            Point.OnUpdatePoint += UpdateCoins;
        }

        void OnDisable()
        {
            Point.OnUpdatePoint -= UpdateCoins;
        }
    }
}
