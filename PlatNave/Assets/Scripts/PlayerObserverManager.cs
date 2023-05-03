using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerObserverManager
{
    public static Action<int> OnPointsChanged;

    public static void PointsChanged(int valor)
    {
        OnPointsChanged?.Invoke(valor);
    }
}
