using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource
{
    protected int resourceQuantity;

    public void AddResource(int quantity)
    {
        resourceQuantity += quantity;
    }

    public void SetResource(int quantity)
    {
        resourceQuantity = quantity;
    }

    public void RemoveResource(int quantity)
    {
        resourceQuantity -= quantity;
    }

    public int GetQuantity()
    {
        return resourceQuantity;
    }

    protected virtual void ResourceChanged()
    {

    }
}
