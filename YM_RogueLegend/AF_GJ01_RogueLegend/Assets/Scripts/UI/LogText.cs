using DG.Tweening;
using UnityEngine;

public class LogText : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;

    public virtual void LogStart(Vector2 pos, float time = 0.2f, string text = "", Color? color = null)
    {
        SetPos(pos);
        AlphaView(time);
        SetText(text);
        SetColor(Color.white);
    }
    
    protected virtual void SetPos(Vector2 pos)
    {
        
    }

    protected virtual void AlphaView(float time)
    {
        var seq = DOTween.Sequence();
        seq.Append(canvas.DOFade(0f, 0.2f));
    }

    protected virtual void SetText(string text)
    {
        
    }
    
    protected virtual void SetColor(Color color)
    {
        
    }
}
