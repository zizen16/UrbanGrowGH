using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diagnose : MonoBehaviour
{
    public static Diagnose Instance;
    public int wormCount, leafCount, flyCount;
    public GameObject[] worms;
    public GameObject[] leaves;
    public GameObject[] flies;
    public int randomCount;
    public int amountToRemove;
    public bool finishedDiagnose;

    public float timerCount;

    public TextMeshProUGUI removecounts;
    public TextMeshProUGUI TimerUI;

    public bool startDiag;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timerCount = 45;
        randomCount = Random.Range(0, 5);
        for (int i = 0; i <= randomCount; i++) {
            worms[i].SetActive(true);
            leaves[i].SetActive(true);
            flies[i].SetActive(true);
        }

        amountToRemove = (randomCount+1) * 3;
    }

    // Update is called once per frame
    void Update()
    {
        PlantSeed ps = PlantManager.instance.chosenPlant.GetComponent<PlantSeed>();
        TimerUI.text = "Timer: " + timerCount.ToString("F0");
        removecounts.text = "To be Removed: " + amountToRemove;
        

        if (!finishedDiagnose && startDiag) timerCount -= Time.deltaTime;

        if (timerCount <= 0) { 
            ps.failMinigame = true;
            UIManager.Instance.DiagnoseLose.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                worms[i].SetActive(false);
                leaves[i].SetActive(false);
                flies[i].SetActive(false);
            }
            finishedDiagnose = true;
        }

        if (amountToRemove <= 0) {
            amountToRemove = 0;
            finishedDiagnose = true;
            ps.isDiagnosed = true;
            UIManager.Instance.DiagnoseWin.SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                worms[i].SetActive(false);
                leaves[i].SetActive(false);
                flies[i].SetActive(false);
            }
        }

    }

    public void ResetDiagnose() {
        startDiag = false;
        finishedDiagnose=false;
        timerCount = 45;
        randomCount = Random.Range(0, 5);
        for (int i = 0; i <= randomCount; i++)
        {
            worms[i].SetActive(true);
            leaves[i].SetActive(true);
            flies[i].SetActive(true);
        }
        UIManager.Instance.DiagContextPanel.SetActive(true);
        UIManager.Instance.DiagnoseLose.SetActive(false);
        UIManager.Instance.DiagnoseWin.SetActive(false);
        amountToRemove = (randomCount + 1) * 3;
    }
}
