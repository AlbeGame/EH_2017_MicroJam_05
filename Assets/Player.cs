using UnityEngine;

public class Player : MonoBehaviour {

    public float PlayerSpeed = 10f;
    public float MaxDistanceFromCentre = 5f;

    Vector3 startingPos;
	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 movement = Input.GetAxis("Horizontal") * PlayerSpeed * Vector3.right * Time.deltaTime;

        movement = movement + transform.position;

        if(Vector3.Distance(movement, startingPos) < MaxDistanceFromCentre)
        {
            transform.position = movement;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Meteor met = other.GetComponent<Meteor>();
        if (met != null)
        {
            Destroy(met.gameObject);
        }
    }
}
