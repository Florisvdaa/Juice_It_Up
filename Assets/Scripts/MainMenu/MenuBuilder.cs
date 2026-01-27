using UnityEngine;
using UnityEngine.UI;

public class MenuBuilder : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SceneRegistry registry;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private GameObject buttonPrefab;

    private void Start()
    {
        BuildMenu();
    }

    private void BuildMenu()
    {
        foreach (var entry in registry.scenes)
        {
            GameObject btnObj = Instantiate(buttonPrefab, buttonContainer);
            SceneButton btn = btnObj.GetComponent<SceneButton>();
            btn.Setup(entry);
        }
    }
}
