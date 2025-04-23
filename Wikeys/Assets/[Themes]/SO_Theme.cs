using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Theme_", menuName = "ThemeData/SO_Theme")]
public class SO_Theme : ScriptableObject {
    public List<SO_Background> backgrounds = new();
    public List<SO_Icon> icon = new(); // instantiate in each background cells

    [Header("Settings")]
    public SO_Float speed;
}
