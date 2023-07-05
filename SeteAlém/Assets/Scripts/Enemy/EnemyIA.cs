using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] ways;
    public Transform playerTarger;
    int wayIndex;
    Vector3 tg;
    bool isPatrolling = true; // Indica se o objeto est� em patrulha ou persegui��o
    public float detectionRadius = 5f; // Raio de detec��o do visor

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestino();
    }

    void Update()
    {
        if (isPatrolling)
        {
            if (Vector3.Distance(transform.position, tg) < 1)
            {
                WayEnd();
                UpdateDestino();
            }

            // Detectar o objeto "Player" dentro do raio de detec��o
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    StartChasing(collider.transform);
                    break;
                }
            }
        }
        else
        {
            // Se n�o estiver patrulhando, continuar perseguindo o objeto "Player"
            agent.SetDestination(playerTarger.position);

            // Verificar se o objeto "Player" saiu do raio de detec��o
            if (Vector3.Distance(transform.position, playerTarger.position) > detectionRadius)
            {
                StopChasing();
                UpdateDestino();

            }
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
        if (wayIndex == ways.Length)
        {
            wayIndex = 0;
        }
    }

    void StartChasing(Transform target)
    {
        isPatrolling = false;
        playerTarger = target;
    }

    void StopChasing()
    {
        isPatrolling = true;
        playerTarger = null;
    }

    // Visualizar o raio de detec��o no editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
