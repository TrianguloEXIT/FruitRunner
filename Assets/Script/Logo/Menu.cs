using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;

public class Menu: MonoBehaviour
{
    public bool Ativador=false; // Referência ao Canvas
    public TextMeshProUGUI texto; // Referência ao objeto de TextMeshPro
    public Image imagem; // Referência à imagem para ajustar a transparência
    public float posicaoFinalX = 5f; // Posição final desejada para o texto na coordenada X
    public float velocidadeMovimento = 1f; // Velocidade de movimento
    public float transparenciaAlvo = 0.5f; // Transparência alvo para a imagem
    public float velocidadeTransparencia = 0.5f; // Velocidade de ajuste de transparência
    public GameObject Button1, Button2, Button3;
    public float Tempoativarbotoes,TempoMoverTexto;
    private bool canvasHabilitado = false; // Variável para rastrear se o Canvas está habilitado
    private bool movendo = true; // Variável para rastrear se o texto está em movimento
    private bool ajustandoTransparencia = false; // Variável para rastrear se a transparência está sendo ajustada
    private bool aumentandoTransparencia = true; // Variável para rastrear se a transparência está aumentando ou diminuindo
    private Color corOriginal; // Cor original da imagem

    void Start()
    {
        // Salva a cor original da imagem
        corOriginal = imagem.color;
    }

    void Update()
    {
       
        // Verifica se o Canvas está habilitado
        if (Ativador==false)
        {
            canvasHabilitado = false;
        }
        else
        {
            canvasHabilitado = true;
            Invoke("AtivarBotoes", Tempoativarbotoes);
        }

        // Move suavemente o texto na posição X se o Canvas estiver habilitado
        if (canvasHabilitado==true && movendo)
        {
            Invoke("MoverTextoSuavemente", TempoMoverTexto);
        }

        // Ajusta a transparência da imagem suavemente se estiver sendo ajustada
        if (ajustandoTransparencia)
        {
            AjustarTransparencia();
        }
    }

    void MoverTextoSuavemente()
    {
        // Calcula a nova posição do texto
        float novaPosicaoX = Mathf.MoveTowards(texto.rectTransform.anchoredPosition.x, posicaoFinalX, velocidadeMovimento * Time.deltaTime);

        // Aplica a nova posição ao objeto de texto
        Vector3 posicaoAtual = texto.rectTransform.anchoredPosition;
        texto.rectTransform.anchoredPosition = new Vector3(novaPosicaoX, posicaoAtual.y, posicaoAtual.z);

        // Verifica se o texto atingiu a posição final
        if (Mathf.Approximately(novaPosicaoX, posicaoFinalX))
        {
            movendo = false; // Define movendo como falso para parar o movimento
            // Inicia o ajuste de transparência da imagem
            ajustandoTransparencia = true;
        }
    }
    public void AtivarBotoes()
    {
        

            Button1.SetActive(true);
            Button2.SetActive(true);
            Button3.SetActive(true);

        

    }
   
    void AjustarTransparencia()
    {
        // Calcula a nova transparência da imagem
        float novaTransparencia;

        if (aumentandoTransparencia)
        {
            novaTransparencia = Mathf.MoveTowards(imagem.color.a, transparenciaAlvo, velocidadeTransparencia * Time.deltaTime);
        }
        else
        {
            novaTransparencia = Mathf.MoveTowards(imagem.color.a, corOriginal.a, velocidadeTransparencia * Time.deltaTime);
        }

        // Cria uma nova cor com a transparência ajustada
        Color novaCor = new Color(corOriginal.r, corOriginal.g, corOriginal.b, novaTransparencia);

        // Aplica a nova cor à imagem
        imagem.color = novaCor;

        // Verifica se a transparência atingiu o alvo
        if (Mathf.Approximately(novaTransparencia, transparenciaAlvo))
        {
            aumentandoTransparencia = false; // Define aumentandoTransparencia como falso para começar a diminuir a transparência
        }

        // Verifica se a transparência voltou ao normal
        if (Mathf.Approximately(novaTransparencia, corOriginal.a))
        {
            ajustandoTransparencia = false; // Define ajustandoTransparencia como falso para parar o ajuste de transparência
        }
        

    }
}
