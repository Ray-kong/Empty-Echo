using System.Collections;
using UnityEngine;

public class LerpingObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;
    public bool moveToB = true;

    private Transform target;
    private bool isMoving = false;

    private void Start()
    {
        target = moveToB ? pointB : pointA;
        moveToB = false;
    }

    private void Update()
    {
        if (isMoving)
            return;

        if (moveToB && target != pointB)
        {
            target = pointB;
            StartCoroutine(MoveObject(transform.position, target.position));
        }
        else if (!moveToB && target != pointA)
        {
            target = pointA;
            StartCoroutine(MoveObject(transform.position, target.position));
        }
    }

    private IEnumerator MoveObject(Vector3 startPos, Vector3 targetPos)
    {
        isMoving = true;
        float startTime = Time.time;
        float journeyLength = Vector3.Distance(startPos, targetPos);

        while (transform.position != targetPos)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPos, targetPos, fractionOfJourney);
            yield return null;
        }

        isMoving = false;
    }
}
