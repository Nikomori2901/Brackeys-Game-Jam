using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public List<GameObject> restockButtons = new List<GameObject>();
    public List<GameObject> purchaseButtons = new List<GameObject>();
    public GameObject tutorialPage;
    public GameObject tutorialButton;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CloseTutorial()
    {
        tutorialPage.SetActive(false);
        tutorialButton.SetActive(false);
    }
}