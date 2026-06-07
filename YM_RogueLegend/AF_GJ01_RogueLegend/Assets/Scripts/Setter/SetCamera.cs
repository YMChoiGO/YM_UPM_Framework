using UnityEngine;

public class SetCamera : MonoBehaviour
{
    private Canvas canvas;
    
    void Start()
    {  
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }
}
