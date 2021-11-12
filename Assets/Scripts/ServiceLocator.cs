using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static readonly Dictionary<Type, object> _serviceŅontainer =
        new Dictionary<Type, object>();

    public static void SetServiceToDictionary<T>(T value) where T : class
    {
        var typeValue = typeof(T);
        if (!_serviceŅontainer.ContainsKey(typeValue))
        {
            _serviceŅontainer[typeValue] = value;
        }
    }

    public static T GetService<T>()
    {
        var type = typeof(T);

        if (_serviceŅontainer.ContainsKey(type))
        {
            return (T)_serviceŅontainer[type];
        }

        return default;
    }
}

