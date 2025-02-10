using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Light : MonoBehaviour
{
    private Anxiety anxiety;
    [SerializeField] private float decreaseAnxietyBy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anxiety = player.GetComponent<Anxiety>();
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("COuld not be a player");
        if (other.tag == "Player")
        {
            anxiety.DecreaseAnxiety(decreaseAnxietyBy);
            Debug.Log("Is a player");
        }
    }
}