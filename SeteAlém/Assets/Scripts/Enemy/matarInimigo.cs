using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matarInimigo : MonoBehaviour
{
    Player_Inventory inventory;
    public bool podeMatar;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Inventory>();

    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (inventory.NumberOfScissors > 0)
            {
                Debug.Log("verdadeiro");
                podeMatar = true;
            }
            else
            {
                Debug.Log("NAO PODE MATAR -  FALTA DE TESOURAS - falso");
                podeMatar = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("SAIU");
        podeMatar = false;
    }
}
