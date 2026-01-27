using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneRegistry", menuName = "Scriptable Objects/SceneRegistry")]
public class SceneRegistry : ScriptableObject
{
    [System.Serializable]
    public class SceneEntry
    {
        public string sceneName;                // Must match the name in Build settings
        public string displayName;              // Show in the menu
        public Sprite icon;                     // Optional icon for menu
        [TextArea] public string description;   // Optional description for tooltip
        public string catagory;                 // UI, VFX, Physics etc.
    }

    public List<SceneEntry> scenes = new List<SceneEntry>();
}
