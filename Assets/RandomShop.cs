using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShop : MonoBehaviour
{
    public ShopUIManager shopManager;
    public Transform spawnLocation;
    public string description = "";
    public int cost = 30;
    public List<GameObject> prefabOptions;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            shopManager.ShowShop(description, cost, prefabOptions[Random.Range(0, prefabOptions.Count)], spawnLocation.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            shopManager.HideShop();
        }
    }
}
