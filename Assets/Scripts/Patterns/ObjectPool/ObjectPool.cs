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
        [SerializeField] private List<GameObject> _pooledObjectList;
        private int _toPoolArrayIndex = -1;
        private int _pooledListIndex = 0;

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
            if (_toPoolArrayIndex >= _objectToPoolArray.Length - 1)
            {
                _toPoolArrayIndex = -1;
            }
            _toPoolArrayIndex++;
            return _objectToPoolArray[_toPoolArrayIndex];
        }

        public GameObject GetObjectFromPool()
        {
            var nextPooledObject = GetNextPooledObject();

            if (!nextPooledObject.activeInHierarchy)
            {
                nextPooledObject.SetActive(true);
                return nextPooledObject;
            }
            else
            {
                CreateInstance(out GameObject newInstance);
                newInstance.SetActive(true);
                return newInstance;
            }
        }

        private GameObject GetNextPooledObject()
        {
            if (_pooledListIndex >= _pooledObjectList.Count - 1)
            {
                _pooledListIndex = -1;
            }
            _pooledListIndex++;
            return _pooledObjectList[_pooledListIndex];
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