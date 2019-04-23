using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleUIHandler : MonoBehaviour
{

    public Text text1;
    public Text text2;
    public Text text3;

    private void Start()
    {
        StartCoroutine(Waiting(""));
    }
    public void Attack()
    {
        if(text1.text == "Attack") { PlayerPrefs.SetString("Action", "Attack"); }
        if (text1.text == "Psy Attack") { PlayerPrefs.SetString("Action", "Psychic"); }
        if(text1.text == "Item Heal") { PlayerPrefs.SetString("Action", "Heal"); }
        
    }

    public void Psychic()
    {
        
        if (text2.text == "Psychic") {
            StartCoroutine(Waiting("Psychic"));
            
        }
        if(text2.text == "Psy Heal")
        {
            PlayerPrefs.SetString("Action", "Heal");
        }
       
    }

    public void Item()
    {
        if (text3.text == "Item")
        {
            StartCoroutine(Waiting("Item"));
            
        }
        else if(text3.text == "Back")
        {
            StartCoroutine(Waiting("Back"));
        }
        
    }

    IEnumerator Waiting(string n)
    {
        yield return new WaitForSeconds(0.5f);
        if (n == "Psychic")
        {
            text1.text = "Psy Attack";
            text2.text = "Psy Heal";
            text3.text = "Back";
        } else if (n == "Item")
        {
            text1.text = "Item Heal";
            text2.text = "";
            text3.text = "Back";
        } else if (n == "Back")
        {
            text1.text = "Attack";
            text2.text = "Psychic";
            text3.text = "Item";
        }
    }

}
