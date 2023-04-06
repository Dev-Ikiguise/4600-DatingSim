using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int startingMoney = 10;
    public int money;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Instance = this;
        LoadPlayerMoney();
    }

    void Update()
    {
        
    }

    public void GainMoney(int moneyToGive)
    {
        money += moneyToGive;
    }

    void Die()
    {
        // Handle player death
    }

    void SavePlayerMoney(int money)
    {
        PlayerPrefs.SetInt("PlayerMoney", money);
    }

    int LoadPlayerMoney()
    {
        return PlayerPrefs.GetInt("PlayerMoney", startingMoney);
    }
}
