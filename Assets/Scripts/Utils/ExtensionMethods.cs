using UnityEngine;

public static class ExtensionMethods 
{
    public static void Toggle(this CanvasGroup canvasGroup, bool isActive)
    {
        canvasGroup.alpha = isActive ? 1 : 0;
        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;
    }
}
