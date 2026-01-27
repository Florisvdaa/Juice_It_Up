using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Image icon;
    [SerializeField] private string sceneToLoad;

    private Button thisBtn;

    public void Setup(SceneRegistry.SceneEntry entry)
    {
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(OnClick);

        if (entry.displayName != null)
            label.text = entry.displayName;

        if(entry.icon != null)
            icon.sprite = entry.icon;
        
        if(entry.sceneName != null) 
            sceneToLoad = entry.sceneName;
    }

    public void OnClick()
    {
        SceneLoader.Instance.LoadScene(sceneToLoad);
    }
}
