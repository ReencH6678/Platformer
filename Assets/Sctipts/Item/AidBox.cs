using UnityEngine;

public class AidBox : MonoBehaviour, IItem
{
    [SerializeField] private float _healCount;

    public void Pick(IItemVisitor visitor)
    {
        visitor.VisitAidBox(this, _healCount);
        Destroy(this.gameObject);
    }
}
