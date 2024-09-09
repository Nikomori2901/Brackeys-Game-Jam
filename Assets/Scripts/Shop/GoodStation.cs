using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using VInspector;

public class GoodStation : MonoBehaviour
{
    [SerializeField] Shop.GoodType goodType;
    [ReadOnly] public int stock = 0;
    [SerializeField] int maxStock = 0;

    [SerializeField] private CustomerArea customerArea;

    [Button]
    public void Restock()
    {
        stock = maxStock;
    }

    public void GrabGood(Customer customer)
    {
        if (HasStock())
        {
            customer.heldGood = Shop.GoodType.None;
            stock -= 1;
        }

        // send customer on way to cashier
    }

    public bool HasStock()
    {
        return stock > 0;
    }

    public void NewCustomer(CustomerArea customerArea)
    {
        Debug.Log("New Cashier Customer");

        StartCoroutine(BrowsingTimer(customerArea.currentCustomer));
    }

    private IEnumerator BrowsingTimer(Customer customer)
    {
        yield return new WaitForSeconds(customer.taskSpeed);

        GrabGood(customer);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
