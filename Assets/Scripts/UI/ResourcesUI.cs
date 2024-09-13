using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    public TMP_Text moneyAmount;
    public TMP_Text reputationAmount;
    public TMP_Text securityAmount;

    void Start()
    {
        MoneyResource.onMoneyChange += UpdateMoney;
        ReputationResource.onReputationChange += UpdateReputation;
        SecurityResource.onSecurityChange += UpdateSecurity;

        SetAmounts();
    }

    public void SetAmounts()
    {
        UpdateMoney(PlayerResources.current.money.GetQuantity());
        UpdateReputation(PlayerResources.current.reputation.GetQuantity());
        UpdateSecurity(PlayerResources.current.security.GetQuantity());
    }

    private void UpdateMoney(int quantity)
    {
        moneyAmount.text = quantity.ToString();
    }

    private void UpdateReputation(int quantity)
    {
        reputationAmount.text = quantity.ToString();
    }

    private void UpdateSecurity(int quantity)
    {
        securityAmount.text = quantity.ToString();
    }
}
