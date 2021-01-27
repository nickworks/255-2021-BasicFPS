using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    /// <summary>
    /// Singleton design pattern
    /// </summary>
    private static Inventory _main;
    public static Inventory main {
        get { return _main; }
    }

    public bool hasKey = false;
    public bool hasSword = false;

    private void Start() {

        if (_main == null) {

            _main = this;
            DontDestroyOnLoad(gameObject);
            // don't destroy this object when loading new scenes

        } else {
            Destroy(gameObject); // destroy this extra inventory system....
        }

    }


}
