using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterController : MonoBehaviour
{
    public GameObject player;
    public AudioSource sound;
    public string scene;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        float startx, starty, startz;
        startx = 407.45f;
        starty = 0.0f;
        startz = 216.4f;
        Vector3 playerPosition = new Vector3(startx, starty, startz);
        player.transform.position = playerPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            PlayerPrefs.SetString("StartX", obj.transform.position.x.ToString());
            PlayerPrefs.SetString("StartY", obj.transform.position.y.ToString());
            PlayerPrefs.SetString("StartZ", obj.transform.position.z.ToString());
            sound.Play();
            SceneManager.LoadScene(scene);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetString("StartX", player.transform.position.x.ToString());
            PlayerPrefs.SetString("StartY", player.transform.position.y.ToString());
            PlayerPrefs.SetString("StartZ", player.transform.position.z.ToString());
            PlayerPrefs.SetString("CurrentEnemy", collision.gameObject.name);
            SceneManager.LoadScene("Battle");
        }
        if (collision.gameObject.name == "Strength")
        {
            UnityEngine.Object.Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
        }
        else if (collision.gameObject.name == "Defense")
        {
            UnityEngine.Object.Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
        }
        else if (collision.gameObject.name == "Speed")
        {
            Debug.Log(PlayerPrefs.GetInt("Speed"));
            UnityEngine.Object.Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
            Debug.Log(PlayerPrefs.GetInt("Speed"));
        }
        else if (collision.gameObject.name == "Psychic")
        {
            UnityEngine.Object.Destroy(collision.gameObject);
            PlayerPrefs.SetInt("Pyschic", PlayerPrefs.GetInt("Psychic") + 1);
        }
    }

    void setupEncounter()
    {
        //Move the player and instantiate the enemy.
        //We can save the player's previous position through PlayerPrefs 
        //and have them placed where they were before the fight after the battle concludes.
    }
}
