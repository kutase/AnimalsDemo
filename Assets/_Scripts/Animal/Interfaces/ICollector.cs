namespace AnimalsDemo
{
    public interface ICollector : ITransformProvider
    {
        float MoveSpeed { get; }
        
        void SetTarget(ICollectable collectable);

        void SetSpeed(float speed);
    }
}
