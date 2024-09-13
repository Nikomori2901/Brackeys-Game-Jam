using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class Shop : MonoBehaviour
{
    public static Shop current;

    public Vector2 cashierLocation;
    public Vector2 entranceLocation;

    public int snackPrice, drinkPrice, homePrice, trinketPrice, expensivePrice;

    public GameObject customerPrefab;

    public List<GoodStation> goodStations = new List<GoodStation>();

    public GoodStation secondSnackStation;

    public enum GoodType
    {
        None, Snack, Drink, Home, Trinket, Expensive
    }

    private void Awake()
    {
        current = this;
    }

    public int GetGoodPrice(GoodType goodType)
    {
        switch (goodType)
        {
            case Shop.GoodType.Snack:
                return snackPrice;
            case Shop.GoodType.Drink:
                return drinkPrice;
            case Shop.GoodType.Home:
                return homePrice;
            case Shop.GoodType.Trinket:
                return trinketPrice;
            case Shop.GoodType.Expensive:
                return expensivePrice;
            default:
                return 0;
        }
    }

    [Button]
    void SpawnCustomer()
    {
        Instantiate(customerPrefab, entranceLocation, Quaternion.identity);
    }

    public void PurchaseSnackStation()
    {
        secondSnackStation.gameObject.SetActive(true);
        goodStations.Add(secondSnackStation);
    }
}
