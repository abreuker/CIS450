using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{
    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public static ObjectPooler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //make sure this object pooler persists across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instantiate a second" +
                "instance of singleton ObjectPooler");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary= new Dictionary<string, Queue<GameObject>>();
        FillPoolsWithInactiveObjects();
    }
    private void FillPoolsWithInactiveObjects()
    {
        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++) 
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        Debug.Log(tag);
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("pool with tag " + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void ReturnObjectToPool(string tag, GameObject objectToReturn) 
    { 
        objectToReturn.SetActive(false);
        poolDictionary[tag].Enqueue(objectToReturn);
    }
}
