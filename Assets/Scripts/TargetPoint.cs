using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] private int _countPositionsInRow = 10;
    [SerializeField] private float _offset = 0.5f;

    private int _currentNumberInRow = 0;
    private Vector3 _firstPosition;

    private void Start()
    {
        _firstPosition = transform.position;
    }

    public Vector3 GetPosition()
    {
        Vector3 position = _firstPosition;
        position.x -= _offset * _currentNumberInRow;

        _currentNumberInRow++;

        if( _currentNumberInRow >= _countPositionsInRow )
        {
            _firstPosition.z -= _offset;
            _currentNumberInRow = 0;
        }

        return position;
    }
}