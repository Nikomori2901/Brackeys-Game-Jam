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
    }

    public void Move()
    {
        StopAllCoroutines();
        Debug.Log("Start Moving");
        StartCoroutine(MoveToPosition(currentTarget.GetPosition()));
    }

    public IEnumerator MoveToPosition(Vector2 targetPosition)
    {
        bool atPosition = false;
        while (!atPosition)
        {
            yield return new WaitForFixedUpdate();

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
                //Debug.Log("Moving");
            }

            else
            {
                atPosition = true;
            }
        }

        yield break;
    }

    public void Despawn()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}