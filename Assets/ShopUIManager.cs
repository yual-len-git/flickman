using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopUIManager : MonoBehaviour
{
    public RectTransform shopUI;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public GameObject dragLocation;
    public Rigidbody player;
    public Transform attatchPoint;

    private Vector3 spawnLocation;
    private GameObject purchaseObject = null;
    private double cost;
    
    private PlayerControls playerControls;
    private bool shopActive = false;

    private void Awake()
    {
        playerControls = new PlayerControls();
        Debug.Log(shopUI.GetType());
        shopActive = false;
        shopUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Keyboard.current.enterKey.wasPressedThisFrame && shopActive)
        {
            Debug.Log("Pressed");
            if (cost > loadScenes.globalBalance)
            {
                print("insufficient funds");
            } else
            {
                GameObject go = Instantiate(purchaseObject, spawnLocation, Quaternion.identity);
                DragObject d = go.GetComponent<DragObject>();
                if(d)
                {
                    d.dragLocation = dragLocation;
                    d.player = player;
                    d.attachLocation = attatchPoint;
                }
            }
        }
    }

    public void ShowShop(string description, double c, GameObject prefab, Vector3 spawnLoc)
    {
        purchaseObject = prefab;
        spawnLocation = spawnLoc;
        cost = c;
        descriptionText.text = description;
        costText.text = cost.ToString();
        shopActive = true;
        shopUI.gameObject.SetActive(true);
    }

    public void HideShop()
    {
        shopActive = false;
        shopUI.gameObject.SetActive(false);
    }
}
