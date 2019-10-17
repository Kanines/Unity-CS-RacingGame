using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject Car;
    public float CarX;
    public float CarY;
    public float CarZ;

    GameObject[] camerasGO;
    //List<Camera> cameras;

    public int currentCamera = 0;

    public bool isStabilized = false;

    // Update is called once per frame
    void Update()
    {
        if (isStabilized)
        {
            CarX = Car.transform.eulerAngles.x;
            CarY = Car.transform.eulerAngles.y;
            CarZ = Car.transform.eulerAngles.z;

            transform.eulerAngles = new Vector3(0, CarY, 0);
        }
    }

    void Start()
    {
        camerasGO = GameObject.FindGameObjectsWithTag("MainCamera");
    }

    public void StabilizeToggle()
    {
        isStabilized = !isStabilized;
    }

    public void ToggleCamera()
    {
        currentCamera++;
        if (currentCamera >= camerasGO.Length)
            currentCamera = 0;

        foreach (GameObject g in camerasGO)
        {
            g.GetComponent<Camera>().enabled = false;
            g.GetComponent<AudioListener>().enabled = false;
        }

        camerasGO[currentCamera].GetComponent<Camera>().enabled = true;

        camerasGO[currentCamera].GetComponent<AudioListener>().enabled = true;
    }

    public void StartDefaultCamera()
    {
        camerasGO[0].GetComponent<Camera>().enabled = true;
        camerasGO[0].GetComponent<AudioListener>().enabled = true;
    }
}
