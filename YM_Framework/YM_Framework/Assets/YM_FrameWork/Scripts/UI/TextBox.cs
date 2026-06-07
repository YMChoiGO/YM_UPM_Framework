using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public Image boxImage;
    public TextMeshProUGUI Text;

    public void SetText(string text)
    {
        Text.text = text;
    }

    public void SetImage(Sprite sprite)
    {
        boxImage.sprite = sprite;
    }
}
