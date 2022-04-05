using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    public float hostileRadius = 35f;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GroundUnitSingleton.instance.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Set player as destination and start the running animation
        if (distance <= hostileRadius)
        {
            if(!messageShown)
            {
                Debug.Log("Attacking - Distance is " + distance.ToString());
                messageShown = true;
            }
            
            agent.SetDestination(target.position);
            //Start running and stop when close to target
            SetRunning(distance > agent.stoppingDistance + 0.05);
        }
    }

    private bool messageShown = false;

    private void SetRunning(bool isRunning)
    {
        Animator animator = this.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("IsRunning", isRunning);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hostileRadius);
    }
}
