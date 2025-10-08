using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    public GameObject PlantUI;
    public GameObject buttonHarvest;
    public GameObject buttonWater;
    public GameObject buttonDiagnose;

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
    public bool isgrowing;
    public bool isWatered;
    public bool isDiagnosed;
    public bool fullgrown;

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

        if (isgrowing && isDiagnosed) {
            if (fruitPlant)
            {
                switch (plantValue)
                {
                    case 0:
                        fruitGrowing[1].SetActive(false);
                        fruitPlanted[plantValue].SetActive(true);
                        break;
                    case 1:
                        fruitGrowing[1].SetActive(false);
                        fruitPlanted[plantValue].SetActive(true);
                        break;
                    case 2:
                        fruitGrowing[1].SetActive(false);
                        fruitPlanted[plantValue].SetActive(true);
                        break;
                    case 3:
                        fruitGrowing[1].SetActive(false);
                        fruitPlanted[plantValue].SetActive(true);
                        break;
                    case 4:
                        fruitGrowing[1].SetActive(false);
                        fruitPlanted[plantValue].SetActive(true);
                        break;
                }

                plantedPlant = fruitPlanted[plantValue];

            }
            else if (flowerPlant)
            {
                flowerGrowing[0].SetActive(false);//switch case for different flower plant val*
                flowerPlanted[0].SetActive(true);

                plantedPlant = flowerPlanted[0];
            }
            fullgrown = true;
            isgrowing = false;

        }


        if (!isWatered && isseeded)
        {
            buttonWater.SetActive(true);
        }
        else {
            buttonWater.SetActive(false);
        }

        if (!isDiagnosed && isseeded && isWatered)
        {
            buttonDiagnose.SetActive(true);
        }
        else {
            buttonDiagnose.SetActive(false);
        }

        if (fullgrown && isseeded)
        {
            buttonHarvest.SetActive(true);
        }
        else
        {
            buttonHarvest.SetActive(false);
        }

        if (failMinigame) {
            isseeded = false;
            isgrowing = false;
            isWatered = false;
            if (fruitPlant)
            {
                fruitPlant = false;
                fruitGrowing[0].SetActive(false);
                fruitGrowing[1].SetActive(false);
                fruitPlanted[plantValue].SetActive(false);
            }
            else if (flowerPlant)
            {
                flowerPlant = false;
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
            fullgrown = false;

            isDiagnosed = false;
        }
        else if (flowerPlant) {
            //growTimer = 0;
            flowerGrowing[0].SetActive(true);
            flowerPlanted[0].SetActive(false);
            isgrowing = true;
            fullgrown = false;

            isDiagnosed = false;
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

    public void DiagnosePlant()
    {
        UIManager.Instance.RoomUI.SetActive(false);
        UIManager.Instance.DiagnoseUI.SetActive(true);
        PlantManager.instance.DiagnoseMinigame.SetActive(true);
        PlantManager.instance.DiagnoseMinigame.GetComponentInChildren<Diagnose>().ResetDiagnose();
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
