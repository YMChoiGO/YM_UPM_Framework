using System;
using UnityEngine;

public static class GameEntryEvent
{
    public static Action onEndEvent;

    public static void InvokeEndEvent()
    {
        onEndEvent?.Invoke();
        onEndEvent = null;
    }
}
