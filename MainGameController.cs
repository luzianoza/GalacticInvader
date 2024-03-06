using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainGameController : MonoBehaviour
{
    //Singleton
    public static MainGameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public int gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            goldText.text = "" + _gold;
        }
    }
    public int life
    {
        get { return _life; }
        set
        {
            _life = value;
            lifeText.text = "life : " + _life;
            if (life == 0)
            {
                loseSecenUI.SetActive(true);
                isEndGame = true;
                loseSound.Play();
            }
        }
    }

    public int enemyCount
    {
        get { return _enemyCount; }
        set
        {
            _enemyCount = value;
            if (_enemyCount == 0 && enemySpawner1.isWaveEnd && enemySpawner2.isWaveEnd)
            {
                //show WinUI
                victorySecenUI.SetActive(true);
                victorySound.Play();
                isEndGame = true;
                PlayerPrefs.SetInt("LevelPassed", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }
        }
    }

    public int _gold = 100;
    public int _life = 10;
    private int _enemyCount = 0;

    public TMP_Text goldText;
    public TMP_Text lifeText;

    public bool isEndGame = false;

    public EnemySpawner enemySpawner1;
    public EnemySpawner enemySpawner2;


    public GameObject victorySecenUI;
    public GameObject loseSecenUI;
    public GameObject settingUI;
    public GameObject _playUI;
    public GameObject _pauseUI;

    public AudioSource victorySound;
    public AudioSource loseSound;

    public NodeUIController nodeUI;


    public void OnRetryBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackMainMenuBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNextLevelBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void OnSettingBtnClick()
    {
        settingUI.SetActive(true);
    }

    public void OnBackSettingClick()
    {
        settingUI.SetActive(false);
    }

    public void OnPauseBTNClick()
    {
        _playUI.SetActive(true);
        _pauseUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OnPlayBTNClick()
    {
        _playUI.SetActive(false);
        _pauseUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OnChangeSpeedBtnClick()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
