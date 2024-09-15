using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    [SerializeField] public CustomerArea customerArea;
    public Customer currentCustomer;
    public List<Customer> customerQueue = new List<Customer>();

    void Start()
    {

    }

    void Update()
    {
        if (customerQueue.Count > 0)
        {
            if (currentCustomer == null)
            {
                NextCustomer();
            }
        }
    }

    public void QueueCustomer(Customer customer)
    {
        Debug.Log("Cashier Queue Customer");
        customer.currentTarget = customerArea;
        customerQueue.Add(customer);
    }

    public void NextCustomer()
    {
        Debug.Log("Cashier Next Customer");
        currentCustomer = customerQueue[0];
        customerQueue.RemoveAt(0);

        //currentCustomer.currentTarget.goodStation.currentCustomer = null;
        
        currentCustomer.Move();
    }

    public void StartCheckout()
    {
        StartCoroutine(CheckoutTimer());
    }
     
    private IEnumerator CheckoutTimer()
    {
        yield return new WaitForSeconds(currentCustomer.taskSpeed);

        Purchase();
    }

    private void Purchase()
    {
        Debug.Log("Cashier Purchase");

        int sellAmount = Shop.current.GetGoodPrice(currentCustomer.goodType);
        PlayerResources.current.money.AddResource(sellAmount);

        currentCustomer.currentTarget = Shop.current.exitLocation;
        currentCustomer.Move();
        currentCustomer = null;
    }
}
