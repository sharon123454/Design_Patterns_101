using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoIComp : MonoBehaviour
{
    [SerializeField] List<PickedItem> relevantItems;

    public Transform newCamParent;
    private Transform baseCamParent;

    public void MoveToPoI(bool zoom, Transform currentCamPos)
    {
        Debug.Log("PoI Clicked");
        if (!zoom)
        {
            baseCamParent = currentCamPos.parent;
            currentCamPos.SetParent(newCamParent, false);
            currentCamPos.rotation = new Quaternion(0, 0, 0, 0);

            foreach (PickedItem keyObj in relevantItems)
                if (keyObj != null)
                    keyObj.IsPickable = true;

            return;
        }

        currentCamPos.SetParent(baseCamParent, false);
        currentCamPos.rotation = new Quaternion(0, 0, 0, 0);

        foreach (PickedItem keyObj in relevantItems)
            keyObj.IsPickable = false;
    }
}