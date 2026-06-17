using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private CanvasGroup canvasGroup;
    private Sequence fadeSequence;
    private Sequence loadingSequence;
    public static LoadingScreen Instance { get; private set; }

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canvasGroup.Toggle(false);
    }

    public void StartLoading(string sceneName)
    {
        StartCoroutine(LoadCoroutine(sceneName));
    }

    private IEnumerator LoadCoroutine(string sceneName)
    {
        Show();
        yield return new WaitForSeconds(fadeTime);
        yield return SceneManager.LoadSceneAsync(sceneName);
        Hide();
    }

    private void Show()
    {
        fadeSequence?.Kill();

        fadeSequence = DOTween.Sequence();

        fadeSequence.Append(canvasGroup.DOFade(1f, fadeTime).SetEase(Ease.OutCubic));

        StartAnimation();
    }

    private void Hide()
    {
        loadingSequence?.Kill();
        fadeSequence?.Kill();

        fadeSequence = DOTween.Sequence().Append(canvasGroup.DOFade(0f, fadeTime). SetEase(Ease.OutCubic));
    }

    private void StartAnimation()
    {
        loadingSequence?.Kill();
        loadingSequence = DOTween.Sequence().AppendCallback(() => loadingText.text = "Loading.")
        .AppendInterval(0.4f)
        .AppendCallback(() => loadingText.text = "Loading..")
        .AppendInterval(0.4f)
        .AppendCallback(() => loadingText.text = "Loading...")
        .AppendInterval(0.4f)
        .AppendCallback(() => loadingText.text = "Loading")
        .SetLoops(-1, LoopType.Restart);
    }
}
