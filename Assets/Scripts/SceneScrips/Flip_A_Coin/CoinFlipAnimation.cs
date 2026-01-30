using UnityEngine;
using System;
using System.Collections;
public class CoinFlipAnimation : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] private Transform coinRoot;
    [SerializeField] private float flipDuration = 0.6f;
    [SerializeField] private int flips = 3;

    public void PlayFlip(bool isHeads)
    {
        StartCoroutine(FlipRoutine(isHeads));
    }

    private IEnumerator FlipRoutine(bool isHeads)
    {
        float totalRotation = 360f * flips;
        float elapsed = 0f;

        while (elapsed < flipDuration)
        {
            float t = elapsed / flipDuration;
            float angle = Mathf.Lerp(0f, totalRotation, t);

            coinRoot.localRotation = Quaternion.Euler(angle, 0f, 0f);

            // Swap at halfway point
            if (angle % 360f > 180f)
                coin.SetSide(CoinSide.Heads);
            else
                coin.SetSide(CoinSide.Heads);
            //coin.Flip(isHeads);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Snap to final side
        coinRoot.localRotation = Quaternion.identity;
        //coin.Flip(isHeads);
    }

}
