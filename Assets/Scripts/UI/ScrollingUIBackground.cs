using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ScrollingUIBackground : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector2 direction;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.material.mainTextureOffset += -direction.normalized * Time.deltaTime * speed;
    }
}
