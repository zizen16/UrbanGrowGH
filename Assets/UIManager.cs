using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject RoomUI;
    public GameObject WateringUI;
    public GameObject SeedUI;

    [Header("Watering Win/Lose Panel")]
    public GameObject WateringWin;
    public GameObject WateringLose;

    [Header("Seed Win/Lose Panel")]
    public GameObject SeedWin;
    public GameObject SeedLose;

    public GameObject furniturePanel;
    public GameObject gardeningPanel;
    private void Awake()
    {
        Instance = this;
    }
    public void FurenitureMode() {
        if (furniturePanel.activeInHierarchy)
        {
            furniturePanel.SetActive(false);
        }
        else {
            furniturePanel.SetActive(true);
        }

        if (gardeningPanel.activeInHierarchy) { 
            gardeningPanel.SetActive(false);
        }
    }

    public void GardenMode() {
        if (gardeningPanel.activeInHierarchy)
        {
            gardeningPanel.SetActive(false);
        }
        else
        {
            gardeningPanel.SetActive(true);
        }

        if (furniturePanel.activeInHierarchy) { 
            furniturePanel.SetActive(false);
        }
    }

    public void ExitWorld() {
        SceneManager.LoadScene("Exploration");
    }

    public void BackButtonMinigame() { 

        RoomUI.SetActive(true);

        if (WateringUI.activeInHierarchy && PlantManager.instance.WateringMinigame.activeInHierarchy) { 
            WateringUI.SetActive(false);
            PlantManager.instance.WateringMinigame.SetActive(false);
            PlantManager.instance.chosenPlant = null;
        }

        if (SeedUI.activeInHierarchy && PlantManager.instance.SeedMinigame.activeInHierarchy)
        {
            SeedUI.SetActive(false);
            PlantManager.instance.SeedMinigame.SetActive(false);
            PlantManager.instance.chosenPlant = null;
        }
    }
}
