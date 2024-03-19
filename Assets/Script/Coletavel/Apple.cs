using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer SR;
    private CircleCollider2D Circle;
    public GameObject Colected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        SR= GetComponent<SpriteRenderer>();
        Circle= GetComponent<CircleCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
      if(collider.gameObject.tag == "Player")
        {
            SR.enabled = false;
            Circle.enabled = false;
            Colected.SetActive(true);
            GameController.instance.TotalScore += Score;
            GameController.instance.UpdateScoreText();
            Destroy(gameObject,0.25f);

        }
        


    }
}
