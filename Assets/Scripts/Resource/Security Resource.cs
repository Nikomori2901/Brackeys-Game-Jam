using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SecurityResource : Resource
{
    public static Action<int> onSecurityChange;

    protected override void ResourceChanged()
    {
        onSecurityChange(resourceQuantity);
    }
}
