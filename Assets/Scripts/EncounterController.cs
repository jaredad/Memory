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
        startx = float.Parse(PlayerPrefs.GetString("StartX"));
        starty = float.Parse(PlayerPrefs.GetString("StartY"));
        startz = float.Parse(PlayerPrefs.GetString("StartZ"));
        Vector3 playerPosition = new Vector3(startx, starty, startz);
        player.transform.position = playerPosition;
    }

    // Update is called once per frame
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
    }

    void setupEncounter()
    {
        //Move the player and instantiate the enemy.
        //We can save the player's previous position through PlayerPrefs 
        //and have them placed where they were before the fight after the battle concludes.
    }
}
