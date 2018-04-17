using UnityEngine;

public class PlantManager : MonoBehaviour {

    public int MaxMisstakes = 3;
    int actualMisstakes;

    int succesfullygrownPlants;

    public GameObject PlantPrefab;

    public Plant plant1;
    public Plant plant2;
    public Plant plant3;

    public TextMesh SavedPlants;
    public TextMesh DeadPlants;
    public GameObject GameOver;

    private void Start()
    {
        SavedPlants.text = "Saved Seeds: " + succesfullygrownPlants;
        DeadPlants.text = "Un-Saved Seeds: " + actualMisstakes;

        plant1.Init(this);
        plant2.Init(this);
        plant3.Init(this);
    }

    public void NotifySuccesfullyGrown(Plant _plant)
    {
        succesfullygrownPlants++;
        Plant newPlant = Instantiate(PlantPrefab, _plant.transform.position, Quaternion.identity, transform).GetComponent<Plant>();
        newPlant.Init(this);

        Destroy(_plant.gameObject);
        SavedPlants.text = "Saved Seeds: " + succesfullygrownPlants;
    }

    public void NotifyDeath(Plant _plant)
    {
        actualMisstakes++;

        Plant newPlant = Instantiate(PlantPrefab, _plant.transform.position, Quaternion.identity, transform).GetComponent<Plant>();
        newPlant.Init(this);

        Destroy(_plant.gameObject);

        if (actualMisstakes >= MaxMisstakes)
            DoGameOver();

        DeadPlants.text = "Un-Saved Seeds: " + actualMisstakes;
    }

    void DoGameOver()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
