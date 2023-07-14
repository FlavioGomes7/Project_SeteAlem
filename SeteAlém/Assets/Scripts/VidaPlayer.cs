using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    [SerializeField()]
    int vida = 3;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("inimigoMenor"))
        {
            TomaDano();
        }
    }
    public void TomaDano()
    {
        Debug.Log("tomei dano");
        vida--;
        if (vida == 0)
        {
            Morrer();
        }
    }
    public void Morrer()
    {
        Destroy(gameObject);
    }
}
