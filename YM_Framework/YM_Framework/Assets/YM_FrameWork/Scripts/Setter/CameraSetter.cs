using UnityEngine;

public class CameraSetter : MonoBehaviour
{
    public CameraWidthHeight camOrtho;

    private void Start()
    {
        Setter();
    }

    public void Setter(float size = 6f)
    {
        Camera.main.orthographicSize = size;
        
        if (camOrtho == CameraWidthHeight.Width)
        {
            Camera.main.orthographicSize /= Camera.main.aspect;
        }
    }
}

public enum CameraWidthHeight
{
    Width,
    Height
}