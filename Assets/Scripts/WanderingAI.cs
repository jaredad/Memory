using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WanderingAI : MonoBehaviour
{

    public GameObject p;
    public int MoveSpeed = 4;
    public float wanderRadius;
    public float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(p.transform.position, this.transform.position) < 20)
        {
            transform.LookAt(p.transform);
            agent.SetDestination(p.transform.position);
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
