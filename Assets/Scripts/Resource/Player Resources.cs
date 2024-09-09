using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using VInspector;

public class PlayerResources : MonoBehaviour
{
    private PlayerResources current;

    // Resources
    public MoneyResource money = new MoneyResource();
    public ReputationResource reputation = new ReputationResource();
    public SecurityResource security = new SecurityResource();

    private void Awake()
    {
        current = this;
        MoneyResource.onMoneyChange += MoneyChanged;
    }

    // Test Methods
    [Button]
    private void AddMoneyTest()
    {
        money.AddResource(1);
    }

    private void MoneyChanged(int quantity)
    {
        Debug.Log("Money Changed - " + quantity);
    }
}