using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    public string scene;
    public Player player;

    public void Quick()
    {
        Debug.Log("quick");
        player.CreateQuickChar();
        SceneManager.LoadScene(scene);
    }

    public void Strength()
    {
        Debug.Log("strong");
        player.CreateStrongChar();
        SceneManager.LoadScene(scene);
    }

    public void Defense()
    {
        Debug.Log("defense");
        player.CreateDefChar();
        SceneManager.LoadScene(scene);
    }

    public void Pyschic()
    {
        Debug.Log("psychic");
        player.CreatePsychicChar();
        SceneManager.LoadScene(scene);
    }
}

