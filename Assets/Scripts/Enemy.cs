using UnityEngine;

[RequireComponent (typeof(EnemyAnimator))] 

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _speed;

    public void SetDirection(Vector3 target)
    {
        transform.LookAt(target);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward *  _speed * Time.deltaTime);
        _animator.Walk();
    }
}