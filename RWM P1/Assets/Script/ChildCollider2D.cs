using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider2D : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D c)
    {
        gameObject.GetComponentInParent<portalCollision>().PullTrigger(c);
    }

    void OnTriggerEnter(Collider c)
    {
        gameObject.GetComponentInParent<portalCollision>().PullTrigger(c);
    }

}
