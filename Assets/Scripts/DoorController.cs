using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform doorArt;

    //summary
    private float doorAngle = 0;
    public float animLength = .5f;
    private float animTime = 0;
    private bool isAnimPlaying = false;

    private bool isClosed = true;


    void Update()
    {
       //playing anim
       if (isAnimPlaying)
        {
            if (!isClosed)
                animTime += Time.deltaTime;
            else
                animTime -= Time.deltaTime;

            float percent = animTime / animLength;
            if (percent < 0 && isClosed)
            {
                percent = 0;
                isAnimPlaying = false;

            }
            if (percent > 1 && !isClosed)
            {
                percent = 1;
                isAnimPlaying = false;
            }

            doorArt.localRotation = Quaternion.Euler(0, doorAngle * percent, 0);
        }

    }

    public void PlayerInteract(Vector3 position)
    {
        if (isAnimPlaying) return; // does nothing

        Vector3 disToPlayer = position - transform.position;
        disToPlayer = disToPlayer.normalized;

        bool playerOnOtherSide = Vector3.Dot(disToPlayer, transform.right) > 0f;

        isClosed = !isClosed; // toggles state

        if (!isClosed)
        {
            doorAngle = -90;
            if (playerOnOtherSide) doorAngle = 90;
        }


        isAnimPlaying = true;
     
        if (isClosed) animTime = animLength;
        else animTime = 0;


    }
  
}
