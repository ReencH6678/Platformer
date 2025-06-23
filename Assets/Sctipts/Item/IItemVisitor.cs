public interface IItemVisitor
{
    void VisitCoin(Coin coin);
    void VisitAidBox(AidBox aidBox, float healCount);
}
