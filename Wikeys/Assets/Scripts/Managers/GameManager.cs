using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject SnapPoints;
    public List<Transform> snapPointsLocations;

    void OnEnable()
    {
        DragCard.OnDropCard += SnapCard;
    }

    void OnDisable()
    {
        DragCard.OnDropCard -= SnapCard;
    }

    void Start()
    {
        foreach(Transform child in SnapPoints.transform)
        {
            snapPointsLocations.Add(child);
        }
    }

    void SnapCard(Transform card)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform point in snapPointsLocations)
        {
            float currentDistance = Vector3.Distance(point.position, card.position);
            if(closestSnapPoint == null || currentDistance <= closestDistance)
            {
                closestSnapPoint = point;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null || closestDistance <= 0.5f)
        {
            card.position = closestSnapPoint.position;
            Debug.Log(closestSnapPoint.position);
            Debug.Log(card.position);
        }
    }
}
