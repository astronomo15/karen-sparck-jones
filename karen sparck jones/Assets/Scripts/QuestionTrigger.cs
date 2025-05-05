using UnityEngine;
using UnityEngine.UI;

public class QuestionTrigger : MonoBehaviour
{
    public GameObject questionCanvas;
    [SerializeField] private GameObject desabilitado;

   public void abrir()
    {
        desabilitado.SetActive(false);
        questionCanvas.SetActive(true);
    }
    
  public void Voltar()
    {
        desabilitado.SetActive(true);
        questionCanvas.SetActive(false);

    }

}
