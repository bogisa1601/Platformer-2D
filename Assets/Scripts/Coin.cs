using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private int amount;

    public void Collect(Player player)
    {
        GameController.singleton.ModifyCoins(amount);
        Destroy(gameObject); 
    }
}
