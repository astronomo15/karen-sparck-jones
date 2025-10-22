using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    public float totalTime = 300f; // 5 minutos
    private float currentTime;

    [Header("UI")]
    public TextMeshProUGUI timerText; // só o timer usa TMP
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Botões de Vitória")]
    public Button[] botoesParaVitoria;
    private int botoesClicados = 0;
    private bool[] botoesJaClicados;

    [Header("Objeto a ser desativado")]
    public GameObject objetoParaDesativar; // você escolhe no Inspector

    [Header("Cenas")]
    public string nomeCenaMenu; // coloque aqui no Inspector o nome da cena do menu

    private bool jogoAcabou = false;

    void Start()
    {
        currentTime = totalTime;
        botoesJaClicados = new bool[botoesParaVitoria.Length];

        for (int i = 0; i < botoesParaVitoria.Length; i++)
        {
            int index = i;
            botoesParaVitoria[i].onClick.AddListener(() => BotaoClicado(index));
        }

        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (jogoAcabou) return;

        currentTime -= Time.deltaTime;
        AtualizarTimerUI();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            GameOver();
        }
    }

    void AtualizarTimerUI()
    {
        int minutos = Mathf.FloorToInt(currentTime / 60f);
        int segundos = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutos:00}:{segundos:00}";
    }

    void BotaoClicado(int index)
    {
        if (jogoAcabou) return;

        if (!botoesJaClicados[index])
        {
            botoesJaClicados[index] = true;
            botoesClicados++;

            if (botoesClicados >= 8)
            {
                Venceu();
            }
        }
    }

    void GameOver()
    {
        jogoAcabou = true;
        timerText.gameObject.SetActive(false); 
        gameOverPanel.SetActive(true);

        if (objetoParaDesativar != null)
            objetoParaDesativar.SetActive(false);
    }

    void Venceu()
    {
        jogoAcabou = true;
        timerText.gameObject.SetActive(false);
        winPanel.SetActive(true);

        if (objetoParaDesativar != null)
            objetoParaDesativar.SetActive(false);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarMenu()
    {
        if (!string.IsNullOrEmpty(nomeCenaMenu))
        {
            SceneManager.LoadScene(nomeCenaMenu);
        }
        else
        {
            Debug.LogWarning("Nome da cena do menu não foi definido no Inspector!");
        }
    }
}
