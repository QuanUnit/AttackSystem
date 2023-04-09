using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DefaultEntityAttack))]
[RequireComponent(typeof(EntityAnimatorInterlayer))]
public class Player : MonoBehaviour
{
    [SerializeField] private DefaultEntityAttack _attack;
    [SerializeField] private EntityAnimatorInterlayer _animatorInterlayer;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _attack.Init(_animatorInterlayer);
    }

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _attack.Attack();
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _attack.InterruptAttack();
            return;
        }
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        _attack = GetComponent<DefaultEntityAttack>();
        _animatorInterlayer = GetComponent<EntityAnimatorInterlayer>();
    }

#endif
}
