using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public Material minimapMaterial;

    void LateUpdate()
    {
        // Captures camera rendering in texture
        RenderTexture.active = minimapMaterial.mainTexture as RenderTexture;
        Camera.main.Render();
        RenderTexture.active = null;
    }
}
