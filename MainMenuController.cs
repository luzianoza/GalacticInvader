using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject selectLevelUI;
    public GameObject creditUI;
    public GameObject settingUI;

    public int levelPassed = 0;

    public bool clearSaveData;
    public bool _isOpen;

    public Button[] levelBtn = new Button[0];

    public void OnStartBtnClick()
    {
        selectLevelUI.SetActive(true);

        if (clearSaveData)
        {
            PlayerPrefs.DeleteAll();
        }

        if (!PlayerPrefs.HasKey("LevelPassed"))
        {
            PlayerPrefs.SetInt("LevelPassed", 0);
            PlayerPrefs.Save();
        }

        levelPassed = PlayerPrefs.GetInt("LevelPassed");

        for (int i = 0; i < levelBtn.Length; i++)
        {
            if (i <= levelPassed)
            {
                levelBtn[i].interactable = true;
            }
            else
            {
                levelBtn[i].interactable = false;

            }
        }
    }

    public void OnBackLevelSelectClick()
    {
        selectLevelUI.SetActive(false);
    }

    public void OnLevelBtnClick(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void BtnOnCreditClick()
    {
        _isOpen = !_isOpen;
        if (_isOpen)
        {
            creditUI.gameObject.SetActive(true);
        }
        else
        {
            creditUI.gameObject.SetActive(false);
        }
    }

    public void OnSettingBtnClick()
    {
        settingUI.SetActive(true);
    }

    public void OnBackSettingClick()
    {
        settingUI.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    
}
