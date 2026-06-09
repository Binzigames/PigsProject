using Cysharp.Threading.Tasks;

public interface ILoadSceneService
{
    public void LoadSceneAsync(string sceneName);
    public UniTask LoadSceneAsyncWithLoading(string sceneName);
}
