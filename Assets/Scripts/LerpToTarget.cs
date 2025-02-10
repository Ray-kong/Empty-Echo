using UnityEngine;

public class LerpToTarget : MonoBehaviour
{
    public Transform targetTransform; // The target position to lerp to

    private bool lerpToTarget = false; // Flag indicating whether to lerp to the target
    private float lerpSpeed = 5f; // The speed of the lerp

    private void Update()
    {
        // Check if lerpToTarget is true in the LerpAndDelete script attached to the parent (up to 7 generations)
        LerpAndDelete lerpScript = GetComponentInParentRecursive<LerpAndDelete>(transform, 7);
        if (lerpScript != null && lerpScript.lerpToTarget)
        {
            lerpToTarget = true;
        }

        // Lerp to the target position if lerpToTarget is true
        if (lerpToTarget)
        {
            // Calculate the new position to lerp to
            Vector3 newPosition = Vector3.Lerp(transform.position, targetTransform.position, Time.deltaTime * lerpSpeed);

            // Move the object to the new position
            transform.position = newPosition;
        }
    }

    private T GetComponentInParentRecursive<T>(Transform currentTransform, int generationCount) where T : Component
    {
        if (generationCount <= 0)
            return null;

        T component = currentTransform.GetComponentInParent<T>();
        if (component != null)
            return component;

        if (currentTransform.parent != null)
            return GetComponentInParentRecursive<T>(currentTransform.parent, generationCount - 1);

        return null;
    }
}
