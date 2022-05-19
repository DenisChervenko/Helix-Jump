using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _scriptCollisionParentSphere;
    CollisionParetnSphere collisionParetnSphere;

    [Header("SpeedOption")]
    [SerializeField] private float _speedFallParent;

    public bool _canFall = false;
    private Rigidbody _rbParent;
    private Animator _anim;
    private void Start()
    {
        collisionParetnSphere = _scriptCollisionParentSphere.GetComponent<CollisionParetnSphere>();
        _rbParent = _parent.GetComponent<Rigidbody>();
        _anim = _player.GetComponent<Animator>();

        _rbParent.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX 
        | RigidbodyConstraints.FreezePositionZ;
    }

    private void FixedUpdate()
    {
        if(_canFall)
        {
            MoveDownSphere();
        }
    }

    private void MoveDownSphere()
    {
        _rbParent.velocity = new Vector3(0, _speedFallParent, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnClickDown()
    {
        ClickEvent(0);
    }

    public void OnClickUp()
    {
        ClickEvent(1);
    }

    //0 = OnClickDown | 1 = OnClickUp
    private void ClickEvent(int index)
    {
        _rbParent.WakeUp();
        _rbParent.constraints = (index == 0 || collisionParetnSphere._onPlatform == true ? RigidbodyConstraints.None : 
        RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);

        if(index == 1)
        {
            _rbParent.freezeRotation = true;
        }

        _canFall = (index == 0 ? true : false);
        _anim.SetTrigger((index == 0 ? "Fall" : "Idle"));
    }
}
