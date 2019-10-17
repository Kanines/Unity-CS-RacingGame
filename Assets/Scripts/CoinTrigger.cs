using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour {

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);   
    }

	void OnTriggerEnter()
    {
        LapTimerManager.Coins += 1;
        Destroy(this.gameObject);
    }
}
