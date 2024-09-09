using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyResource : Resource
{
    public static Action<int> onMoneyChange;

    protected override void ResourceChanged()
    {
        onMoneyChange(resourceQuantity);
    }
}
