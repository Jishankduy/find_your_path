using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public LayerMask _targetLayer;
    public GameObject GameCanVas;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        MoveToTarget();
    }

    void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void OnTriggerEnter(Collider other)
    {
        if((_targetLayer.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            GameCanVas.SetActive(true);
        }
    }
}
