using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager instance;

    public GameObject chosenPlant;

    public GameObject WateringMinigame;
    public GameObject DiagnoseMinigame;
    public GameObject SeedMinigame;

    public bool tomatoIF, chiliIF, eggplantIF, lemonIF, flowerIF;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

}
