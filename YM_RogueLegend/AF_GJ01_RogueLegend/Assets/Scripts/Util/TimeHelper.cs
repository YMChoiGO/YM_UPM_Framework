using UnityEngine;

public static class TimeHelper
{
    public static float timeSpeed = 1f;
    
    public static float GetDeltaTime()
    {
        return Time.deltaTime * timeSpeed;
    }

    public static float GetTime(float time)
    {
        return time / timeSpeed;
    }
}
