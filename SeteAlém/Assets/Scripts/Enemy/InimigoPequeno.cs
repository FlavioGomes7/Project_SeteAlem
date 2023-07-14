using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ToyEstado 
{
    ESTADOPARADO,
    PERSERGUINDO
};

public class InimigoPequeno : MonoBehaviour
{
    public bool podeMatar = false;

    [SerializeField()]
    private float           anguloVisao = 90;
    [SerializeField()]
    private float           distanciaVisao = 5;

    private NavMeshAgent    inimigo;

    [SerializeField()]
    private GameObject      player;

    private Transform       point;

    public ToyEstado EstadoBriquedo;
    void Start()
    {
        EstadoBriquedo = ToyEstado.ESTADOPARADO;
        inimigo = GetComponent<NavMeshAgent>();
        point = GameObject.Find("PlayerCapsule").transform;
    }


    void Update()
    {
        if(ToTeVendo())
        {
            EstadoBriquedo = ToyEstado.PERSERGUINDO;
        }
        else
        {
            EstadoBriquedo = ToyEstado.ESTADOPARADO;
        }
 

        if(EstadoBriquedo == ToyEstado.PERSERGUINDO)
        {
            
            Cacando();
        }

        if(Input.GetMouseButtonDown(0) && podeMatar == true)
        {
            InimigoMorre();
        }
        
    }

    private void InimigoMorre()
    {
        Destroy(gameObject);
    }

    void Cacando()
    {
        inimigo.SetDestination(point.position);
       
    }
    void Amimi()
    {

    }
    bool ToTeVendo()
    {
        Vector3 dir = point.position - transform.position;
        float angulo = Vector3.Angle(dir, transform.forward);
        float distanci = Vector3.Distance(point.position, transform.position);

        RaycastHit hit;

        if(angulo <= anguloVisao && distanci <= distanciaVisao)
        {
            if(Physics.Linecast(transform.position, point.position, out  hit))
            {
                if(hit.transform.tag == "Player")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    
}
