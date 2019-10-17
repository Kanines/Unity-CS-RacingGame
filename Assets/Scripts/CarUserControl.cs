using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");

            if (Input.GetKeyDown(KeyCode.V))
                GameObject.Find("Cameras").GetComponent<CameraStable>().StabilizeToggle();
            if (Input.GetKeyDown(KeyCode.C))
                GameObject.Find("Cameras").GetComponent<CameraStable>().ToggleCamera();
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
            if (Input.GetKeyDown(KeyCode.R))
            {

                GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(257.1f, 60.25f, 354.2f);
                GameObject.FindGameObjectWithTag("Player").transform.rotation = Quaternion.Euler(0, 90, 0);
                GameObject.Find("LapTimerManager").GetComponent<LapTimerManager>().ResetTimer();
            }
            if (Input.GetKeyDown(KeyCode.L))
                GameObject.Find("EventSystem").GetComponent<MenuManager>().ToggleLeaderboard();


            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
