using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetector : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    //public GameObject monsterRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [SerializeField] private float increaseAnxietyBy = 10f;

    private GameObject player;

    public bool canSeeMonster;
    private Anxiety anxiety;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //monsterRef = GameObject.FindGameObjectWithTag("Monster");
        anxiety = GetComponent<Anxiety>();
        StartCoroutine(MonsterDetectorRoutine());
    }

    private IEnumerator MonsterDetectorRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length > 0)
        {
            foreach (Collider c in rangeChecks)
            {
                Transform target = c.transform;
                Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
                {
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    {
                        canSeeMonster = true;
                        Debug.Log("Player is looking at Monster");
                        anxiety.IncreaseAnxiety(increaseAnxietyBy);
                    }
                    else
                    {
                        canSeeMonster = false;
                        Debug.Log("Player is looking in the direction of the monster but there " +
                            "is an obstacle in the way.");
                    }
                }
                else
                {
                    canSeeMonster = false;
                    Debug.Log("Monster is not in player's fov");
                }

            }
        }
        else if (canSeeMonster)
        {
            canSeeMonster = false;
            Debug.Log("Player is near monster");
        }

    }

}
