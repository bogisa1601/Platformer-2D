using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController singleton;

    [field: SerializeField] public TextMeshProUGUI CoinAmountText { get; set; }

    public int currentCoinAmount = 0;
    public Player currentActivePlayer;

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
        currentCoinAmount += amount;

        CoinAmountText.text = currentCoinAmount.ToString();
    }
}
