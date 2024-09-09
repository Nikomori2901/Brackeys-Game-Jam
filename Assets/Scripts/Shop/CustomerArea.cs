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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.TryGetComponent<Customer>(out Customer customer))
        {
            currentCustomer = customer;
            Debug.Log("Customer Enter");
            onCustomerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.TryGetComponent<Customer>(out Customer customer))
        {
            currentCustomer = null;
            Debug.Log("Customer Exit");
            onCustomerExit.Invoke();
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
