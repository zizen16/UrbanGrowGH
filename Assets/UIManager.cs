using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject RoomUI;
    public GameObject WateringUI;
    public GameObject SeedUI;
    public GameObject DiagnoseUI;

    [Header("Watering Win/Lose Panel")]
    public GameObject WateringWin;
    public GameObject WateringLose;

    [Header("Seed Win/Lose Panel")]
    public GameObject SeedWin;
    public GameObject SeedLose;
    [Header("Diagnose Win/Lose Panel")]
    public GameObject DiagnoseWin;
    public GameObject DiagnoseLose;
    [Header("Context Panels")]
    public GameObject SeedContextPanel;
    public GameObject WaterContextPanel;
    public GameObject DiagContextPanel;

    public GameObject furniturePanel;
    public GameObject gardeningPanel;
    public GameObject LibraryPanel;

    [Header("Library Buts")]
    public Button tomatoLibButt;
    public Button chiliLibButt;
    public Button eggplantLibButt;
    public Button lemonLibButt; 
    public Button flowerLibButt;
    public GameObject tomatoLibIF, chiliLibIF, eggplantLibIF, lemonLibIF, flowerLibIF;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (PlantManager.instance.tomatoIF)
        {
            tomatoLibButt.interactable = true;
        }
        else {
            tomatoLibButt.interactable = false;
        }

        if (PlantManager.instance.chiliIF)
        {
            chiliLibButt.interactable = true;
        }
        else
        {
            chiliLibButt.interactable = false;
        }

        if (PlantManager.instance.eggplantIF)
        {
            eggplantLibButt.interactable = true;
        }
        else
        {
            eggplantLibButt.interactable = false;
        }

        if (PlantManager.instance.lemonIF)
        {
            lemonLibButt.interactable = true;
        }
        else
        {
            lemonLibButt.interactable = false;
        }

        if (PlantManager.instance.flowerIF)
        {
            flowerLibButt.interactable = true;
        }
        else
        {
            flowerLibButt.interactable = false;
        }
    }

    public void PlantLibrary()
    {
        if (LibraryPanel.activeInHierarchy)
        {
            LibraryPanel.SetActive(false);
        }
        else
        {
            LibraryPanel.SetActive(true);
        }

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

        if (DiagnoseUI.activeInHierarchy && PlantManager.instance.DiagnoseMinigame.activeInHierarchy)
        {
            DiagnoseUI.SetActive(false);
            PlantManager.instance.DiagnoseMinigame.SetActive(false);
            PlantManager.instance.chosenPlant = null;
        }
    }

    public void StartContextPanel() {
        if (SeedContextPanel.activeInHierarchy)
        {
           Seeding s = FindAnyObjectByType<Seeding>();
           s.seedStart = true;
           SeedContextPanel.SetActive(false);
        }

        if (WaterContextPanel.activeInHierarchy)
        {
            Watering watering = FindAnyObjectByType<Watering>();
            watering.waterStart = true;
            WaterContextPanel.SetActive(false);
        }

        if (DiagContextPanel.activeInHierarchy)
        {
            Diagnose diag = FindAnyObjectByType<Diagnose>();
            diag.startDiag = true;
            DiagContextPanel.SetActive(false);
        }
    }

    public void ShowTomatoIF() { 
        tomatoLibIF.SetActive(true);
        chiliLibIF.SetActive(false);
        eggplantLibIF.SetActive(false);
        lemonLibIF.SetActive(false);
        flowerLibIF.SetActive(false);
    }
    public void ShowChiliIF()
    {
        tomatoLibIF.SetActive(false);
        chiliLibIF.SetActive(true);
        eggplantLibIF.SetActive(false);
        lemonLibIF.SetActive(false);
        flowerLibIF.SetActive(false);
    }
    public void ShowEggplantIF()
    {
        tomatoLibIF.SetActive(false);
        chiliLibIF.SetActive(false);
        eggplantLibIF.SetActive(true);
        lemonLibIF.SetActive(false);
        flowerLibIF.SetActive(false);
    }
    public void ShowLemonIF()
    {
        tomatoLibIF.SetActive(false);
        chiliLibIF.SetActive(false);
        eggplantLibIF.SetActive(false);
        lemonLibIF.SetActive(true);
        flowerLibIF.SetActive(false);
    }
    public void ShowFlowerIF()
    {
        tomatoLibIF.SetActive(false);
        chiliLibIF.SetActive(false);
        eggplantLibIF.SetActive(false);
        lemonLibIF.SetActive(false);
        flowerLibIF.SetActive(true);
    }

}
