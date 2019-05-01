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
<<<<<<< HEAD

=======
            PlayerPrefs.SetString("CurrentEnemy", "Boss");
            SceneManager.LoadScene("Battle");
>>>>>>> 65128e1fb1117df4d2bfbb460aa38373736c9b79
        }
        
    }
}
