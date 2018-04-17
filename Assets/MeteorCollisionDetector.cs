using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollisionDetector : MonoBehaviour {

    Plant parentPlant;

	// Use this for initialization
	void Start () {
        parentPlant = GetComponentInParent<Plant>();
	}

    private void OnTriggerEnter(Collider other)
    {
        Meteor met = other.GetComponent<Meteor>();
        if(met != null)
        {
            Destroy(met.gameObject);
            parentPlant.Die();
        }
    }
}
