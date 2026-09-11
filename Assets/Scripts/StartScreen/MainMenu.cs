using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private GameObject _page1Text;
    [SerializeField] private GameObject _page2Text;


    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Debug.Log("게임 종료 버튼 클릭");
        Application.Quit();
    }


    public void OpenInfo()
    {
        _infoPanel.SetActive(true);
        _page1Text.SetActive(true);
        _page2Text.SetActive(false);
    }

    public void CloseInfo()
    {
        _infoPanel.SetActive(false);
    }

    public void NextInfo()
    {
        _page1Text.SetActive(false);
        _page2Text.SetActive(true);
    }

}   