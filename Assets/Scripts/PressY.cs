using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressY : MonoBehaviour
{
    public AudioSource sound;
    public string scene;

    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            sound.Play();
            SceneManager.LoadScene(scene);
        }
    }
}
