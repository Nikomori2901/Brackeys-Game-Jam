using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void DestroyCustomer(CustomerArea area)
    {
        if (area.currentCustomer.currentTarget == area)
        {
            area.currentCustomer.Despawn();
        }

        Shop.current.SpawnCustomer();
    }
}
