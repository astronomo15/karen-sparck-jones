using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float parallaxSpeed = 2f;   // velocidade do movimento
    public float layerMultiplier = 1f; // multiplicador para dar efeito em diferentes layers

    [Header("Limites de Movimento")]
    public float minX = -5f;  // limite esquerdo
    public float maxX = 5f;   // limite direito

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = parallaxSpeed * layerMultiplier * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = -parallaxSpeed * layerMultiplier * Time.deltaTime;
        }

        // aplica o movimento
        Vector3 newPos = transform.position + new Vector3(moveX, 0f, 0f);

        // limita o movimento no eixo X
        newPos.x = Mathf.Clamp(newPos.x, startPos.x + minX, startPos.x + maxX);

        transform.position = newPos;
    }
}
