using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;

public class Menu: MonoBehaviour
{
    public bool Ativador=false; // Refer�ncia ao Canvas
    public TextMeshProUGUI texto; // Refer�ncia ao objeto de TextMeshPro
    public Image imagem; // Refer�ncia � imagem para ajustar a transpar�ncia
    public float posicaoFinalX = 5f; // Posi��o final desejada para o texto na coordenada X
    public float velocidadeMovimento = 1f; // Velocidade de movimento
    public float transparenciaAlvo = 0.5f; // Transpar�ncia alvo para a imagem
    public float velocidadeTransparencia = 0.5f; // Velocidade de ajuste de transpar�ncia
    public GameObject Button1, Button2, Button3;
    public float Tempoativarbotoes,TempoMoverTexto;
    private bool canvasHabilitado = false; // Vari�vel para rastrear se o Canvas est� habilitado
    private bool movendo = true; // Vari�vel para rastrear se o texto est� em movimento
    private bool ajustandoTransparencia = false; // Vari�vel para rastrear se a transpar�ncia est� sendo ajustada
    private bool aumentandoTransparencia = true; // Vari�vel para rastrear se a transpar�ncia est� aumentando ou diminuindo
    private Color corOriginal; // Cor original da imagem

    void Start()
    {
        // Salva a cor original da imagem
        corOriginal = imagem.color;
    }

    void Update()
    {
       
        // Verifica se o Canvas est� habilitado
        if (Ativador==false)
        {
            canvasHabilitado = false;
        }
        else
        {
            canvasHabilitado = true;
            Invoke("AtivarBotoes", Tempoativarbotoes);
        }

        // Move suavemente o texto na posi��o X se o Canvas estiver habilitado
        if (canvasHabilitado==true && movendo)
        {
            Invoke("MoverTextoSuavemente", TempoMoverTexto);
        }

        // Ajusta a transpar�ncia da imagem suavemente se estiver sendo ajustada
        if (ajustandoTransparencia)
        {
            AjustarTransparencia();
        }
    }

    void MoverTextoSuavemente()
    {
        // Calcula a nova posi��o do texto
        float novaPosicaoX = Mathf.MoveTowards(texto.rectTransform.anchoredPosition.x, posicaoFinalX, velocidadeMovimento * Time.deltaTime);

        // Aplica a nova posi��o ao objeto de texto
        Vector3 posicaoAtual = texto.rectTransform.anchoredPosition;
        texto.rectTransform.anchoredPosition = new Vector3(novaPosicaoX, posicaoAtual.y, posicaoAtual.z);

        // Verifica se o texto atingiu a posi��o final
        if (Mathf.Approximately(novaPosicaoX, posicaoFinalX))
        {
            movendo = false; // Define movendo como falso para parar o movimento
            // Inicia o ajuste de transpar�ncia da imagem
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
        // Calcula a nova transpar�ncia da imagem
        float novaTransparencia;

        if (aumentandoTransparencia)
        {
            novaTransparencia = Mathf.MoveTowards(imagem.color.a, transparenciaAlvo, velocidadeTransparencia * Time.deltaTime);
        }
        else
        {
            novaTransparencia = Mathf.MoveTowards(imagem.color.a, corOriginal.a, velocidadeTransparencia * Time.deltaTime);
        }

        // Cria uma nova cor com a transpar�ncia ajustada
        Color novaCor = new Color(corOriginal.r, corOriginal.g, corOriginal.b, novaTransparencia);

        // Aplica a nova cor � imagem
        imagem.color = novaCor;

        // Verifica se a transpar�ncia atingiu o alvo
        if (Mathf.Approximately(novaTransparencia, transparenciaAlvo))
        {
            aumentandoTransparencia = false; // Define aumentandoTransparencia como falso para come�ar a diminuir a transpar�ncia
        }

        // Verifica se a transpar�ncia voltou ao normal
        if (Mathf.Approximately(novaTransparencia, corOriginal.a))
        {
            ajustandoTransparencia = false; // Define ajustandoTransparencia como falso para parar o ajuste de transpar�ncia
        }
        

    }
}
