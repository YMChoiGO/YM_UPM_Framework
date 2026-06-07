using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mainVisual;
    
    private void Awake()
    {
        // int charIdx = Random.Range(0, 12);
        // mainVisual.sprite = ManagerHub.I.Resource.Sprites[$"Character_{charIdx}"];

        SetOrder();
    }

    private void SetOrder()
    {
        mainVisual.sortingOrder = DefaultKey.UnitOrder;
    }
}
