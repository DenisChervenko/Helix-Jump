using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _destroyedPart;
    
    private Animator _anim;
    private GameObject _playerScript;
    Player player;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();

        if(_playerScript == null)
        {
            _playerScript = GameObject.Find("Fall");
        }
        player = _playerScript.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(player._canFall)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                ContactWithPlatform();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(player._canFall)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                ContactWithPlatform();   
            }
        }
    }

    private void ContactWithPlatform()
    {
        int temp = Random.Range(0, 3);

        _anim.SetTrigger((temp == 0 ? "Destroy" : (temp == 1 ? "DestroyV2" : "DestroyV3")));
    }

    public void EventDisabledObject()
    {
        gameObject.SetActive(false);
    }
}
