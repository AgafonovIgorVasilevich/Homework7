using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyAnimator : MonoBehaviour
{
    private const string IsStay = nameof(IsStay);

    [SerializeField] private Animator _animator;

    public void Walk()
    {
        _animator.SetBool(IsStay, false);
    }

    public void Stay()
    {
        _animator.SetBool(IsStay, true);
    }
}