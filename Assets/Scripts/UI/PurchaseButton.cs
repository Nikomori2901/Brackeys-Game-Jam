using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PurchaseButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject purchasePopup;
    public int purchaseCost;
    public UnityEvent onPurchase;
    public bool destroy;

    public void Purchase()
    {
        if (PlayerResources.current.money.GetQuantity() >= purchaseCost)
        {
            PlayerResources.current.money.RemoveResource(purchaseCost);
            onPurchase.Invoke();
            
            if (destroy)
            {
                Destroy(gameObject);
            }


            else
            {
                //restock, could be a unity event
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        purchasePopup.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        purchasePopup.SetActive(false);
    }
}