using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Astroboy.Utils.StateMachine;
using Astroboy.Utils;
using Astroboy.Player;
using Astroboy.Asteroid;
using Astroboy.UI;

namespace Astroboy.Manager{
    public class GameManager : Singleton<GameManager>
    {
        #region GM State Machine
        public StateMachine<GameManager> GameManagerMachine;
        public InLoadingState LoadingState = new InLoadingState();
        public InGameState InGameState = new InGameState();
        public InPauseState InPauseState = new InPauseState();
        public InMenuState InMenuState = new InMenuState();
        public InWingameState InWingameState = new InWingameState();
        #endregion

        public GameObject FinishPanel;
        [SerializeField] private Timer _timer;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] public GameObject _triggers;

        private static UpdateScore _updateScore;

        public UnityEvent OnGameLose;

        //public bool CanPause = true;

        public bool IsLoading
        {
            get => GameManagerMachine.CurrentState == LoadingState;
        }

        public float InitialTimeScale
        {
            get;
            set;
        }

        protected override void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(this.gameObject);
            else
            {
                Instance = this;
                //DontDestroyOnLoad(this.gameObject);

                //Initializing Game Manager State Machine.
                GameManagerMachine = new StateMachine<GameManager>(this);

                GameManagerMachine.SetState(InMenuState);

                InitialTimeScale = .8f;
                FinishPanel.SetActive(false);
            }
        }

        private void Start()
        {
            Time.timeScale = InitialTimeScale;

            _updateScore = UpdateScore.Instance;
            _triggers.SetActive(false);
        }

        /// <summary>
        /// Loose the game.
        /// </summary>
        public void GameLoose()
        {
            FinishPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        private void Update()
        {
            GameManagerMachine.CurrentState.TickState(this);
        }

        public void LoadScene(string sceneName) => StartCoroutine(LoadLevelAsync(sceneName));

        /// <summary>
        /// Loads the given scene asynchronous.
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        private IEnumerator LoadLevelAsync(string sceneName)
        {
            GameManagerMachine.SetState(LoadingState);

            yield return new WaitForSecondsRealtime(1f);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            GameManagerMachine.SetState(InMenuState);
        }

        /// <summary>
        /// Set the game to win state.
        /// </summary>
        public void WinGame()
        {
            //Player.gameObject.SetActive(false);
            GameManagerMachine.SetState(InWingameState);
        }

        public void ResetGame()
        {
            FinishPanel.SetActive(false);

            //Reset the player life - counter and UI
            _playerHealth.ResetLife();

            //Reset the score
            ScoreSystem.Score.GetScore = 0;
            _updateScore.ResetScore();

            //Disable triggers
            _triggers.SetActive(false);

            //Init the time again
            Time.timeScale = InitialTimeScale;
        }
    }
}