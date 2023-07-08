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
    [SerializeField()]
    private float           anguloVisao = 90;
    [SerializeField()]
    private float           distanciaVisao = 5;
    [SerializeField()]
    private float           raio = 0.7f;
    [SerializeField()]
    private float           eixoY = 0.4f;

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
            Debug.Log("caçando");
        }
        else
        {
            EstadoBriquedo = ToyEstado.ESTADOPARADO;
        }

        if(Interacao() && Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }

        if(EstadoBriquedo == ToyEstado.PERSERGUINDO)
        {
            Cacando();
        }
        
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
    bool Interacao()
    {
        Collider[] hitC = Physics.OverlapSphere(gameObject.transform.position + new Vector3(0, eixoY, 0), raio);
                
        if ( hitC != null )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3( 0, 0,eixoY), raio);
    }
}
