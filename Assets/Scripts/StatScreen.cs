using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatScreen : MonoBehaviour
{
    public TextMeshProUGUI type;
    public TextMeshProUGUI level;
    public TextMeshProUGUI exp;
    public TextMeshProUGUI health;
    public TextMeshProUGUI str;
    public TextMeshProUGUI def;
    public TextMeshProUGUI psy;
    public TextMeshProUGUI spd;


    // Start is called before the first frame update
    void Start()
    {
        type.text = PlayerPrefs.GetString("type");
        level.text = "Level: " + PlayerPrefs.GetInt("Level").ToString();
        exp.text = "EXP: " + PlayerPrefs.GetInt("ExperiencePoints").ToString();
        health.text = "Health: " + PlayerPrefs.GetInt("CurrentHitPoints").ToString() + " / " + PlayerPrefs.GetInt("MaximumHitPoints");
        str.text = "STR: " + PlayerPrefs.GetInt("Strength").ToString();
        def.text = "DEF: " + PlayerPrefs.GetInt("Defense").ToString();
        psy.text = "PSY: " + PlayerPrefs.GetInt("Psychic").ToString();
        spd.text = "SPD: " + PlayerPrefs.GetInt("Speed").ToString();
    }
}
