using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            PlayerPrefs.SetString("CurrentEnemy", "Boss");
            SceneManager.LoadScene("Battle");

        }
        
    }
}
