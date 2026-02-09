using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverTextAnimator : MonoBehaviour
{
    Text gameOverText;
    Shadow textShadow;

    void Awake()
    {
        gameOverText = GetComponent<Text>();
        gameOverText.alignment = TextAnchor.MiddleCenter;
        gameOverText.color = Color.white;
        gameOverText.horizontalOverflow = HorizontalWrapMode.Overflow;
        gameOverText.verticalOverflow = VerticalWrapMode.Overflow;
        textShadow = GetComponent<Shadow>();
        textShadow.effectDistance = new Vector2(3, -3);
    }

    void Start()
    {
        Transform transformCache = transform;
        Vector3 defaultPosition = transform.localPosition;
        transformCache.localPosition = new Vector3(0, 300f);

        transformCache.DOLocalMove(defaultPosition, 1).SetEase(Ease.Linear).OnComplete(() =>
        {
            transformCache.DOShakePosition(1.5f, 100);
        });

        DOVirtual.DelayedCall(10, () =>
        {
            SceneManager.LoadScene("TitleScene");
        });
    }
}
