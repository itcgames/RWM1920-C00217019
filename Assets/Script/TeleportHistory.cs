using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHistory : MonoBehaviour
{
    private List<GameObject> teleportHistory = new List<GameObject>();//List of warped Objects.
    private List<float> listTimeout = new List<float>();//List of times from when the objects were warped.
    public float teleportTimeout = 0.5f; //Objects have a 0.5 second cool down before they can be teleported again.
    public bool limitToRigidBodies = true;//Only warp objects that have rigid bodies.


    public bool History(Collider2D col)
    {
        checkTimes();
        if (col.gameObject != teleportHistory.Contains(col.gameObject))//Checking if list contains the object
        {
            teleportHistory.Add(col.gameObject);
            listTimeout.Add(Time.time);//Add the time and Object to the list.
            return true;//Allow it to be warped
        }
        else
        {
            return false;//Else Deny the Warp.
        }
        
    }
    public bool History(Collider col)//Polymorphic Function to work with 3D collider.
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

    void checkTimes()//Check to see if any of the objects have timed out. Working from back to front to prevent errors.
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
