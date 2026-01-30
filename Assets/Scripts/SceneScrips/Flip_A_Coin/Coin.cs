using UnityEngine;

//public enum CoinSide { Heads, Tails }

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coinHeads;
    [SerializeField] private GameObject coinTails;

    public void SetSide(CoinSide side)
    {
        coinHeads.SetActive(side == CoinSide.Heads);
        coinTails.SetActive(side == CoinSide.Tails);
    }
}
