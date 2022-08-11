using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCar : MonoBehaviour
{
    //Declaring Variables
    public bool clickEnter;
    public Transform playerCamera;
    public GameObject carCamera;
    public GameObject player;
    private bool inCar;
    private bool exitCar;
    //
    private void FixedUpdate()
    {
        if(clickEnter == true)
        {
            clickEnter = false;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, 1))
            {
                hit.transform.GetComponent<CarController>().inCar = true;
                carCamera.SetActive(true);
                player.transform.parent = hit.transform;
                player.SetActive(false);
                inCar = true;
            }
        }
    }
    //
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !inCar)
        {
            clickEnter = true;
        }
        if(Input.GetKeyDown(KeyCode.F) && inCar)
        {
            transform.GetComponent<CarController>().inCar = false;
            carCamera.SetActive(false);
            player.SetActive(true);
            player.transform.parent = null;
            inCar = false;
        }
    }
}
