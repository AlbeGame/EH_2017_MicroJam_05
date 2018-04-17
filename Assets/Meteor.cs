using UnityEngine;

public class Meteor : MonoBehaviour {

    public float Speed = 10f;

	// Update is called once per frame
	void Update () {
        transform.position += -Vector3.up * Speed * Time.deltaTime;
	}
}
