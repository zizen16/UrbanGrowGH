using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBanish : MonoBehaviour
{
    public int seedBanished;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seed")
        {
            seedBanished++;
            Destroy(other.gameObject);
        }
    }
}
