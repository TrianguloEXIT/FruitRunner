using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    private Image imagem;
    private Color corInicial = Color.black;
    private Color corFinal = Color.white;
    public float tempoTotal = 5f;
    private float tempoDecorrido = 0f;

    // Objeto que será desativado após a imagem ser revelada
    public GameObject objetoParaDesativar;
    public GameObject RecebeMenu;
    public  Menu Menulogos;
    public bool AtivadorLogo = false;
    private bool imagemRevelada = false;
    private bool imagemEscurecida = false;

    void Start()
    {
        
        AtivadorLogo = RecebeMenu.GetComponent<Menu>().Ativador;
        imagem = GetComponent<Image>();
        imagem.color = corInicial;
    }

    void Update()
    {
        tempoDecorrido += Time.deltaTime;

        // Verifica se a imagem ainda não foi totalmente revelada
        if (!imagemRevelada)
        {
            float proporcao = Mathf.Clamp01(tempoDecorrido / tempoTotal);
            Color corAtual = Color.Lerp(corInicial, corFinal, proporcao);
            imagem.color = corAtual;

            // Verifica se a imagem foi totalmente revelada
            if (proporcao >= 1f)
            {
                imagemRevelada = true;
                tempoDecorrido = 0f; // Reseta o tempo decorrido para o atraso antes de escurecer a imagem
            }
        }
        else if (!imagemEscurecida)
        {
            // Espera 1 segundo antes de escurecer a imagem novamente
            if (tempoDecorrido >= 1f)
            {
                Color corAtual = Color.Lerp(corFinal, corInicial, Mathf.Clamp01((tempoDecorrido - 1f) / tempoTotal));
                imagem.color = corAtual;

                // Verifica se a imagem foi totalmente escurecida novamente
                if (corAtual == corInicial)
                {
                    imagemEscurecida = true;
                    tempoDecorrido = 0f; // Reseta o tempo decorrido para o atraso antes de desativar o objeto
                }
            }
        }
        else
        {
            // Desativa o objeto após o atraso
            if (tempoDecorrido >= 1f)
            {
                Menulogos.Ativador = true;
                AtivadorLogo = true;
                objetoParaDesativar.SetActive(false);
            }
        }
    }
}
