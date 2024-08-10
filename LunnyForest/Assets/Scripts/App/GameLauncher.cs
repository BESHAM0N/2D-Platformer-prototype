using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameLauncher
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
