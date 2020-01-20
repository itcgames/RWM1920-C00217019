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
        if (gameObject.GetComponentInParent<TeleportHistory>().History(col))
        {
            col.gameObject.transform.position = SpawnPoint.position;
            m_source.PlayOneShot(m_portalSFX);
        }

    }




    public void PullTrigger(Collider col)
    {
        if (gameObject.GetComponentInParent<TeleportHistory>().History(col))
        {
            col.gameObject.transform.position = SpawnPoint.position;
            m_source.PlayOneShot(m_portalSFX);
        }
    }


}
