
using Cysharp.Threading.Tasks;

public interface ISceneLoadService
{
    public void LoadSceneAsync(string sceneName);
    public UniTask LoadSceneAsyncWithLoading(string sceneName);
}
