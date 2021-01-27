using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform doorArt;

    /// <summary>
    /// The angle the door is at, in degrees.
    /// </summary>
    private float doorAngle = 0;

    public float animLength = 0.5f;
    private float animTimer = 0;
    private bool animIsPlaying = false;


    private bool isClosed = true;

    
    void Update()
    {
        // play the animation

        if (animIsPlaying) {

            if (!isClosed)
                animTimer += Time.deltaTime; // playing forward
            else
                animTimer -= Time.deltaTime; // playing backwards

            float percent = animTimer / animLength;

            if (percent < 0 && isClosed) {
                percent = 0;
                animIsPlaying = false;
            }
            if (percent > 1 && !isClosed) {
                percent = 1;
                animIsPlaying = false;
            }

            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0); // set angle of doorArt
        }
    }

    public void PlayerInteract(Vector3 position) {

        if (animIsPlaying == true) return; // do nothing...

        if (Inventory.main.hasKey == false) return; // do nothing...

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;

        bool playerOnOtherSide = (Vector3.Dot(disToPlayer, transform.forward) > 0f);

        isClosed = !isClosed; // toggles state

        if (!isClosed) {
            doorAngle = 90;
            if (playerOnOtherSide) doorAngle = -90;
        }

        //if(!isClosed) doorAngle = (playerOnOtherSide) ? -90 : 90;

        animIsPlaying = true;

        // set playhead to end (or beginning)
        if (isClosed) animTimer = animLength;
        else animTimer = 0;
    }


}
