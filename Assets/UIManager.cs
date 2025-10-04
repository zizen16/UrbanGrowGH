using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject furniturePanel;
    public GameObject gardeningPanel;

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
}
