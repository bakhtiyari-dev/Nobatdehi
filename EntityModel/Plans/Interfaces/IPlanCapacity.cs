namespace EntityModel.Plans.Interfaces
{
    public interface IPlanCapacity
    {
        public void IncreaseCapacity(int opoId, int capacity);
        public void DecreaseCapacity(int opoId, int capacity);
        public void SetCapacity(int opoId, int capacity);
    }
}
