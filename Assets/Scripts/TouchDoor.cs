using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDoor : MonoBehaviour
{
    public string scene;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetString("CurrentEnemy", "Boss1");
            SceneManager.LoadScene("Battle");
        }
        
    }
}
