using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        LevelManager.Instance.LoadScene(SceneType.Game);
    }
}
