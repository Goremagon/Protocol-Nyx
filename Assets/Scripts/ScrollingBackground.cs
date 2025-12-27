using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 0.5f;
    private Renderer meshRenderer;
    private Material backgroundMaterial;

    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        if (meshRenderer == null)
        {
            Debug.LogWarning("ScrollingBackground requires a Renderer. Disabling.");
            enabled = false;
            return;
        }
        backgroundMaterial = meshRenderer.material;
    }

    void Update()
    {
        // Scroll the texture on the material
        Vector2 offset = new Vector2(0, Time.time * speed);
        if (backgroundMaterial != null)
        {
            backgroundMaterial.mainTextureOffset = offset;
        }
    }
}
