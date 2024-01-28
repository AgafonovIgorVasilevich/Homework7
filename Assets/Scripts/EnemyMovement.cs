using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private float _speed;

    public TargetPoint TargetPoint;

    private Vector3 _destinationPoint;
    private bool _inPlace;

    private void Start()
    {
        _destinationPoint = TargetPoint.GetPosition();
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
        transform.rotation = TargetPoint.transform.rotation;
    }
}
