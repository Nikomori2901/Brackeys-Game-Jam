using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public int patience = 0;
    public int taskSpeed = 0;
    public float moveSpeed = 0f;

    public Shop.GoodType goodType;
    public bool holdingGood = false;

    private Collider2D customerCollider;

    public CustomerArea currentTarget;

    void Start()
    {
        customerCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(CheckStations());
    }

    private IEnumerator CheckStations()
    {
        yield return new WaitForSeconds(0.1f);

        List<GoodStation> validStations = new List<GoodStation>();

        foreach (GoodStation goodStation in Shop.current.goodStations)
        {
            if (goodStation.goodType == goodType)
            {
                validStations.Add(goodStation);
                Debug.Log("Same Type Good Station Found");
            }
        }

        bool stationAvailable = false;
        while (!stationAvailable)
        {
            Debug.Log("Check Valid Stations");
            yield return new WaitForSeconds(0.1f);

            foreach (GoodStation goodStation in validStations)
            {
                Debug.Log(goodStation.HasStock() + " - " + goodStation.customerArea.currentCustomer);
                if (goodStation.HasStock() && goodStation.customerArea.currentCustomer == null)
                {
                    currentTarget = goodStation.customerArea;
                    MoveTo(goodStation.customerArea);
                    stationAvailable = true;
                }
            }
        }
    }

    public void MoveTo(CustomerArea targetArea)
    {
        this.currentTarget = targetArea;
        Debug.Log(currentTarget);
        StartCoroutine(MoveToPosition(currentTarget.GetPosition()));
        Debug.Log("Start Moving");
    }

    public IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        Debug.Log("MoveToPosition");
        bool atPosition = false;
        while (!atPosition)
        {
            yield return new WaitForFixedUpdate();

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
                Debug.Log("Moving");
            }

            else
            {
                atPosition = true;
            }
        }

        yield break;
    }

    public void Leave()
    {
        customerCollider.enabled = false;
        StartCoroutine(MoveToExit(Shop.current.exitLocation.transform.position));
        Debug.Log("Start Leaving");
    }

    public IEnumerator MoveToExit(Vector2 targetPosition)
    {
        bool atPosition = false;
        while (!atPosition)
        {
            yield return new WaitForFixedUpdate();

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
                Debug.Log("Moving");
            }

            else
            {
                atPosition = true;
            }
        }

        Despawn();
    }

    private void Despawn()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}