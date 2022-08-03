using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMoveTowards : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject target;
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = target.transform.position;
    }
}
