	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCollision : MonoBehaviour {

	public Transform SpawnPoint;

    void OnTriggerEnter2D(Collider2D col) { 

        col.gameObject.transform.position = SpawnPoint.position;
	}
}
