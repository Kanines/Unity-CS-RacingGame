using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfLapTrigger : MonoBehaviour {

    public GameObject FinishLapTrigger;
    public GameObject HalflapTrigger;

    void OnTriggerEnter()
    {
        FinishLapTrigger.SetActive(true);
        HalflapTrigger.SetActive(false);
        
    }
}
