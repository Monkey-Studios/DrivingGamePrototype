using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouchingScript : MonoBehaviour
{
    CapsuleCollider playerCol;
    float origionalHeight;
    public float reduceHeight;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        origionalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        //Crouch
        if (Input.GetKeyDown(KeyCode.C))
            Crouch();
        else if (Input.GetKeyUp(KeyCode.C))
            GetUp();
    }

    //Method used to reduce height
    void Crouch()
    {
        player.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f); 
        
    }

    //Method used to reset height
    void GetUp()
    {
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
    }
}
