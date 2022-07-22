using Astroboy.Utils.StateMachine;
using UnityEngine;
using TMPro;
using Astroboy.Utils;

namespace Astroboy.UI
{
    public class UpdateTimer : Singleton<UpdateTimer>
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private Timer _timer;

        private string secondsLeft;

        #region Singleton
        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

        }
        #endregion Singleton

        private void Start()
        {
            _timer = Timer.Instance;
        }

        void Update()
        {
            UpdateText();
        }

        public void ResetTime()
        {
            Debug.Log(_timer.ActualSeconds);
            UpdateText();
        }

        private void UpdateText()
        {
            if ((int)_timer.ActualSeconds >= 10)
            {
                secondsLeft = "00:";
            }
            else if ((int)_timer.ActualSeconds < 10)
            {
                secondsLeft = "00:0";
            }
            _timerText.text = secondsLeft + ((int)_timer.ActualSeconds).ToString();
        }
    }
}
