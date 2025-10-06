using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 instance;

    public GameObject ApartmentPanel;
    public GameObject GardenPanel;

    public bool playerEnteredApartment;
    public bool playerEnteredGarden;
    // Start is called before the first frame update
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
        if (playerEnteredApartment)
        {
            ApartmentPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            ApartmentPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (playerEnteredGarden) {
            GardenPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            GardenPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void changeChange(string roomname) {
        SceneManager.LoadScene(roomname);
    }
    public void closeWindow() { 
        playerEnteredApartment = false;
        playerEnteredGarden = false;
    }
}
