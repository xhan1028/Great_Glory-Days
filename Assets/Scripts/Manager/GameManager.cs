using System;
using Cinema;
using Load;
using Load.Scenes;
using ScreenEffect;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
  public class GameManager : SingleTon<GameManager>, IDontDestroy
  {
    [SerializeField]
    private GameObject optionPanel;
    
    public void Die(string retryScene)
    {
      SceneLoader.Instance.Load("Die", null, null, () => FindObjectOfType<Die>().retryScene = retryScene);
    }

    public void Die()
    {
      var sceneName = SceneManager.GetActiveScene().name;
      SceneLoader.Instance.Load("Die", null, null, () => FindObjectOfType<Die>().retryScene = sceneName);
    }

    public void GoToMain()
    {
      ToggleOptionPanel();
      SceneLoader.Instance.Load("Title_Main");
    }

    public void ToggleOptionPanel()
    {
      Time.timeScale = optionPanel.activeSelf ? 1f : 0f;
      optionPanel.SetActive(!optionPanel.activeSelf);
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
        ToggleOptionPanel();
    }
  }
}
