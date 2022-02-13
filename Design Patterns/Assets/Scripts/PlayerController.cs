using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask pointOfInterest;
    [SerializeField] private LayerMask lockMask;
    [SerializeField] private LayerMask keyMask;
    [SerializeField] private LayerMask MoverMask;
    private Camera cam;
    private bool zoom = false;
    private bool atSpawn = true;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIObject())
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, keyMask))
                {
                    PickedItem picked = hit.collider.GetComponent<PickedItem>();
                    picked.TryTakeMe();
                }
                else if (Physics.Raycast(ray, out hit, 100, lockMask))
                {
                    Debug.Log($"A hint of the missing key + {hit.collider.GetComponent<Unlockable>().eKey}");
                }
                else if (Physics.Raycast(ray, out hit, 100, pointOfInterest))
                {
                    PoIComp PoI = hit.collider.GetComponent<PoIComp>();
                    PoI.MoveToPoI(zoom, cam.transform);
                    zoom = !zoom;
                }
                else if (Physics.Raycast(ray, out hit, 100, MoverMask))
                {
                    Mover moverObj = hit.collider.GetComponent<Mover>();
                    moverObj.MoveCam(atSpawn, cam.transform);
                    atSpawn = !atSpawn;
                }
            }
        }
    }

    public void RotateCW()
    {
        cam.transform.eulerAngles += new Vector3(0, 90, 0);
    }
    public void RotateCCW()
    {
        cam.transform.eulerAngles -= new Vector3(0, 90, 0);
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrPos = new PointerEventData(EventSystem.current);
        eventDataCurrPos.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrPos, results);
        return results.Count > 0;
    }
}