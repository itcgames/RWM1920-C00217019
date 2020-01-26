	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCollision : MonoBehaviour {

	public Transform SpawnPoint;
    public AudioClip m_portalSFX;
    private AudioSource m_source;

    void Start()
    {
        m_source = gameObject.transform.GetComponent<AudioSource>();
    }

    public void PullTrigger(Collider2D col)
    {
        if (gameObject.GetComponentInParent<TeleportHistory>().limitToRigidBodies)//Checks to see if it needs to check for Rigid bodies.
        {
            if(col.GetComponent<Rigidbody2D>() != null)//Checks for a non null rigid body.
            {
                if (gameObject.GetComponentInParent<TeleportHistory>().History(col))//Checks to see if it's allowed to warp
                {
                    col.gameObject.transform.position = SpawnPoint.position;//Warps the object
                    m_source.PlayOneShot(m_portalSFX);//Playes sound effect
                }
            }
        }
        else
        {
            if (gameObject.GetComponentInParent<TeleportHistory>().History(col))//As above just without checking for Rigid body.
            {
                col.gameObject.transform.position = SpawnPoint.position;
                m_source.PlayOneShot(m_portalSFX);
            }
        }

    }




    public void PullTrigger(Collider col)
    {
        if (gameObject.GetComponentInParent<TeleportHistory>().limitToRigidBodies)
        {
            if (col.GetComponent<Rigidbody>() != null)
            {
                if (gameObject.GetComponentInParent<TeleportHistory>().History(col))
                {
                    col.gameObject.transform.position = SpawnPoint.position;
                    m_source.PlayOneShot(m_portalSFX);
                }
            }
        }
        else
        {
            if (gameObject.GetComponentInParent<TeleportHistory>().History(col))
            {
                col.gameObject.transform.position = SpawnPoint.position;
                m_source.PlayOneShot(m_portalSFX);
            }
        }
    }


}
