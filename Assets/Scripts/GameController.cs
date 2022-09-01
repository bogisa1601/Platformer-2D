using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    [SerializeField] private TextMeshProUGUI coinAmountText;
    
    
    private int _currentCoinAmount = 0;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        ModifyCoins(0);
    }

    public void ModifyCoins(int amount)
    {
        _currentCoinAmount += amount;

        coinAmountText.text = _currentCoinAmount.ToString();
    }
}
