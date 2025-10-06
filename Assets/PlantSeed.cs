using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    public GameObject PlantUI;
    public GameObject buttonHarvest;

    Placement placement;

    public int plantValue;//change to fruit and flower plant value

    public GameObject[] fruitPlanted;
    public GameObject[] fruitGrowing;

    public GameObject[] flowerPlanted;
    public GameObject[] flowerGrowing;

    public GameObject plantedPlant;

    public bool fruitPlant;
    public bool flowerPlant;

    public bool isgrowing;
    public bool isplanted;
    public bool fullgrown;
    public float growTimer;
    public float plantTime;//for different types of plant

    void Start()
    {
        isplanted = false;
        placement = GetComponent<Placement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isgrowing && isplanted)
        {
            if (fruitPlant)
            {
                fruitGrowing[0].SetActive(true);
            }
            else if (flowerPlant)
            {
                flowerGrowing[0].SetActive(true);//switch case for different flower plant val
            }

            growTimer += Time.deltaTime;
        }
        else if (!isgrowing && isplanted) { 
            growTimer += Time.deltaTime;
        }


        if (growTimer > 5 && growTimer > 2) // change 5 into plantTime different val has different growth time
        {

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
            else if (flowerPlant) {
                flowerGrowing[0].SetActive(false);//switch case for different flower plant val*
                flowerPlanted[0].SetActive(true);

                plantedPlant = flowerPlanted[0];
            }
            fullgrown = true;
            isgrowing=false;
        }

        else if (growTimer > 2) {
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

        if (fullgrown)
        {
            buttonHarvest.SetActive(true);
        }
        else {
            buttonHarvest.SetActive(false);
        }
        
    }

    public void plantButton() {
        if (!isplanted)
        {
            PlantUI.SetActive(true);
        }
        else {
            print("already planted");
        }
        
    }

    public void plantVal0() {
        plantValue = 0;
        isplanted = true;
        fruitPlant = true;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal1()
    {
        plantValue = 1;
        isplanted = true;
        fruitPlant = true;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal2()
    {
        plantValue = 2;
        isplanted = true;
        isgrowing = true;
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal3()
    {
        plantValue = 3;
        isplanted = true;
        isgrowing = true;
        fruitPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal4()
    {
        plantValue = 4;
        isplanted = true;
        isgrowing = true;
        flowerPlant = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }

    public void HarvestPlant() {
        if (fruitPlant)
        {
            growTimer = 0;
            fruitGrowing[1].SetActive(true);
            fruitPlanted[plantValue].SetActive(false);
            isgrowing = true;
        }
        else if (flowerPlant) {
            growTimer = 0;
            flowerGrowing[0].SetActive(true);
            flowerPlanted[0].SetActive(false);
            isgrowing = true;
            
        }
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }

}
