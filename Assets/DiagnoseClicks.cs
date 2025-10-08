using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagnoseClicks : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        gameObject.SetActive(false);
    }
}
