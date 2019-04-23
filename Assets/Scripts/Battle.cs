using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private Enemy enemy;
    private Player player;

    public Battle(string enemy_name)
    {
        enemy = new Enemy(enemy_name);
        player = new Player();
    }

    public int game_loop()
    {
        bool first = true;
        while (PlayerPrefs.GetInt("CurrentHealthPoints") > 0 || enemy.health > 0)
        {
            if (PlayerPrefs.GetInt("Speed") >= enemy.speed && first == true)
            {
                //wait for user selection
                first = false;
            }
            else
            {
                player.Damage(enemy.Attack());
                first = false;
            }
            //wait for user selection
            if (enemy.health > 0)
            {
                player.Damage(enemy.Attack());
            }
        }
        if (PlayerPrefs.GetInt("CurrentHealthPoints") < 0)
        {
            Debug.Log("You Died");
            return 0;
        }
        else
        {
            Debug.Log("You won! You gained " + enemy.exp_given + " EXP!");
            return enemy.exp_given;
        }
    }
}
