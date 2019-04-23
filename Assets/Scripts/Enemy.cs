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

    public Enemy(string n)
    {
        List<int> values = EnemyType(n);
        max_health = values[0];
        health = values[0];
        attack = values[1];
        speed = values[2];
        exp_given = values[3];
        id = n;
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
        if (n == "imp")
        {
            list.Add(20);
            list.Add(10);
            list.Add(9);
            list.Add(10);
        }
        //create other if characters

        return list;
    }
}
