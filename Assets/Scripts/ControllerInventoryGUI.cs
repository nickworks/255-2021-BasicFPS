using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInventoryGUI : MonoBehaviour
{

    public Transform imgKey;


    void Update()
    {
        imgKey.gameObject.SetActive(Inventory.main.hasKey);
    }
}
