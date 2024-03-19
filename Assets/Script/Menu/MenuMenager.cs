using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
    [SerializeField] private string Level_1;
    [SerializeField] private GameObject PainelOpcoes;
    [SerializeField] private GameObject PainelCreditos;



    public void PlayGame()
    {
        SceneManager.LoadScene(Level_1);

    }
    public void OpenCredits()
    {
        PainelCreditos.SetActive(true);

    }
    public void ClodeCredits()
    {
        PainelCreditos.SetActive(false);

    }

    public void ExitGame()
    {
        
      UnityEditor.EditorApplication.isPlaying = false; //editor unity 
       // Application.Quit();   //jogo compilado


    }

}
