using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationResource : Resource
{
    public static Action onReputationChange;

    protected override void ResourceChanged()
    {
        onReputationChange();
    }
}