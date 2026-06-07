using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CanvasGroupUtil
{
   public static void Activate(this CanvasGroup canvasGroup, bool isTrue)
   {
     canvasGroup.alpha = isTrue ? 1 : 0;
     canvasGroup.interactable = isTrue;
     canvasGroup.blocksRaycasts = isTrue;
   }
}
