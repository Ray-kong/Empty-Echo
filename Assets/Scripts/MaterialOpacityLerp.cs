using UnityEngine;
using UnityEngine.UI;

public class MaterialOpacityLerp : MonoBehaviour
{
    public float lerpSpeed = 1f; // The rate at which the opacity will change

    private Image image;
    private Material originalMaterial;
    private Material copiedMaterial;
    private bool isLerping;

    private void Awake()
    {
        image = GetComponent<Image>();
        originalMaterial = image.material;
    }

    public void StartOpacityLerp()
    {
        if (!isLerping)
        {
            isLerping = true;
            copiedMaterial = Instantiate(originalMaterial);
            image.material = copiedMaterial;
            StartCoroutine(LerpOpacity());
        }
    }

    private System.Collections.IEnumerator LerpOpacity()
    {
        float elapsedTime = 0f;
        Color startColor = copiedMaterial.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * lerpSpeed;
            copiedMaterial.color = Color.Lerp(startColor, targetColor, elapsedTime);
            yield return null;
        }

        isLerping = false;
        image.material = originalMaterial;
    }
}
