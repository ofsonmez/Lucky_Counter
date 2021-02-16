namespace Dependency_Injection_LifeTime.Services
{
    public class SingletonService
    {
        public static int Counter = 0;
        public SingletonService()
        {
            ++Counter;
        }
        public int GetNextCounter()
        {
            return Counter;
        }
    }

    public class ScopedService
    {
        public static int Counter = 0;
        public ScopedService()
        {
            ++Counter;
        }
        public int GetNextCounter()
        {
            return Counter;
        }
    }

    public class TransientService
    {
        public static int Counter = 0;
        public TransientService()
        {
            ++Counter;
        }
        public int GetNextCounter()
        {
            return Counter;
        }
    }
}




