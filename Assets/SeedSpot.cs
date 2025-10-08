using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedSpot : MonoBehaviour
{
    public int seedRequired = 5;
    public int seedPlanted;

    public TextMeshProUGUI seedplantTxt;
    public TextMeshProUGUI seedmissTxt;
    public int seedmissed;


    private void Update()
    {
        
        SeedBanish seedBanish = GameObject.FindAnyObjectByType<SeedBanish>();
        PlantSeed ps = PlantManager.instance.chosenPlant.GetComponent<PlantSeed>();
        
        if (seedBanish.seedBanished >= 3) {
            UIManager.Instance.SeedLose.SetActive(true);
            ps.flowerPlant = false;
            ps.fruitPlant = false;
            ps.plantValue = 0;
            seedBanish.seedBanished = 0;
        }

        if (seedRequired <= seedPlanted) {
            ps.isseeded = true;
            ps.isgrowing = true;
            UIManager.Instance.SeedWin.SetActive(true);
        }

        seedplantTxt.text = "Seed Planted: " + seedPlanted;
        seedmissTxt.text = "Seed Missed: " + seedBanish.seedBanished;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seed") {
            seedPlanted++;
            Destroy(other.gameObject);
        }
    }

    public void ResetStatSeeding() {
        seedPlanted = 0;
        UIManager.Instance.SeedWin.SetActive(false);
        UIManager.Instance.SeedLose.SetActive(false);
    }
}
