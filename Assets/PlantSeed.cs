using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    public GameObject PlantUI;
    public GameObject buttonHarvest;
    public GameObject buttonWater;

    Placement placement;

    public int plantValue;//change to fruit and flower plant value

    public GameObject[] fruitPlanted;
    public GameObject[] fruitGrowing;

    public GameObject[] flowerPlanted;
    public GameObject[] flowerGrowing;

    public GameObject plantedPlant;

    public bool fruitPlant;
    public bool flowerPlant;

    /*public bool isgrowing;
    public bool isplanted;
    public bool fullgrown;
    public float growTimer;
    public float plantTime;//for different types of plant
    */

    public bool isseeded;
    public bool isplanted;
    public bool isgrowing;
    public bool isWatered;
    public bool failMinigame;
    //public bool isChosen;

    void Start()
    {
        isseeded = false;
        placement = GetComponent<Placement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isgrowing && isseeded)
        {
            if (fruitPlant)
            {
                fruitGrowing[0].SetActive(true);
            }
            else if (flowerPlant)
            {
                flowerGrowing[0].SetActive(true);//switch case for different flower plant val
            }

        }
        
        if (isgrowing && isWatered)
        {
            if (fruitPlant)
            {
                fruitGrowing[0].SetActive(false);
                fruitGrowing[1].SetActive(true);
            }
            else if (flowerPlant)
            {
                flowerGrowing[0].SetActive(true);//switch case for different flower plant val
            }
        }

        if (!isWatered && isseeded)
        {
            buttonWater.SetActive(true);
        }
        else {
            buttonWater.SetActive(false);
        }

        if (failMinigame) {
            isseeded = false;
            isgrowing = false;
            isplanted = false;
            isWatered = false;
            if (fruitPlant)
            {
                fruitGrowing[0].SetActive(false);
                fruitGrowing[1].SetActive(false);
                fruitPlanted[plantValue].SetActive(false);
            }
            else if (flowerPlant)
            {
                flowerGrowing[0].SetActive(false);
                flowerPlanted[0].SetActive(false);
            }
            failMinigame = false;
        }

    }

    public void plantVal0() {
        plantValue = 0;
        OpenSeedGame();
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal1()
    {
        plantValue = 1;
        OpenSeedGame();
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal2()
    {
        plantValue = 2;
        OpenSeedGame();
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal3()
    {
        plantValue = 3;
        OpenSeedGame();
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal4()
    {
        plantValue = 4;
        OpenSeedGame();
        flowerPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }

    public void HarvestPlant() {
        if (fruitPlant)
        {
            //growTimer = 0;
            fruitGrowing[1].SetActive(true);
            fruitPlanted[plantValue].SetActive(false);
            isgrowing = true;
        }
        else if (flowerPlant) {
            //growTimer = 0;
            flowerGrowing[0].SetActive(true);
            flowerPlanted[0].SetActive(false);
            isgrowing = true;
            
        }
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }

    public void WaterPlant() {
        UIManager.Instance.RoomUI.SetActive(false);
        UIManager.Instance.WateringUI.SetActive(true);
        PlantManager.instance.WateringMinigame.SetActive(true);
        PlantManager.instance.WateringMinigame.GetComponentInChildren<Watering>().ResetStat();
        placement.DisableInteraction();
    }
    public void plantButton()
    {
        if (!isseeded)
        {
            PlantUI.SetActive(true);
        }
        else
        {
            print("already planted");
        }

    }

    public void OpenSeedGame() {
        UIManager.Instance.RoomUI.SetActive(false);
        UIManager.Instance.SeedUI.SetActive(true);
        PlantManager.instance.SeedMinigame.SetActive(true);
        PlantManager.instance.SeedMinigame.GetComponentInChildren<SeedSpot>().ResetStatSeeding();
        placement.DisableInteraction();
    }

}
