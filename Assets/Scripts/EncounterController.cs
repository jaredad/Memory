using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterController : MonoBehaviour
{
    //public float startX, startY, startZ;
    private float startX, startY, startZ;
    public GameObject player;
    public AudioSource sound;
    public string scene;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        startX = PlayerPrefs.GetFloat("StartX");
        startY = PlayerPrefs.GetFloat("StartY");
        startZ = PlayerPrefs.GetFloat("StartZ");
        Vector3 playerPosition = new Vector3(startX, startY, startZ);
        player.transform.position = playerPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            PlayerPrefs.SetFloat("StartX", player.transform.position.x);
            PlayerPrefs.SetFloat("StartY", player.transform.position.y);
            PlayerPrefs.SetFloat("StartZ", player.transform.position.z);
            sound.Play();
            SceneManager.LoadScene(scene);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerPrefs.SetFloat("StartX", player.transform.position.x);
            PlayerPrefs.SetFloat("StartY", player.transform.position.y);
            PlayerPrefs.SetFloat("StartZ", player.transform.position.z);
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
}
