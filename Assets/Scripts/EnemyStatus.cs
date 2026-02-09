using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    private NavMeshAgent _agent;
    
    protected override void Start()
    {
        base.Start();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }

    protected override void OnDie()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
