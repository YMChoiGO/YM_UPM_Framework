using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StringHelper
{
    public static string ToText(this Enum text)
    {
        return Enum.GetName(text.GetType(), text);
    }

    public static void Go(this SceneType sceneName)
    {
        SceneManager.LoadScene(sceneName.ToText());
    }
}
