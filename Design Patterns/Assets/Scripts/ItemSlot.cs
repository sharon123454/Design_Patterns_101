using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler,IDragHandler, IEndDragHandler
{
    [SerializeField] private Item _item;
    [SerializeField] private Image slotImage;

    public LayerMask lockMask;
    private Transform inventoryParent;
    private Camera _mainCam;

    public void Init(Item i)
    {
        _item = i;
        slotImage.sprite = i.sprite;
        _mainCam = Camera.main;
        inventoryParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(InventoryUI.instance.mainCanvas);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //cant seem to use the right position to see the item move on screen
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, lockMask))
        {
            Unlockable locked = hit.transform.GetComponent<Unlockable>();

            if (locked.eKey == _item.eKey)
            {
                GameObject createdKey = Instantiate(_item.prefab);
                locked.OpenLock(createdKey);
                InventoryData.RemoveItem(_item);
                Destroy(gameObject);
                if (locked.eLock == ELock.Door)
                {
                    InventoryUI.instance.EndScreen.SetActive(true);
                }
                createdKey.GetComponent<PickedItem>().TriggerAnimations();
                //play sound
                Debug.Log("Drag Completed");
            }
            else
            {
                transform.SetParent(inventoryParent);
                Debug.Log("Wrong key");
            }
        }
        else
        {
            transform.SetParent(inventoryParent);
            Debug.Log("Lock not found");
        }
    }
}