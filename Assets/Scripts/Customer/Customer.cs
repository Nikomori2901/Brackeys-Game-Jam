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
    public SpriteRenderer spriteRenderer;

    private Collider2D customerCollider;

    public CustomerArea currentTarget;

    public Sprite north, south, east, west;

    void Start()
    {
        customerCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move()
    {
        StopAllCoroutines();

        float movingAngle = Quaternion.FromToRotation(transform.position, currentTarget.transform.position).eulerAngles.z;
        Debug.Log(movingAngle);
        if (movingAngle > 270)
        {
            // North
            spriteRenderer.sprite = north;
        }

        else if (movingAngle > 180)
        {
            // South
            spriteRenderer.sprite = south;
        }

        else if (movingAngle > 90)
        {
            // East
            spriteRenderer.sprite = east;
        }

        else
        {
            // West
            spriteRenderer.sprite = west;
        }
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