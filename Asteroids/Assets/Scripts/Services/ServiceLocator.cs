using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private ServiceLocator() { }

    private Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();

    public static ServiceLocator Current { get; private set; }

    public static void Initialize()
    {
        Current = new ServiceLocator();
    }

    public T Get<T>() where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError($"Key is not registered");
            throw new InvalidOperationException();
        }
        return (T)services[key];
    }

    public void Register<T>(T service) where T : IGameService
    {
        string key = typeof(T).Name;
        if (services.ContainsKey(key))
        {
            Debug.LogError($"Key already registered");
            return;
        }
        services.Add(key, service);
    }

    public void Unregister<T>() where T : IGameService
    {
        string key = typeof(T).Name;
        if (!services.ContainsKey(key))
        {
            Debug.LogError($"Key already registered");
            return;
        }
        services.Remove(key);
    }
}
