using UnityEngine;

public class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal, Attack, Die
    }

    [SerializeField] private float lifeMax = 10;
    public bool IsMovable => StateEnum.Normal == _state;
    public bool IsAttackable => StateEnum.Normal == _state;
    public float Life => _life;
    public float LifeMax => lifeMax;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    private float _life;
    
    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();
        LifeGaugeContainer.Instance.Add(this);
    }

    protected virtual void OnDie()
    {
        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
        LifeGaugeContainer.Instance.Remove(this);
    }

    public void Damage(int damage)
    {
        if (_state == StateEnum.Die)
        {
            return;
        }

        _life -= damage;

        if (_life > 0)
        {
            return;
        }

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");
    }

    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable)
        {
            return;
        }

        OnDie();
    }

    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die)
        {
            return;
        }

        _state = StateEnum.Normal;
    }
}
