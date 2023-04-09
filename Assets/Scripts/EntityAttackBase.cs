using UnityEngine;

public abstract class EntityAttackBase : MonoBehaviour
{
    private EntityAnimatorInterlayer _animatorInterlayer;

    [SerializeField] [Min(0)] private float _coolDownTime = 0.5f;

    [SerializeField] private bool _canAttack = true;
    [SerializeField] private bool _isAttacking;

    private Coroutine _coolDownCoroutine;

    public void Init(EntityAnimatorInterlayer animatorInterlayer)
    {
        _animatorInterlayer = animatorInterlayer;
    }

    public void Attack()
    {
        if (_canAttack == false) return;

        _canAttack = false;
        _isAttacking = true;
        _animatorInterlayer.PlayerAttack(ApplyAttack);
    }

    public void InterruptAttack()
    {
        if (_isAttacking == false) return;

        _animatorInterlayer.InterruptAttack();
        AllowAttack();
        _isAttacking = false;
    }

    private void ApplyAttack()
    {
        Debug.Log("Attack applied: " + GetDamage());
        _isAttacking = false;
        _coolDownCoroutine = this.Delay(_coolDownTime, AllowAttack);
    }

    protected abstract int GetDamage();

    private void AllowAttack()
    {
        _canAttack = true;
    }

    protected virtual void Dispose()
    {
        if (_coolDownCoroutine == null) return;
        StopCoroutine(_coolDownCoroutine);
    }

    private void OnDestroy()
    {
        Dispose();
    }
}