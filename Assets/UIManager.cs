using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject furniturePanel;

    public void FurenitureMode() {
        if (furniturePanel.activeInHierarchy)
        {
            furniturePanel.SetActive(false);
        }
        else {
            furniturePanel.SetActive(true);
        }
    }

    public void ExitWorld() {
        SceneManager.LoadScene("Exploration");
    }
}
