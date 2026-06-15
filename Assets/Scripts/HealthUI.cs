using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    // Tiempo que va a durar la animación de pérdida de vida
    [SerializeField] private float healthAnimationTime = 0.1f;

    private Tween healthTween;

    public void UpdateHealthAmount(float amount)
    {
        // Paramos la animación actual
        healthTween?.Kill();

        print("B");

        // Actualizamos el fill amount de la imagen en base al amount que nos llega por parámetro con una animación de tween
        healthTween = healthImage.DOFillAmount(amount, healthAnimationTime).SetEase(Ease.OutQuad);
    }
}
