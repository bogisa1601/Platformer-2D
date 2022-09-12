using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Awake()
    {
        GameController.singleton.CoinAmountText = coinsText;
        
        GameController.singleton.ModifyCoins(0);
    }
}
