using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void CreateQuickChar()
    {
        PlayerPrefs.SetInt("CurrentHitPoints", 50);
        PlayerPrefs.SetInt("MaximumHitPoints", 50);
        PlayerPrefs.SetInt("ExperiencePoints", 0);
        PlayerPrefs.SetInt("LevelUpGoal", 50);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Strength", 8);
        PlayerPrefs.SetInt("Defense", 10);
        PlayerPrefs.SetInt("Psychic", 8);
        PlayerPrefs.SetInt("Speed", 12);
        PlayerPrefs.SetFloat("StartX", 408f);
        PlayerPrefs.SetFloat("StartY", 0f);
        PlayerPrefs.SetFloat("StartZ", 175f);
        PlayerPrefs.SetString("type", "Quick");
    }

    public void CreateStrongChar()
    {
        PlayerPrefs.SetInt("CurrentHitPoints", 50);
        PlayerPrefs.SetInt("MaximumHitPoints", 50);
        PlayerPrefs.SetInt("ExperiencePoints", 0);
        PlayerPrefs.SetInt("LevelUpGoal", 50);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Strength", 12);
        PlayerPrefs.SetInt("Defense", 10);
        PlayerPrefs.SetInt("Psychic", 8);
        PlayerPrefs.SetInt("Speed", 8);
        PlayerPrefs.SetFloat("StartX", 408f);
        PlayerPrefs.SetFloat("StartY", 0f);
        PlayerPrefs.SetFloat("StartZ", 175f);
        PlayerPrefs.SetString("type", "Strong");
    }

    public void CreateDefChar()
    {
        PlayerPrefs.SetInt("CurrentHitPoints", 50);
        PlayerPrefs.SetInt("MaximumHitPoints", 50);
        PlayerPrefs.SetInt("ExperiencePoints", 0);
        PlayerPrefs.SetInt("LevelUpGoal", 50);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Strength", 10);
        PlayerPrefs.SetInt("Defense", 12);
        PlayerPrefs.SetInt("Psychic", 8);
        PlayerPrefs.SetInt("Speed", 8);
        PlayerPrefs.SetFloat("StartX", 408f);
        PlayerPrefs.SetFloat("StartY", 0f);
        PlayerPrefs.SetFloat("StartZ", 175f);
        PlayerPrefs.SetString("type", "Defense");
    }

    public void CreatePsychicChar()
    {
        PlayerPrefs.SetInt("CurrentHitPoints", 50);
        PlayerPrefs.SetInt("MaximumHitPoints", 50);
        PlayerPrefs.SetInt("ExperiencePoints", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("LevelUpGoal", 50);
        PlayerPrefs.SetInt("Strength", 8);
        PlayerPrefs.SetInt("Defense", 8);
        PlayerPrefs.SetInt("Psychic", 12);
        PlayerPrefs.SetInt("Speed", 10);
        PlayerPrefs.SetFloat("StartX", 408f);
        PlayerPrefs.SetFloat("StartY", 0f);
        PlayerPrefs.SetFloat("StartZ", 175f);
        PlayerPrefs.SetString("type", "Psychic");
    }

    public int Attack(int damageRoll)
    {
        return damageRoll + (PlayerPrefs.GetInt("Strength") / 2);
    }

    public int PsyAttack(int damageRoll)
    {
        return damageRoll + (PlayerPrefs.GetInt("Psychic") / 2);
    }

    public void Damage(int attack)
    {
        int temp = attack - PlayerPrefs.GetInt("Defense");
        Debug.Log(temp);
        if (temp < 0)
        {
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("CurrentHitPoints") - 1);
        }
        else
        {
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("CurrentHitPoints") - temp);
        }
    }

    public void Heal(int points)
    {
            if (PlayerPrefs.GetInt("CurrentHitPoints") + points >= PlayerPrefs.GetInt("MaximumHitPoints"))
            {
                
                PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("MaximumHitPoints"));
            }
            else
            {
                PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("CurrentHitPoints") + points);
            }
    }

    public void Exp(int points)
    {
        PlayerPrefs.SetInt("ExperiencePoints", PlayerPrefs.GetInt("ExperiencePoints") + points);
        LevelCheck();
    }

    public void LevelCheck()
    {
            if (PlayerPrefs.GetInt("ExperiencePoints") > PlayerPrefs.GetInt("LevelUpGoal"))
            {
                PlayerPrefs.SetInt("LevelUpGoal", PlayerPrefs.GetInt("LevelUpGoal") * 2);
                PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
                LevelUp();
            }
    }

    public void LevelUp()
    {
        if (PlayerPrefs.GetString("type") == "Quick")
        {
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 2);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
            PlayerPrefs.SetInt("Psychic", PlayerPrefs.GetInt("Psychic") + 1);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
            PlayerPrefs.SetInt("MaximumHitPoints", PlayerPrefs.GetInt("MaximumHitPoints") + 10);
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("MaximumHitPoints"));
        }
        else if(PlayerPrefs.GetString("type") == "Strong")
        {
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 2);
            PlayerPrefs.SetInt("Psychic", PlayerPrefs.GetInt("Psychic") + 1);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
            PlayerPrefs.SetInt("MaximumHitPoints", PlayerPrefs.GetInt("MaximumHitPoints") + 10);
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("MaximumHitPoints"));
        }
        else if (PlayerPrefs.GetString("type") == "Defense")
        {         
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
            PlayerPrefs.SetInt("Psychic", PlayerPrefs.GetInt("Psychic") + 1);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 2);
            PlayerPrefs.SetInt("MaximumHitPoints", PlayerPrefs.GetInt("MaximumHitPoints") + 10);
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("MaximumHitPoints"));
        }
        else if (PlayerPrefs.GetString("type") == "Psychic")
        {
            PlayerPrefs.SetInt("Speed", PlayerPrefs.GetInt("Speed") + 1);
            PlayerPrefs.SetInt("Strength", PlayerPrefs.GetInt("Strength") + 1);
            PlayerPrefs.SetInt("Psychic", PlayerPrefs.GetInt("Psychic") + 1);
            PlayerPrefs.SetInt("Defense", PlayerPrefs.GetInt("Defense") + 1);
            PlayerPrefs.SetInt("MaximumHitPoints", PlayerPrefs.GetInt("MaximumHitPoints") + 10);
            PlayerPrefs.SetInt("CurrentHitPoints", PlayerPrefs.GetInt("MaximumHitPoints"));
        }
    }
}
