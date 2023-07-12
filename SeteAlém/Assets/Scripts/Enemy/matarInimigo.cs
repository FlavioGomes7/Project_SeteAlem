using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matarInimigo : MonoBehaviour
{
    InimigoPequeno _IP;
    private void Start()
    {
        _IP = FindObjectOfType<InimigoPequeno>();
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("verdadeiro");
            _IP.podeMatar = true;
        }
        else
        {
            _IP.podeMatar = false;
            Debug.Log("falso");
        }
    }
}
