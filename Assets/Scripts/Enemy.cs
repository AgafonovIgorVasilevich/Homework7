using UnityEngine;

[RequireComponent (typeof(EnemyAnimator))] 

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _speed;

    public Vector3 TargetPoint;

    private Vector3 _destinationPoint;
    private bool _inPlace;

    private void Start()
    {
        _destinationPoint = TargetPoint;
        transform.LookAt(_destinationPoint);
    }

    private void Update()
    {
        if (_inPlace)
            return;

        if(transform.position != _destinationPoint)
        {
            _animator.Walk();
            Walk();
        }
        else
        {
            _animator.Stay();
            GetInLine();
            _inPlace = true;
        }
    }

    private void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destinationPoint, _speed * Time.deltaTime);
    }

    private void GetInLine()
    {
        Quaternion orientation = Quaternion.Euler(0, -90, 0);
        transform.rotation = orientation;
    }
}
