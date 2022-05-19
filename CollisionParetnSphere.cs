using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionParetnSphere : MonoBehaviour
{
    public bool _onPlatform;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            _onPlatform = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Platform")
        {
            _onPlatform = false;
        }
    }
}
