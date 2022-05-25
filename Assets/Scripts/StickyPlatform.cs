using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// captures effect of player moving with a moving platform
public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            // if player touches the sticky platform, set the player's parent to platform, copying speeds over
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            // if player exits the sticky platform, set the player's parent to null, resetting speeds
            collision.gameObject.transform.SetParent(null);
        }
    }
}
