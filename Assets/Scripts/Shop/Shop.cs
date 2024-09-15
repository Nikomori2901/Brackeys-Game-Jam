using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class Shop : MonoBehaviour
{
    public static Shop current;

    public GameObject customerPrefab;

    public GameObject snackCustomer, drinkCustomer, homeCustomer, trinketCustomer, expensiveCustomer;

    public List<Customer> customerQueue = new List<Customer>();

    public List<GoodType> typesToCheck = new List<GoodType>();
    public List<GoodStation> goodStations = new List<GoodStation>();

    public Cashier cashier;
    public CustomerArea exitLocation;

    public int snackPrice, drinkPrice, homePrice, trinketPrice, expensivePrice;

    public GoodStation secondSnackStation;
    public GoodStation drinkStation;
    public GoodStation trinketStation;
    public GoodStation homeStation;
    public GoodStation expensiveStation;

    public enum GoodType
    {
        None, Snack, Drink, Home, Trinket, Expensive
    }

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        StartCoroutine(CheckAvailable());
        Shop.current.SpawnCustomer();
    }

    #region Customer Spawning Process

    [Button]
    public void SpawnCustomer() // Spawn Customer
    {
        int rand = Random.Range(0, 4);
        Customer spawnedCustomer;
        switch (rand)
        {
            case 0:
                spawnedCustomer = Instantiate(snackCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
            case 1:
                spawnedCustomer = Instantiate(drinkCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
            case 2:
                spawnedCustomer = Instantiate(homeCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
            case 3:
                spawnedCustomer = Instantiate(trinketCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
            case 4:
                spawnedCustomer = Instantiate(expensiveCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
            default:
                spawnedCustomer = Instantiate(snackCustomer, exitLocation.transform.position, Quaternion.identity).GetComponent<Customer>();
                break;
        }
        CustomerQueueAdd(spawnedCustomer);
    }

    private void CustomerQueueAdd(Customer customer) // Add To Customer Queue
    {
        customerQueue.Add(customer);

        if (!typesToCheck.Contains(customer.goodType))
        {
            typesToCheck.Add(customer.goodType);
        }
    }

    private void CustomerQueueRemove(Customer customer, GoodStation targetStation) // Remove From Customer Queue
    {
        if (CheckCustomerType(customer.goodType) < 2)
        {
            typesToCheck.Remove(customer.goodType);
        }
        
        targetStation.currentCustomer = customer; // Set Station Current Customer
        customer.currentTarget = targetStation.customerArea; // Set Customer Target Area
        customer.Move();

        customerQueue.Remove(customer);
    }

    private int CheckCustomerType(GoodType type) // Check if any Customers in queue have this type.
    {
        int typeCustomerAmount = 0;
        foreach (Customer customer in customerQueue.ToArray())
        {
            if (customer.goodType == type)
            {
                typeCustomerAmount++;
            }
        }

        return typeCustomerAmount;
    }

    private GoodStation CheckStationType(GoodType goodType) // Check if any Stations of this type are available.
    {
        foreach (GoodStation station in goodStations.ToArray())
        {
            if (station.goodType == goodType && station.currentCustomer == null && station.stock > 0) // Has good type in stock and doesnt currently have a customer.
            {
                Debug.Log("Station Available");
                return station;
            }
        }

        return null;
    }

    private IEnumerator CheckAvailable() // Check if customers can be released from queue
    {
        while (true)
        {
            Debug.Log("Customer Queue Check");
            if (customerQueue.Count > 0)
            {
                Debug.Log("There Is Customers");
                foreach (GoodType goodType in typesToCheck.ToArray())
                {
                    //Debug.Log(goodType.ToString() + " Customers Waiting");
                    GoodStation station = CheckStationType(goodType);
                    if (station != null)
                    {
                        Debug.Log(goodType.ToString() + " Stations Available");
                        foreach (Customer customer in customerQueue.ToArray())
                        {
                            if (customer.goodType == goodType && station.currentCustomer == null)
                            {
                                CustomerQueueRemove(customer, station);
                                yield return new WaitForSeconds(1f);
                            }
                        }
                    }
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }

    #endregion



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

    //Upgrades
    public void PurchaseDrinkStation()
    {
        drinkStation.gameObject.SetActive(true);
        goodStations.Add(drinkStation);
    }

    public void PurchaseSnackStation()
    {
        secondSnackStation.gameObject.SetActive(true);
        goodStations.Add(secondSnackStation);
    }

    public void PurchaseTrinketStation()
    {
        trinketStation.gameObject.SetActive(true);
        goodStations.Add(trinketStation);
    }

    public void PurchaseHomeStation()
    {
        homeStation.gameObject.SetActive(true);
        goodStations.Add(homeStation);
    }

    public void PurchaseExpensiveStation()
    {
        expensiveStation.gameObject.SetActive(true);
        goodStations.Add(expensiveStation);
    }
}
