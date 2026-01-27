using UnityEngine;
using UnityEngine.UI;

public class FlipACoin : MonoBehaviour , IJuiceToggle
{
    // here come all the Juice variables like animator , particle system , audioclip etc.

    [SerializeField] private Toggle juiceToggle;
    [SerializeField] private Button flipButton;

    private bool juiceEnabled = false;

    private void Awake()
    {
        //flipButton = GetComponent<Button>();
        flipButton.onClick.AddListener(FlipCoin);
    }

    private void Update()
    {
        if (juiceToggle != null)
        {
            SetJuice(juiceToggle.isOn);
        }
    }

    public void FlipCoin()
    {
        if (juiceEnabled)
        {
            // Juicy flip
            Debug.Log("Juicy Flip");
        }
        else
        {
            // Boring flip
            Debug.Log("Boring flip");
        }
    }

    public void SetJuice(bool enabled)
    {
        juiceEnabled = enabled;
    }
}
