using System;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    [SerializeField] private int tileCount = 8;
    [SerializeField] private float scrollSpeed = 0.1f;
    [SerializeField] private Color colorA = Color.white;
    [SerializeField] private Color colorB = Color.black;
    [Tooltip("(1,0 ->) scroll right, (0,1) -> scroll up, (1,1) -> scroll diagonally up-right, (-1,-1) -> scroll diagonally down-left")]
    [SerializeField] private Vector2 scrollDirection = new Vector2(1, 1);

    private Material mat;

    private void Start()
    {
        Texture2D texture = GenerateBackground(tileCount, colorA , colorB);
        texture.wrapMode = TextureWrapMode.Repeat;
        texture.filterMode = FilterMode.Point;

        mat = new Material(Shader.Find("Unlit/Texture"));
        mat.mainTexture = texture;

        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.localScale = new Vector3(20, 20, 1); // large enough to fill screen
        quad.GetComponent<Renderer>().material = mat;
        quad.transform.parent = transform;
    }

    private void Update()
    {
        Vector2 offset = scrollDirection.normalized * scrollSpeed * Time.time;
        mat.mainTextureOffset = offset;
    }

    private Texture2D GenerateBackground(int tileCount, Color colorA, Color colorB)
    {
        Texture2D tex = new Texture2D(tileCount, tileCount);
        for (int x = 0; x < tileCount; x++)
        {
            for (int y = 0; y < tileCount; y++)
            {
                Color c = (x + y) % 2 == 0 ? colorA : colorB;
                tex.SetPixel(x, y, c);
            }
        }
        tex.Apply();
        return tex;
    }
}
