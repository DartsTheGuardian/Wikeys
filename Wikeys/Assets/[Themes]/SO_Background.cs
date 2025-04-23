using UnityEngine;

[CreateAssetMenu(fileName = "SO_Background", menuName = "ThemeData/SO_Background")]
public class SO_Background : ScriptableObject {
    public enum SpriteOrder {
        TopLeft = 0,
        TopRight = 1,
        BottomLeft = 2,
        BottomRight = 3,
    }
    
    [Tooltip("Expected 4 sprites : TopLeft, TopRight, BottomLeft, BottomRight")]
    public Sprite[] sprites;


    [Tooltip("The following object should have 4 children instead of 4 sprites")]
    // SO_Icon.optionnalGameObject may be instanced inside each child,
    // or if null, optionnalGameObject.GetChild((int)SpriteOrder.TopLeft).GetComponentInChildren<SpriteRender>().sprite = ;
    // if SpriteRender is null, throw errors
    public GameObject optionnalGameObject;
}
