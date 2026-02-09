using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    private NavMeshAgent _agent;
    private EnemyStatus _status;
    private RaycastHit[] _raycastHists = new RaycastHit[10];
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 1;
        _agent.angularSpeed = 180;
        _agent.acceleration = 3;
        _status = GetComponent<EnemyStatus>();
    }

    public void OnDetectObject(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }

        if (collider.CompareTag("Player"))
        {
            Vector3 positionDiff = collider.transform.position - transform.position;
            float distance = positionDiff.magnitude;
            Vector3 direction = positionDiff.normalized;
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHists, distance, raycastLayerMask);

            if (hitCount == 0)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }
}
