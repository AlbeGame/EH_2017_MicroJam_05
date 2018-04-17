using UnityEngine;

public class Plant : MonoBehaviour {

    public float TimeToGrow = 60;
    public float TimeAsFlower = 2;
    float timeSpent;
    
    public float waterPercentage = .5f;

    Vector3 dryWetAxis;

    public GameObject Rain;

    public GameObject DryLevel;
    public GameObject WetLevel;
    public GameObject ActualWaterLevel;

    public GameObject Seedlevel;
    public GameObject SapplingLevel;
    public GameObject AlmostFlowerLevel;
    public GameObject Flower;

    int stage = 0;

    PlantManager manager;

    public void Init(PlantManager _manager)
    {
        manager = _manager;

        transform.parent = manager.transform;

        timeSpent = TimeToGrow;

        Seedlevel.SetActive(true);
        SapplingLevel.SetActive(false);
        AlmostFlowerLevel.SetActive(false);
        Flower.SetActive(false);

        dryWetAxis = WetLevel.transform.position - DryLevel.transform.position;
        ActualWaterLevel.transform.position = DryLevel.transform.position + dryWetAxis * waterPercentage;
    }
	
	// Update is called once per frame
	void Update () {

        timeSpent -= Time.deltaTime;

        if (timeSpent <= 0)
        {
            timeSpent = TimeToGrow;
            Grow();
        }

        UpdateWaterPercentage();
	}

    void Grow()
    {
        stage++;

        switch (stage)
        {
            case 1:
                Seedlevel.SetActive(false);
                SapplingLevel.SetActive(true);
                break;
            case 2:
                SapplingLevel.SetActive(false);
                AlmostFlowerLevel.SetActive(true);
                break;
            case 3:
                AlmostFlowerLevel.SetActive(false);
                Flower.SetActive(true);
                timeSpent = TimeAsFlower;
                break;
            default:
                AssignPoint();
                break;
        }
    }

    void UpdateWaterPercentage()
    {
        if (Rain.activeSelf)
            waterPercentage += Time.deltaTime/100;
        else
            waterPercentage -= Time.deltaTime/100;

        ActualWaterLevel.transform.position = DryLevel.transform.position + dryWetAxis * waterPercentage;

        if (waterPercentage < 0 || waterPercentage > 1)
            Die();
    }

    void AssignPoint()
    {
        manager.NotifySuccesfullyGrown(this);
    }

    public void Die()
    {
        manager.NotifyDeath(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player playR = other.GetComponent<Player>();

        if (playR)
        {
            Rain.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player playR = other.GetComponent<Player>();

        if (playR)
        {
            Rain.SetActive(true);
        }
    }
}
