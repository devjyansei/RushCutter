using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; }} // buradan erisim saglayacagiz.

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower,transform.position);

            isPlaceable = false;
        }

    }
}
