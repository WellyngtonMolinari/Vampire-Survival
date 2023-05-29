using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;
    
    private void Awake()
    {
        instance = this;
    }

    public int currentCoins;

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
    }
}