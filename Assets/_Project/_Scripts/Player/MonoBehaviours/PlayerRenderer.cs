using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRenderer : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogError("Renderer component not found on the Player GameObject.");
        }
    }

    public void SetVisibility(float alpha)
    {
        if (_renderer != null && _renderer.material != null)
        {
            _renderer.material.SetFloat("_Alpha", alpha);
            _renderer.shadowCastingMode = ShadowCastingMode.On;
        }
        else
        {
            Debug.LogError("Renderer or material is not set.");
        }
    }
}
