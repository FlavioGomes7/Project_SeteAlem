using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    [Range(10, 360)]
    public int viewRayCount;
    [SerializeField][Range(0, 360)] private float fieldOfViewAngle; // Angle of the field of view
    [SerializeField] private LayerMask playerLayer; // LayerMask to find the player
    [SerializeField] private LayerMask obstacleLayer;
    NavMeshAgent agent;
    public Transform[] ways;
    public Transform playerTarger;
    int wayIndex;
    Vector3 tg;
    bool isPatrolling = true; // Indica se o objeto está em patrulha ou perseguição
    public float detectionRadius = 5f; // Raio de detecção do visor

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

            // Detect the player within the detection radius
            if (Physics.CheckSphere(transform.position, detectionRadius, playerLayer))
            {
                // Get the player
                Collider player = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer)[0];

                Vector3 directionToTarget = (player.transform.position - transform.position).normalized;
                if (Vector3.Dot(transform.forward, directionToTarget) > Mathf.Cos(fieldOfViewAngle / 2f))
                {
                    if (!Physics.Linecast(transform.position, player.transform.position, obstacleLayer))
                    {
                        Debug.DrawLine(transform.position, player.transform.position, Color.green);
                        StartChasing(player.transform);
                    }
                    else
                    {
                        Debug.DrawLine(transform.position, player.transform.position, Color.red);
                    }
                }
            }
        }
        else
        {
            // If not patrolling, continue chasing the player
            agent.SetDestination(playerTarger.position);

            // Check if the player has left the detection radius
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

    // Visualizar o raio de detecção no editor
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        DrawFieldOfView();
    }

    void DrawFieldOfView()
    {
        float stepAngleSize = fieldOfViewAngle / viewRayCount;
        for (int i = 0; i <= viewRayCount; i++)
        {
            float angle = transform.eulerAngles.y - fieldOfViewAngle / 2 + stepAngleSize * i;
            Vector3 direction = DirFromAngle(angle, false);
            Gizmos.DrawRay(transform.position, direction * detectionRadius);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
