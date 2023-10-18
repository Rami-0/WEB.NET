namespace BLL.Services;

public interface IMyService
{
    void DoSomething();
}

public class ServiceCollection : IMyService
{
    public void DoSomething()
    {
        // Implementation code
    }
}
