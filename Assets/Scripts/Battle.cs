using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public GameObject imp;
    public GameObject goblin;
    public GameObject skeleton;
    public GameObject boss1;
    public AudioSource attack;
    public AudioSource p_attack;
    public AudioSource p_heal;
    public GameObject playerHit;
    public GameObject enemyHit;
    public Button a;
    public Button b;
    public Button c;
    public Enemy enemy;
    public Player player;
    public TextMeshProUGUI char_health;
    public TextMeshProUGUI enemy_health;
    private System.Random random = new System.Random();
    private bool first = true;
    private bool p_turn = true;
    public string scene;
    public string gameOverScene;
    private Animator playerAnim;
    private Animator enemyAnim;




    void Start()
    {
        if (PlayerPrefs.GetString("CurrentEnemy").Equals("Imp"))
        {
            imp.SetActive(true);
        }
        else if (PlayerPrefs.GetString("CurrentEnemy").Equals("Goblin"))
        {
            goblin.SetActive(true);
        }
        else if (PlayerPrefs.GetString("CurrentEnemy").Equals("Skeleton"))
        {
            skeleton.SetActive(true);
        } else if (PlayerPrefs.GetString("CurrentEnemy").Equals("Boss"))
        {
            skeleton.SetActive(true);
            skeleton.transform.localScale += new Vector3(2.0F, 2.0f, 2.0f);
        }
        else if (PlayerPrefs.GetString("CurrentEnemy").Equals("Boss1"))
        {
            boss1.SetActive(true);
        }
            PlayerPrefs.SetString("Action", "");
        char_health.text = PlayerPrefs.GetInt("CurrentHitPoints").ToString() + " / " + PlayerPrefs.GetInt("MaximumHitPoints").ToString();
        enemy_health.text = enemy.health.ToString() + " / " + enemy.max_health.ToString();
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        char_health.text = PlayerPrefs.GetInt("CurrentHitPoints").ToString() + " / " + PlayerPrefs.GetInt("MaximumHitPoints").ToString();
        enemy_health.text = enemy.health.ToString() + " / " + enemy.max_health.ToString();
        if (PlayerPrefs.GetInt("Speed") >= enemy.speed && first == true)
        {
            p_turn = true;
            first = false;
        } else if (first)
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
            SceneManager.LoadScene(gameOverScene);
            Debug.Log("You Died");
        }
        if (enemy.health <= 0)
        {
            Debug.Log("You won! You gained " + enemy.exp_given + " EXP!");
            player.Exp(enemy.exp_given);
            Debug.Log(PlayerPrefs.GetInt("ExperiencePoints").ToString());
            SceneManager.LoadScene(scene);
        }
    }

    private void UserSelection()
    {
        Debug.Log(PlayerPrefs.GetString("Action"));
        if (PlayerPrefs.GetString("Action") != "")
        {
            int num = random.Next(10);
            if (PlayerPrefs.GetString("Action") == "Attack")
            {
                attack.Play();
                playerHit.SetActive(true);
                int damageRoll = random.Next(10);
                if (num == 1) { enemy.Damage(player.Attack(2 * damageRoll)); }
                else { enemy.Damage(player.Attack(damageRoll)); }
            }
            if (PlayerPrefs.GetString("Action") == "Psychic")
            {
                p_attack.Play();
                playerHit.SetActive(true);
                int damageRoll = random.Next(10);
                if (num == 1) { enemy.Damage(player.PsyAttack(2 * damageRoll)); }
                else { enemy.Damage(player.PsyAttack(damageRoll)); }
            }
            if (PlayerPrefs.GetString("Action") == "Heal")
            {
                p_heal.Play();
                int healRoll = random.Next(10);
                player.Heal(healRoll + (PlayerPrefs.GetInt("Psychic") / 2));
            }
            PlayerPrefs.SetString("Action", "");
            p_turn = false;
        }
    }

    IEnumerator Waiting()
    {
        a.enabled = false;
        b.enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(2.0f);
        playerHit.SetActive(false);
        player.Damage(enemy.Attack());
        enemyHit.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        enemyHit.SetActive(false);
        a.enabled = true;
        b.enabled = true;
        c.enabled = true;
    }
}
