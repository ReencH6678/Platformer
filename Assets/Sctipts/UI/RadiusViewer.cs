using UnityEngine;

public class RadiusViewer : MonoBehaviour
{
    [SerializeField] private Vamperism _vamperism;

    private void Awake()
    {
        transform.localPosition += _vamperism.GetOffset();
        transform.localScale = new Vector2(_vamperism.GetRadius(),_vamperism.GetRadius());
    }
}
