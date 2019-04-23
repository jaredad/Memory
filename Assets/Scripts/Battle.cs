using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    private GameObject obj;
    private GameObject obj2;
    public Enemy enemy;
    public Player player;
    public TextMeshProUGUI char_health;
    public TextMeshProUGUI enemy_health;
    private System.Random random = new System.Random();
    private bool first = true;
    private bool p_turn = true;
    public string scene;




    void Start()
    {
        
        PlayerPrefs.SetString("Action", "");
        char_health.text = PlayerPrefs.GetInt("CurrentHitPoints").ToString() + " / " + PlayerPrefs.GetInt("MaximumHitPoints").ToString();
        enemy_health.text = enemy.health.ToString() + " / " + enemy.max_health.ToString();
    }

    void Update()
    {
        char_health.text = PlayerPrefs.GetInt("CurrentHitPoints").ToString() + " / " + PlayerPrefs.GetInt("MaximumHitPoints").ToString();
        enemy_health.text = enemy.health.ToString() + " / " + enemy.max_health.ToString();
        if (PlayerPrefs.GetInt("Speed") >= enemy.speed && first == true)
        {
            p_turn = true;
            first = false;
        } else if(first)
        {
            p_turn = false;
            first = false;
        }
        first = false;
        if (p_turn)
        {
            UserSelection();
            
        } else
        {
            p_turn = true;
            StartCoroutine(Waiting());
        }
        if (PlayerPrefs.GetInt("CurrentHitPoints") <= 0)
        {
            Debug.Log("You Died");
        }
        if(enemy.health <= 0)
        {
            Debug.Log("You won! You gained " + enemy.exp_given + " EXP!");
            PlayerPrefs.SetInt("ExperiencePoints",PlayerPrefs.GetInt("ExperiencePoints"+ enemy.exp_given));
            SceneManager.LoadScene(scene);
        }
    }

    private void UserSelection()
    {
        Debug.Log(PlayerPrefs.GetString("Action"));
            if(PlayerPrefs.GetString("Action") != "")
            {
                int num = random.Next(10);
                if (PlayerPrefs.GetString("Action") == "Attack")
                {
                    if(num == 1) { enemy.Damage(player.Attack(2)); }
                    else { enemy.Damage(player.Attack(1)); }
                }
                if(PlayerPrefs.GetString("Action") == "Psychic")
                {
                    if (num < 5) { enemy.Damage(player.PsyAttack(2)); }
                    else { enemy.Damage(player.PsyAttack(1)-5); }
                }
                if(PlayerPrefs.GetString("Action") == "Heal")
                {
                    player.Heal(10);
                }
                PlayerPrefs.SetString("Action", "");
                p_turn = false;
            }
        }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2.0f);
        player.Damage(enemy.Attack());
    }
    }
