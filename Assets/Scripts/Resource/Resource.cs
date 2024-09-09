using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource
{
    protected int resourceQuantity = 0;

    public void AddResource(int quantity)
    {
        resourceQuantity += quantity;
        ResourceChanged();
    }

    public void SetResource(int quantity)
    {
        resourceQuantity = quantity;
        ResourceChanged();
    }

    public void RemoveResource(int quantity)
    {
        resourceQuantity -= quantity;
        ResourceChanged();
    }

    public int GetQuantity()
    {
        return resourceQuantity;
    }

    protected virtual void ResourceChanged()
    {

    }
}
