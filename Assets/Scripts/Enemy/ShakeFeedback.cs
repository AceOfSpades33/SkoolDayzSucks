using UnityEngine;
using DG.Tweening;

public class ShakeFeedback : MonoBehaviour
{
    [SerializeField] private float duration = 0.4f;
    // Intensidad del shake
    [SerializeField] private float strength = 0.3f;

    private Transform targetTransform;
    private Tween currentTween;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        targetTransform = transform;
    }

    public void DoShake()
    {
        // Si hay una tween en acción, la cancelamos
        if (currentTween != null && currentTween.IsActive())
        {
            currentTween.Kill();
        }

        // Creamos el shake
        currentTween = targetTransform.DOShakePosition(duration, strength);
    }
}
