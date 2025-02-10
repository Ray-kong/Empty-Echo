using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startFirstMission() {
        // Load the specified scene
        SceneManager.LoadScene("Tutorial Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
