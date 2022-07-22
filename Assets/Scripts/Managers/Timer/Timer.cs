using Astroboy.Utils;
using UnityEngine;
using UnityEngine.Events;
using Astroboy.Manager;

namespace Astroboy.Utils.StateMachine
{
    public class Timer : Singleton<Timer>
    {
        [SerializeField] private float _startSeconds = 10;
        [SerializeField] private bool _restartOnFinish = false;

        public GameManager gameManager;

        public bool ShouldReset
        {
            get => _restartOnFinish;
        }


        private float _actualSeconds;

        public float ActualSeconds
        {
            get => _actualSeconds;
            set => _actualSeconds = value;
        }

        [Space(10)]

        public UnityEvent OnTimerEnds;

        #region Timer State Machine
        public StateMachine<Timer> TimerMachine;
        public TimerTickingState TickingState = new TimerTickingState();
        public TimerStoppedState StoppedState = new TimerStoppedState();
        #endregion

        #region Singleton
        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            //Initializing the timer's state machine
            TimerMachine = new StateMachine<Timer>(this);
            //_gameManager = GameManager.Instance;
        }
        #endregion Singleton

        private void Start()
        {
            ActualSeconds = _startSeconds;

            TimerMachine.SetState(TickingState);
        }

        private void Update()
        {
            TimerMachine.CurrentState.TickState(this);
        }

        /// <summary>
        /// Starts the timer with a new StartSeconds value.
        /// </summary>
        /// <param name="newSeconds"></param>
        public void StartTimer(float newSeconds)
        {
            _startSeconds = newSeconds;

            _actualSeconds = _startSeconds;

            TimerMachine.SetState(TickingState);
        }

        /// <summary>
        /// Starts the timer with the value set throught the inspector.
        /// </summary>
        public void StartTimer()
        {
            TimerMachine.SetState(TickingState);
        }

        /// <summary>
        /// Restarts the timer to its initial time.
        /// </summary>
        public void RestartTimer()
        {
            ActualSeconds = _startSeconds;
        }

        public void AddTime(int amount)
        {
            if (ActualSeconds + amount > _startSeconds)
                ActualSeconds = _startSeconds;
            else
                ActualSeconds += amount;
        }
    }
}