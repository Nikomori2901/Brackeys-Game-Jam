using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPressSpriteChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    public Sprite sprite;
    public Sprite heldSprite;

    void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = heldSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = sprite;
    }
}
