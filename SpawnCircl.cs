using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircl : MonoBehaviour
{
    [Header("GameObjectOption")]
    [SerializeField] private GameObject[] _prefabPlaformForSpawn;
    [SerializeField] private GameObject[] _prefabCubePlatformForSpawn;
    [SerializeField] private GameObject _finish;
    [SerializeField] private List<GameObject> _prefabWasSpawned;

    [Header("SpawnOption")]
    [SerializeField] private int _minRangeSpawnPlatform;
    [SerializeField] private int _maxRangeSpawnPlatfrom;
    [SerializeField] private int _minRangeSpawnIteration;
    [SerializeField] private int _maxRangeSpawnIteration;
    private int _spawnIteration;
    private int _countSpawn;    
    [SerializeField] private float _angleRotatePlatform;
    // 0 - left | 1 - right
    private int _sideRotate;
    private bool _vectorZeroForRotatePlatform;
    [SerializeField] private float _distancePlatformToPlatform;
    private float _currentDistance;
    private int _turnSpawnObject;
    private int _previousEnemyRotate;
    private int _tempCycle;

    [Header("SpawnPlaceOption")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;
    private Vector3 _spawnPointVector;

    private void Start()
    {
        //initialize spawn point
        _spawnPointVector = _spawnPoint.transform.position;

        SpawnPlatform();

        //create distances between each platform
        for(int i = 0; i <= (_prefabWasSpawned.Count - 1); i++)
        {
            _currentDistance -= _distancePlatformToPlatform;
            _prefabWasSpawned[i].transform.position = new Vector3(0, _currentDistance, 0);
        }

        //delete last platform, because he doesn`t rotate
        for(int i = 1; i < (_spawnIteration + 1); i++)
        {
            _prefabWasSpawned[_prefabWasSpawned.Count - i].gameObject.SetActive(false);
            _currentDistance += _distancePlatformToPlatform;
        }

        _finish.transform.position = new Vector3(0, _currentDistance - 1, 0);
        _finish.SetActive(true);
    }

    private void SpawnPlatform()
    {
        _spawnIteration = Random.Range(_minRangeSpawnIteration, _maxRangeSpawnIteration);
        int platformForSpawn = Random.Range(0, 2);

        for(int i = 0; i <= _spawnIteration; i++)
        {
            _countSpawn = Random.Range(_minRangeSpawnPlatform, _maxRangeSpawnPlatfrom);

            for(int j = 0; j <= _countSpawn; j++)
            {
                _prefabWasSpawned.Add(Instantiate((platformForSpawn == 0 ? _prefabPlaformForSpawn[_turnSpawnObject] : 
                _prefabCubePlatformForSpawn[_turnSpawnObject])));
                
                if(j >= _countSpawn)
                {
                    RotatePlatform(j);

                    Debug.Log(_countSpawn);
                }
            }

            _turnSpawnObject = Random.Range(0, _prefabPlaformForSpawn.Length - 1);
            
            if(i == _spawnIteration)
            {
                for(int k = 0; k <= (_prefabWasSpawned.Count - 1); k++)
                {
                    _prefabWasSpawned[k].transform.SetParent(_parent);
                    _prefabWasSpawned[k].transform.position = _spawnPointVector;
                }
            }
        }
    }

    private void RotatePlatform(int currentEnemyRotate)
    {
        _previousEnemyRotate += currentEnemyRotate;

        _sideRotate = Random.Range(0, 4);

        for(int i = _tempCycle; i <= _previousEnemyRotate; i++)
        {
            _prefabWasSpawned[i].transform.Rotate(0, _angleRotatePlatform, 0);
            
            if(_sideRotate == 0)
            {   
                _angleRotatePlatform += 2;
            }
            else if(_sideRotate == 1)
            {
                _angleRotatePlatform -= 2;
            }
            else if(_sideRotate == 2)
            {
                if(_vectorZeroForRotatePlatform)
                {   
                    _angleRotatePlatform = 0;
                    _vectorZeroForRotatePlatform = false;
                }
                
                _angleRotatePlatform +=2;
            }
            else if(_sideRotate == 3)
            {
                if(_vectorZeroForRotatePlatform)
                {   
                    _angleRotatePlatform = 0;
                    _vectorZeroForRotatePlatform = false;
                }
                
                _angleRotatePlatform -=2;
            }

            if(i == _previousEnemyRotate)
            {
                _tempCycle = i + 1;
            }
        }        
    }
}
