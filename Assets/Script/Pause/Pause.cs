using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
 {

    public GameObject CanvasPause;
    public bool Pausedd, Return;
  

    void Update()
    {
        Paused();
    }
    
    public void Paused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Pausedd == false)
            {
                Time.timeScale = 0f;
                CanvasPause.SetActive(true);
                Pausedd = true;
            }
            else if (Pausedd == true)
            {
                Time.timeScale = 1f;
                CanvasPause.SetActive(false);
                Pausedd = false;

            }
        }
       

    }

}
