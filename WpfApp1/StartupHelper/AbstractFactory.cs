
using System;

namespace WpfApp1.StartupHelper;

public class AbstractFactory<T> : IAbstractFactory<T>
{
    private readonly Func<T> _factory;

    public AbstractFactory(Func<T> factory)
    {
        _factory = factory;
    }
    public T Create()
    {
        return _factory();
    }
}
