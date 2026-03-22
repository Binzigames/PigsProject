public interface IStaticDataProvider
{
    public T GetDataContainer<T>() where T : BaseStaticDataContainer;
}
