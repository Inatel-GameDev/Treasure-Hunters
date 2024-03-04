using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffectMultiplier;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        // Calcula o tamanho da textura em unidades do mundo para saber quando repetir
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit * transform.localScale.x;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier, 0f);
        lastCameraPosition = cameraTransform.position;

        // Verifica se é hora de repetir a textura considerando a direção do movimento
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}