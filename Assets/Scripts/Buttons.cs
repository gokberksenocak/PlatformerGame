using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ResumeGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}