using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [SerializeField] private AudioSource _soundJump;

    public void JumpEvent()
    {
        _soundJump.Play();
    }
}
