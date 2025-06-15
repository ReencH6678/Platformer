using UnityEngine;

public class Fliper : MonoBehaviour
{
    private Quaternion _rightRotate;
    private Quaternion _leftRotate;

    private float _currentDirection;

    private void Start()
    {
        _rightRotate = Quaternion.Euler(0, 0, 0);    
        _leftRotate = Quaternion.Euler(0, 180, 0);    
    }

    public void Flip(float direction) 
    {
        if (direction != _currentDirection) 
        {
            if(direction > 0)
                transform.rotation = _rightRotate;
            else
                transform.rotation = _leftRotate;

            _currentDirection = direction;
        }
    }
}
