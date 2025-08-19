using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(float direction)
    {
        transform.Translate(new Vector3(_speed * Time.deltaTime * direction, 0));
    } 
}
