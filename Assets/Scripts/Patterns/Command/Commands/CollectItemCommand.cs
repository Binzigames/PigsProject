using Scripts.Patterns;

public class CollectItemCommand : ICommand 
{
    private readonly Item _item;
    public CollectItemCommand(Item item)
    {
        _item = item;
    }
    public void Execute()
    {
        _item.Collect();
    }
}
