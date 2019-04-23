using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PressA : MonoBehaviour
{
    public AudioSource sound;
    public string scene;

    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            sound.Play();
            SceneManager.LoadScene(scene);
        }
    }
}