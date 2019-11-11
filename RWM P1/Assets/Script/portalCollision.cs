	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCollision : MonoBehaviour {

	public Transform SpawnPoint;

	void OnTriggerEnter(Collider otherObject){
		otherObject.gameObject.transform.position = SpawnPoint.position;
	}
}
