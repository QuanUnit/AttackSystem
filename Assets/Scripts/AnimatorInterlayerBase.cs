using UnityEngine;

public abstract class AnimatorInterlayerBase : MonoBehaviour
{
    protected Animator Animator => _animator;

    [SerializeField] private Animator _animator;

#if UNITY_EDITOR

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
    }

#endif
}
