using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionItems : MonoBehaviour
{
    private void OnCollsionEnter(Collision col)
    {
        if (col.gameObject.name == "Strength")
        {
            UnityEngine.Object.Destroy(col.gameObject);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
        }
        else if (col.gameObject.name == "Defense")
        {
            UnityEngine.Object.Destroy(col.gameObject);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
        }
        else if (col.gameObject.name == "Speed")
        {
            UnityEngine.Object.Destroy(col.gameObject);
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
        }
        else if (col.gameObject.name == "Psychic")
        {
            UnityEngine.Object.Destroy(col.gameObject);
            PlayerPrefs.SetInt("Pyschic", PlayerPrefs.GetInt("Psychic") + 1);
        }
    }
}
