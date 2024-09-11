using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Customer : MonoBehaviour
{
    public int patience = 0;
    public int taskSpeed = 0;
    public Shop.GoodType heldGood = Shop.GoodType.None;

    List<Shop.GoodType> goodTypes = new List<Shop.GoodType>();
    List<float> typeOdds = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DetermineGood()
    {

    }

    private void CheckStations()
    {

    }


}
