using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DoorMovement : MonoBehaviour
{
     
    public GameObject top;
    public GameObject bottom;
    public GameObject right;
    public GameObject left;

    private bool isOpen;
     
    public float statusOpen = 10f;
    public float statusClose = 0f;
     
    public float movemenAmount = 10f;
     
    bool playerIsHere;
     
    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
        isOpen = false;
    }
 
    // Update is called once per frame
    void Update()   
    {
        if (playerIsHere)
        {
            if (!isOpen && Input.GetKeyDown("f"))
            {
                Debug.Log("door open");
                right.transform.Translate(100 * Time.deltaTime, 0f, 0f);
                isOpen = true;
            }
            else if (isOpen && Input.GetKeyDown("f"))
            {
                Debug.Log("door closed");
                right.transform.Translate(-100 * Time.deltaTime, 0f, 0f);
                isOpen = false;
            }
        } 
    }
     
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("player detected");
            playerIsHere = true;
        }
    }
     
    private void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("player lost");
            playerIsHere = false;
        }
    }
}