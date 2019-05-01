using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int max_health;
    public int health;
    public int attack;
    public int speed;
    public int exp_given;
    public string id;

    void Start()
    {
        List<int> values = EnemyType(PlayerPrefs.GetString("CurrentEnemy"));
        max_health = values[0];
        health = values[0];
        attack = values[1];
        speed = values[2];
        exp_given = values[3];
        id = PlayerPrefs.GetString("CurrentEnemy");
    }

    public int Attack()
    {
        return attack;
    }

    public void Damage(int points)
    {
        health -= points;
    }

    public List<int> EnemyType(string n)
    {
        List<int> list = new List<int> { };
        if (n == "Imp")
        {
            list.Add(20);
            list.Add(15);
            list.Add(10);
            list.Add(10);
        }
        if (n == "Goblin")
        {
            list.Add(25);
            list.Add(20);
            list.Add(15);
            list.Add(15);
        }
        if (n == "Skeleton")
        {
            list.Add(30);
            list.Add(10);
            list.Add(20);
            list.Add(15);
        }
        if (n == "Boss1")
        {
            list.Add(75);
            list.Add(30);
            list.Add(35);
            list.Add(50);
        }
        //create other if characters

        return list;
    }
}
