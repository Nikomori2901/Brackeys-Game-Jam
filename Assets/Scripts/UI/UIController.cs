using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    List<GameObject> restockButtons = new List<GameObject>();
    List<GameObject> purchaseButtons = new List<GameObject>();

    // Depending on game stae hides or displays ui
    // displays restocks if station has already been purchassed and stock is lower than maximum
    // OPTIONAL IF HAVE TIME: adjusts price and ui of restock based on how much stock its restocking.

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
