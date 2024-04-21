using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _groundParallax;
    [SerializeField] private MeshRenderer _backgroundParallax;
    private float animationSpeed = 0.25f;
    
    private void Update()
    {
        _groundParallax.material.mainTextureOffset += new Vector2(animationSpeed * 2 * Time.deltaTime, 0);
        _backgroundParallax.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}