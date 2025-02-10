using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private Anxiety anxiety;
    private Oxygen oxygen;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anxiety = player.GetComponent<Anxiety>();
        oxygen = player.GetComponent<Oxygen>();
    }

    private void Update()
    {
        if (anxiety.GetAnxietyPercent() > 99.9f || oxygen.GetOxygenPercent() < 0.01f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name + "DeathScreen");
        }
    }
}
