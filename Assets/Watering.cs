using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Watering : MonoBehaviour
{
    [Header("Pot Tracking")]
    public Transform PotFollow;
    public Transform rot;
    public float speedrot;


    [Header("Pot Movement")]
    public float speedRandom;
    public Transform[] movePoints;
    public int pointRandom;
    [Header("Fill Percent")]
    public float fillGauge;
    public float minGaugeFill,maxGaugeFill,maxGauge;
    public Image fillBar;
    public Image correctAmountBar;
    public Image minimumAmountBar;

    bool start,finish,completed;
    PlantSeed ps;

    void Start()
    {
       ResetStat();
       maxGauge = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (start && !finish) {
            Vector3 rotates = PotFollow.position - transform.position;
            Quaternion lookrotation = Quaternion.LookRotation(rotates);
            Vector3 rotateme = Quaternion.Lerp(rot.rotation, lookrotation, Time.deltaTime * 10).eulerAngles;
            rot.rotation = Quaternion.Euler(rotateme.x, rotateme.y, rotateme.z);

            float distanceWaypoint = Vector3.Distance(transform.position, movePoints[pointRandom].position);
            if (distanceWaypoint <= 2)
            {
                print("point Change");
                pointRandom = Random.Range(0, movePoints.Length);
                speedRandom = Random.Range(0.03f, 0.08f);
            }
        }
        fillBar.fillAmount = fillGauge / maxGauge;
        correctAmountBar.fillAmount = maxGaugeFill / 100;
        minimumAmountBar.fillAmount = minGaugeFill / 100;
        

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0)) {
            start = true;
            if (start && !finish) {
                fillGauge+=0.1f;
                MoveTowardPoint();
            }
        }



    }
    private void OnMouseExit()
    {
        if (!start)
        {
            print("hovered");
        }
        else {
            finish = true;

            ps = PlantManager.instance.chosenPlant.GetComponent<PlantSeed>();
            if (fillGauge > minGaugeFill && fillGauge < maxGaugeFill)
            {
                ps.isWatered = true;
                UIManager.Instance.WateringWin.SetActive(true);
            }
            else
            {
                UIManager.Instance.WateringLose.SetActive(true);
                ps.failMinigame = true;
            }
        }
        
    }
    

    void MoveTowardPoint() {
        this.transform.position = Vector3.MoveTowards(transform.position, movePoints[pointRandom].position, speedRandom);
    }

    public void ResetStat() {

        start = false;
        finish = false;
        fillGauge = 0;
        minGaugeFill = Random.Range(50, 60);
        maxGaugeFill = Random.Range(70, 80);
        pointRandom = Random.Range(0, movePoints.Length);

        UIManager.Instance.WateringWin.SetActive(false);
        UIManager.Instance.WateringLose.SetActive(false);
        
    }
}
