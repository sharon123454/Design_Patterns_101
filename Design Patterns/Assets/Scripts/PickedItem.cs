using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedItem : MonoBehaviour
{
    public bool IsPickable = false;
    public Item item;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    internal void TryTakeMe()
    {
        if (!IsPickable)
        {
            Debug.Log("not pickable");
            return;
        }
        Debug.Log($"Ray hit {name}");

        InventoryData.AddItem(item);
        //enter pickup sound and VFX
        gameObject.SetActive(false);
    }

    public void TriggerAnimations()
    {
        anim.SetTrigger("Open");
    }
}