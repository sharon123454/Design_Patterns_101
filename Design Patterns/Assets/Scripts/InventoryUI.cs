using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] public GameObject InventoryParent;
    [SerializeField] public GameObject EndScreen;
    internal Transform mainCanvas;
    public static InventoryUI instance;
    public List<Item> items;

    private void Awake()
    {
        mainCanvas = transform;
        items = InventoryData.Items;
        EndScreen.SetActive(false);
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Add(Item item)
    {
        GameObject newItem = Instantiate(prefab, InventoryParent.transform);
        newItem.GetComponent<ItemSlot>().Init(item);
    }
}