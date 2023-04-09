using System;
using UnityEngine;

public class EntityAnimatorInterlayer : AnimatorInterlayerBase
{
    private const string _attackTrigger = "Attack";
    private const string _toIdleTrigger = "ToIdle";

    private Action _damageDealtCallback;

    public void PlayerAttack(Action damageDealt)
    {
        _damageDealtCallback = damageDealt;
        Animator.SetTrigger(_attackTrigger);
    }

    public void InterruptAttack()
    {
        Animator.SetTrigger(_toIdleTrigger);
    }

    private void OnDamageDealt()
    {
        _damageDealtCallback?.Invoke();
    }
}
