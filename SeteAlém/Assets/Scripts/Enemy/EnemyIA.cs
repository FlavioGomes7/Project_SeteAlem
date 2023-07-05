using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] ways;
    int wayIndex;
    Vector3 tg;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestino();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, tg) < 1)
        {
            WayEnd();
            UpdateDestino();
        }
    }

    void UpdateDestino()
    {
        tg = ways[wayIndex].position;
        agent.SetDestination(tg);
    }

    void WayEnd()
    {
        wayIndex++;
        if(wayIndex == ways.Length)
        {
            wayIndex = 0;   
        }
    }
}
