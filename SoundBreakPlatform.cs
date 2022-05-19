using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBreakPlatform : MonoBehaviour
{
    private GameObject _breakSoundObject;
    [SerializeField] private AudioClip _breakSound;
    private AudioSource _audioSource;

    private void Start()
    {
        _breakSoundObject = GameObject.Find("Break");
        _audioSource = _breakSoundObject.GetComponent<AudioSource>();
    }

    public void EventBreakPlatform()
    {
        _audioSource.PlayOneShot(_breakSound, 0.2f);
    }
}
