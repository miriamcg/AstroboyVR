using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    #region Singleton

    public static SceneManagement instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneManagement>();
            }
            return _instance;
        }
    }
    static SceneManagement _instance;

    void Awake()
    {
        _instance = this;
    }

    #endregion

    public void LoadScene(string name) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }

    public void Exit() {
        Application.Quit();
    }
}
