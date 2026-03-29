using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Patterns.ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        private const int STARTED_OBJECT_IN_POOL = 1;

        [Inject] private readonly DiContainer _container;

        [SerializeField] private GameObject _startedObjectToPool;
        [SerializeField] private GameObject[] _objectToPoolArray;
        private int _arrayIndex = -1;

        [SerializeField] private List<GameObject> _pooledObjectList;
        [SerializeField] private int _poolSize = 5;

        public List<GameObject> PooledObjectList => _pooledObjectList;

        private void Awake()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            _pooledObjectList = new List<GameObject>(_poolSize) { _startedObjectToPool };

            for (int i = 0; i < _poolSize - STARTED_OBJECT_IN_POOL; i++)
            {
                CreateInstance(out GameObject objectInstance);
                objectInstance.SetActive(false);
            }
        }
        private void CreateInstance(out GameObject instance)
        {
            instance = _container.InstantiatePrefab(GetNextPrefab(), transform);
            _pooledObjectList.Add(instance);
        }
        private GameObject GetNextPrefab()
        {
            if (_arrayIndex >= _objectToPoolArray.Length - 1)
            {
                _arrayIndex = -1;
            }
            _arrayIndex ++;
            return _objectToPoolArray[_arrayIndex];
        }

        public GameObject GetObjectFromPool()
        {
            foreach (GameObject gameObject in _pooledObjectList)
            {
                if (!gameObject.activeInHierarchy)
                {
                    gameObject.SetActive(true);
                    return gameObject;
                }
            }

            CreateInstance(out GameObject newInstance);
            newInstance.SetActive(true);
            return newInstance;
        }

        public void ReleaseObjectToPool(GameObject gameObject)
        {
            if (_pooledObjectList.Contains(gameObject))
            {
                gameObject.SetActive(false);
            }
        }
    }
}