using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleIdleJump;

    public void IdleJumpAnimationEvent()
    {
        _particleIdleJump.Play();
    }
}
