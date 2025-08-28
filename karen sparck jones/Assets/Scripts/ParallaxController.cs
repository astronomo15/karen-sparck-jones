using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float moveSpeed = 2f;       // velocidade do movimento
    public float layerMultiplier = 1f; // profundidade/parallax

    [Header("Pontas do Parallax")]
    public Transform pontaEsquerda;    // objeto vazio no canto esquerdo do parallax
    public Transform pontaDireita;     // objeto vazio no canto direito do parallax

    [Header("Limites da Cena")]
    public Transform limiteEsquerdo;   // limite fixo esquerdo
    public Transform limiteDireito;    // limite fixo direito

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveX = moveSpeed * layerMultiplier * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = -moveSpeed * layerMultiplier * Time.deltaTime;
        }

        // calcula a posição nova
        Vector3 newPos = transform.position + new Vector3(moveX, 0f, 0f);

        // impede de ultrapassar os limites
        float esquerda = pontaEsquerda.position.x + (newPos.x - transform.position.x);
        float direita = pontaDireita.position.x + (newPos.x - transform.position.x);

        if (esquerda < limiteEsquerdo.position.x)
        {
            newPos.x = transform.position.x + (limiteEsquerdo.position.x - pontaEsquerda.position.x);
        }
        else if (direita > limiteDireito.position.x)
        {
            newPos.x = transform.position.x + (limiteDireito.position.x - pontaDireita.position.x);
        }

        transform.position = newPos;
    }
}
