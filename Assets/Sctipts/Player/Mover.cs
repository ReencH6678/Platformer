using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AnimationHandler _animationHandler;

    public void Move(float direction)
    {
        _animationHandler.PlayMoveAnimation();
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if (direction > 0)
            transform.rotation = Quaternion.Euler(0,0,0);
        else if(direction < 0)
            transform.rotation = Quaternion.Euler(0,180,0);
    } 
}
