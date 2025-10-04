using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeed : MonoBehaviour
{
    public GameObject PlantUI;
    Placement placement;

    public int plantValue;
    public GameObject[] planted;
    public GameObject[] growing;

    public bool isgrowing;
    public float growTimer;
    public float plantTime;//for different types of plant

    void Start()
    {
        isgrowing = false;
        placement = GetComponent<Placement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isgrowing) {
            growing[0].SetActive(true);
            growTimer += Time.deltaTime;
        }

        if (growTimer > 5 && growTimer > 2) // change 5 into plantTime different val has different growth time
        {

            switch (plantValue) { 
            case 0:
                    growing[1].SetActive(false);
                    planted[plantValue].SetActive(true);
                    break;
            case 1:
                    growing[1].SetActive(false);
                    planted[plantValue].SetActive(true);
                    break;
            case 2:
                    growing[1].SetActive(false);
                    planted[plantValue].SetActive(true);
                    break;
            case 3:
                    growing[1].SetActive(false);
                    planted[plantValue].SetActive(true);
                    break;
            case 4:
                    growing[1].SetActive(false);
                    planted[plantValue].SetActive(true);
                    break;
            }

            isgrowing=false;
        }
        else if (growTimer > 2) {
            growing[0].SetActive(false);
            growing[1].SetActive(true);
        }
        
    }

    public void plantButton() { 
        PlantUI.SetActive(true);

    }

    public void plantVal0() {
        plantValue = 0;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal1()
    {
        plantValue = 1;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal2()
    {
        plantValue = 2;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal3()
    {
        plantValue = 3;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }
    public void plantVal4()
    {
        plantValue = 4;
        isgrowing = true;
        PlantUI.SetActive(false);
        placement.DisableInteraction();
    }

}
