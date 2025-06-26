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

            if (botoesClicados >= 5)
            {
                Venceu();
            }
        }
    }

    void GameOver()
    {
        jogoAcabou = true;
        timerText.gameObject.SetActive(false); // some com o timer
        gameOverPanel.SetActive(true);
    }

    void Venceu()
    {
        jogoAcabou = true;
        timerText.gameObject.SetActive(false); // some com o timer também na vitória
        winPanel.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
