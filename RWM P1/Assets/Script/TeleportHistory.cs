using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHistory : MonoBehaviour
{
    private List<GameObject> teleportHistory = new List<GameObject>();
    private List<float> listTimeout = new List<float>();
    public float teleportTimeout = 0.5f; //Objects have a 0.5 second cool down before they can be teleported again.


    public bool History(Collider2D col)
    {
        checkTimes();
        if (col.gameObject != teleportHistory.Contains(col.gameObject))
        {
            teleportHistory.Add(col.gameObject);
            listTimeout.Add(Time.time);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public bool History(Collider col)
    {
        checkTimes();
        if (col.gameObject != teleportHistory.Contains(col.gameObject))
        {
            teleportHistory.Add(col.gameObject);
            listTimeout.Add(Time.time);
            return true;
        }
        else
        {
            return false;
        }

    }

    void checkTimes()
    {
        for (int i = listTimeout.Count - 1; i >= 0; i--)
        { 
            if (listTimeout[i] + teleportTimeout <= Time.time)
            { 
                listTimeout.RemoveAt(i);
                teleportHistory.RemoveAt(i);
            }
        }

    }
}
