using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    private GameObject player;
    private MouseLook mouseLook;
    //private GameObject keycard;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mouseLook = player.GetComponent<MouseLook>();
       // keycard = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                // set player bool hasKeycard to true
                mouseLook.hasKeycard = true;
                // destroy keycard when player presses f to pick it up
                Destroy(this.gameObject);
                Debug.Log("Player should now have the keycard");
            }
        }
    }
}
