using UnityEngine;

public class AnimatorControllerToggle : MonoBehaviour
{
    public float enableDuration = 2f;  // Duration to enable the Animator
    public float disableDuration = 1f; // Duration to disable the Animator

    private Animator animator;
    private bool isAnimatorEnabled = true;

    private void Start()
    {
        // Get the Animator component attached to the game object
        animator = GetComponent<Animator>();

        // Start the toggling coroutine
        StartCoroutine(ToggleAnimatorCoroutine());
    }

    private System.Collections.IEnumerator ToggleAnimatorCoroutine()
    {
        while (true)
        {
            if (isAnimatorEnabled)
            {
                // Disable the Animator after the enable duration
                yield return new WaitForSeconds(enableDuration);
                animator.enabled = false;
                isAnimatorEnabled = false;
            }
            else
            {
                // Enable the Animator after the disable duration
                yield return new WaitForSeconds(disableDuration);
                animator.enabled = true;
                isAnimatorEnabled = true;
            }
        }
    }
}
