using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIlogic : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    [SerializeField] private Animator _animatorHomeButton;
    [SerializeField] private Animator _animatorRestartButton;

    // 0 = false || 1 = true
    private int _wasPresedRestart;
    private int _onFinish;

    private void Start()
    {

        _wasPresedRestart = (PlayerPrefs.HasKey("WasPressed") ? PlayerPrefs.GetInt("WasPressed") : 0);
        _onFinish = (PlayerPrefs.HasKey("Finish") ? PlayerPrefs.GetInt("Finish") : 0);

        if(_wasPresedRestart == 1 || _onFinish == 1)
        {
            Time.timeScale = 1;

            _startButton.SetActive(false);

            _animatorHomeButton.SetTrigger("ShowHomeButton");
            _animatorRestartButton.SetTrigger("ShowRestartButton");

            _wasPresedRestart = 0;
            _onFinish = 0;
            PlayerPrefs.SetInt("Finish", _onFinish);
            PlayerPrefs.SetInt("WasPressed", _wasPresedRestart);
        }
    }

    public void OnClickStart()
    {
        _startButton.SetActive(false);

        _animatorHomeButton.SetTrigger("ShowHomeButton");
        _animatorRestartButton.SetTrigger("ShowRestartButton");
    }

    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void OnClickRestart()
    {
        _wasPresedRestart = 1;

        PlayerPrefs.SetInt("WasPressed", _wasPresedRestart);
        SceneManager.LoadScene(0);
    }
}
