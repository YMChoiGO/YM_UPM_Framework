using DG.Tweening;
using TMPro;
using UnityEngine;

public class LogText_Mesh : LogText
{
    [SerializeField] private TextMeshPro textMesh;
    
    protected override void SetText(string text)
    {
        textMesh.text = text;
    }
    
    protected override void SetColor(Color color)
    {
        textMesh.color = color;
    }
}
