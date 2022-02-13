using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform newCamParent;
    public Transform spawn;

    public void MoveCam(bool atSpawn, Transform currentCamPos)
    {
        if (atSpawn)
        {
            currentCamPos.SetParent(newCamParent, false);
            currentCamPos.rotation = new Quaternion(0, 0, 0, 0);

            return;
        }

        currentCamPos.SetParent(spawn, false);
        currentCamPos.rotation = new Quaternion(0, 0, 0, 0);
    }
}