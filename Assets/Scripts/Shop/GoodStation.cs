using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using VInspector;

public class GoodStation : MonoBehaviour
{
    public Shop.GoodType goodType;
    [ReadOnly] public int stock = 0;
    [SerializeField] int maxStock = 0;
    [SerializeField] public CustomerArea customerArea;
    public Customer currentCustomer;
    public GameObject restockButton;

    private void Update()
    {
        if (stock <= 0)
        {
            ShowRestock();
        }

        else
        {

        }
    }

    [Button]
    public void Restock()
    {
        stock = maxStock;
    }

    public void GrabGood()
    {
        Debug.Log("GrabGood");
        if (HasStock())
        {
            currentCustomer.holdingGood = true;
            stock -= 1;
        }

        //Debug.Log("Null Check");
        if (currentCustomer != null)
        {
            Shop.current.cashier.QueueCustomer(currentCustomer);
        }
    }

    public bool HasStock()
    {
        return stock > 0;
    }

    public void CustomerExit()
    {
        currentCustomer = null;
    }

    public void StartBrowsing()
    {
        StartCoroutine(BrowsingTimer());
    }

    private IEnumerator BrowsingTimer()
    {
        yield return new WaitForSeconds(currentCustomer.taskSpeed);

        GrabGood();
    }
    
    public void ShowRestock()
    {
        restockButton.SetActive(true);
    }
}