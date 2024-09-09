using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    [SerializeField] private CustomerArea customerArea;
    [SerializeField] private bool occupied;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void NewCustomer(CustomerArea customerArea)
    {
        Debug.Log("New Cashier Customer");
        occupied = true;
        StartCoroutine(CheckoutTimer(customerArea.currentCustomer));
    }

    private IEnumerator CheckoutTimer(Customer customer)
    {
        yield return new WaitForSeconds(customer.taskSpeed);

        Purchase(customer);
    }

    private void Purchase(Customer customer)
    {
        Debug.Log("Cashier Purchase");

        int sellAmount = Shop.current.GetGoodPrice(customer.heldGood);
        PlayerResources.current.money.AddResource(sellAmount);

        customer.heldGood = Shop.GoodType.None;


        // send them to leave

        occupied = false;
    }
}
