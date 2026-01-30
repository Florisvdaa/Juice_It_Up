using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class FlipACoin : MonoBehaviour, IJuiceToggle
{
    [Header("References")]
    [SerializeField] private Button flipButton;
    [SerializeField] private TextMeshProUGUI outcomeText;
    [SerializeField] private Transform coinRoot;

    [Header("Flip Settings")]
    [SerializeField] private float flipDuration = 0.6f;

    private bool juiceEnabled = false;

    private void Awake()
    {
        flipButton.onClick.AddListener(FlipCoin);
    }

    private void Start()
    {
        // Start on Heads
        coinRoot.localRotation = Quaternion.identity;
        outcomeText.text = CoinSide.Heads.ToString();
    }

    public void FlipCoin()
    {
        CoinSide result = Random.value < 0.5f ? CoinSide.Heads : CoinSide.Tails;
        outcomeText.text = result.ToString();

        if (juiceEnabled)
            PlayJuicyFlip(result);
        else
            PlayBoringFlip(result);
    }

    // BORING FLIP (instant)
    private void PlayBoringFlip(CoinSide finalSide)
    {
        float angle = finalSide == CoinSide.Heads ? 0f : -180f;
        coinRoot.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

    // JUICY FLIP (animated)
    private void PlayJuicyFlip(CoinSide finalSide)
    {
        int randomFlips = Random.Range(2, 7);
        float finalAngle = finalSide == CoinSide.Heads ? 0f : -180f;
        float totalRotation = (360f * randomFlips) + finalAngle;

        Sequence seq = DOTween.Sequence();

        // Anticipation squash
        seq.Append(coinRoot.DOScaleY(0.8f, 0.1f).SetEase(Ease.OutQuad));

        // Stretch upward as it starts flipping
        seq.Append(coinRoot.DOScaleY(1.2f, 0.1f).SetEase(Ease.OutQuad));

        // Actual flip
        seq.Append(
            coinRoot
                .DORotate(new Vector3(totalRotation, 0f, 0f), flipDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.OutCubic)
        );

        // Landing bounce
        seq.Append(coinRoot.DOScaleY(0.9f, 0.08f).SetEase(Ease.OutQuad));
        seq.Append(coinRoot.DOScaleY(1f, 0.08f).SetEase(Ease.OutBack));

        // Snap to perfect orientation
        seq.OnComplete(() =>
        {
            coinRoot.localRotation = Quaternion.Euler(finalAngle, 0f, 0f);
        });
    }

    public void SetJuice(bool enabled)
    {
        juiceEnabled = enabled;
    }
}

public enum CoinSide { Heads, Tails }