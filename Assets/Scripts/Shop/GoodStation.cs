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

    [Button]
    public void Restock()
    {
        stock = maxStock;
    }

    public void GrabGood(Customer customer)
    {
        if (HasStock())
        {
            customer.holdingGood = true;
            stock -= 1;
        }

        Debug.Log("Null Check");
        if (customer != null)
        {
            
            customer.MoveTo(Shop.current.cashierLocation);
        }
    }

    public bool HasStock()
    {
        return stock > 0;
    }

    public void NewCustomer(CustomerArea customerArea)
    {
        Debug.Log("New Customer");

        StartCoroutine(BrowsingTimer(customerArea.currentCustomer));
    }

    private IEnumerator BrowsingTimer(Customer customer)
    {
        yield return new WaitForSeconds(customer.taskSpeed);

        GrabGood(customer);
    }

    private void OnMouseEnter()
    {
        //show popup
    }

    private void OnMouseExit()
    {
        //show game
    }
}