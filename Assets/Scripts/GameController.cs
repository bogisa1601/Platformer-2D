using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    [field: SerializeField] public TextMeshProUGUI CoinAmountText { get; set; }

    private int _currentCoinAmount = 0;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    public void ModifyCoins(int amount)
    {
        _currentCoinAmount += amount;

        CoinAmountText.text = _currentCoinAmount.ToString();
    }
}
