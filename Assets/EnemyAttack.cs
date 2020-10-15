using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent whateverYouCallYourVaraibleForNavMeshAgent;

    public Transform makeAgentGoToThisLocation;



    // Start is called before the first frame update
    void Start()
    {
        whateverYouCallYourVaraibleForNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAttackDestination();
    }

    void SetAttackDestination() 
    {
        Vector3 targetVector = makeAgentGoToThisLocation.transform.position;
        whateverYouCallYourVaraibleForNavMeshAgent.SetDestination(targetVector);
        // EZPZ
    }
}
