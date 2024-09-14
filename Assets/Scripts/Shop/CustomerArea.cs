using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerArea : MonoBehaviour
{
    BoxCollider2D collisionArea;
    public Customer currentCustomer { get; set; }

    [SerializeField] public UnityEvent onCustomerEnter;
    [SerializeField] public UnityEvent onCustomerExit;

    void Start()
    {
        collisionArea = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.TryGetComponent<Customer>(out Customer customer))
        {
            if (customer.currentTarget == this && !HasCustomer())
            {
                currentCustomer = customer;
                Debug.Log("Customer Enter");
                onCustomerEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(other.gameObject.name);
        if (collision.gameObject.TryGetComponent<Customer>(out Customer customer))
        {
            if (customer.currentTarget == this)
            {
                currentCustomer = null;
                Debug.Log("Customer Exit");
                onCustomerExit.Invoke();
            }
        }
    }

    public bool HasCustomer()
    {
        return currentCustomer != null;
    }

    public Vector2 GetPosition()
    {
        return (Vector2)gameObject.transform.position;
    }
}