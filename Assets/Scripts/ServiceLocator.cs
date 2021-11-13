using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _serviceContainer =
        new Dictionary<Type, object>();

    public static void SetServiceToDictionary<T>(T value) where T : class
    {
        var typeValue = typeof(T);
        if (!_serviceContainer.ContainsKey(typeValue))
        {
            _serviceContainer[typeValue] = value;
        }
    }

    public static T GetService<T>()
    {
        var type = typeof(T);

        if (_serviceContainer.ContainsKey(type))
        {
            return (T)_serviceContainer[type];
        }

        return default;
    }
}

