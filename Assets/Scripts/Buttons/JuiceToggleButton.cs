using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class JuiceToggleButton : MonoBehaviour
{   
    private bool skipFirstToggle = true;
    private bool juiceEnabled = false;
    private IJuiceToggle[] toggles;

    private Button juiceButton;

    private void Awake()
    {
        juiceButton = GetComponent<Button>();
        juiceButton.onClick.AddListener(ToggleJuice);
    }

    private void Start()
    {
        // Find all MonoBehaviours in the scene (including inactive)
        var monos = FindObjectsByType<MonoBehaviour>(
            FindObjectsInactive.Include,
            FindObjectsSortMode.None
        );

        List<IJuiceToggle> list = new List<IJuiceToggle>();

        foreach (var m in monos)
        {
            if (m is IJuiceToggle jt)
                list.Add(jt);
        }

        toggles = list.ToArray();


        ToggleJuice();
    }

    public void ToggleJuice()
    {
        if (!skipFirstToggle)
        {
            juiceEnabled = !juiceEnabled;
        }
        else
        {
            skipFirstToggle = false;
        }

        foreach (var t in toggles)
            t.SetJuice(juiceEnabled);
    }

}
