using UnityEngine;

[CreateAssetMenu(fileName = "Icon_", menuName = "ThemeData/Icon")]
public class SO_Icon : ScriptableObject {
    public Sprite sprite; // replace the default's instanced prefab's icon
    public GameObject optionnalGameObject; // delete previous icon GO, instantiate this one instead
}
