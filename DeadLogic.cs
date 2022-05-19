using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLogic : MonoBehaviour
{
    [SerializeField] private GameObject _playerScript;
    [SerializeField] private Animator _animatorDieScreen;
    Player player;

    private void Start()
    {
        player = _playerScript.GetComponent<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DeadZone") & player._canFall == true)
        {
            Die();
            Debug.Log("Enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("DeadZone") & player._canFall == true)
        {
            Die();
            Debug.Log("Stay");
        }
    }

    private void Die()
    {
        _animatorDieScreen.SetTrigger("ShowDieScreen");
    }
}
