using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradienRandomize : MonoBehaviour
{
    [SerializeField] private GameObject[] _gradient;

    private void Start()
    {
        int temp = Random.Range(0, _gradient.Length);

        _gradient[temp].gameObject.SetActive(true);
    }
}
