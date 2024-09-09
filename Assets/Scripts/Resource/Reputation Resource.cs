using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationResource : Resource
{
    public static Action<int> onReputationChange;

    protected override void ResourceChanged()
    {
        onReputationChange(resourceQuantity);
    }
}