using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonHelper
{
    public static void AddEvent(this Button button, Action action)
    {
        button.onClick.AddListener(() => action());
    }
    
    public static void OnlyEvent(this Button button, Action action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => action());
    }

    public static void SetNameBtn(this Button button, string name)
    {
        TextMeshProUGUI tmp = button.GetComponentInChildren<TextMeshProUGUI>();
        button.gameObject.name = name;
        tmp.gameObject.name = $"Text({tmp.text})";
    }
    
    public static void SetNameComp(this Component obj, string name)
    {
        obj.name = name;
    }

    public static void Link<T>(this T obj, string name) where T : Component
    {
        obj = GameObject.Find("name").GetComponent<T>();
    }

    public static void Active(this CanvasGroup canvasGroup, bool active)
    {
        canvasGroup.interactable = active;
        canvasGroup.blocksRaycasts = active;
        canvasGroup.alpha = active? 1 : 0;
    }
}
