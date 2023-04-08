using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameManager instance;
    public float sideScrollerSpeed = 20;
    public bool gamePaused;
    public string[] obstacleTags = new string[] { "Short", "Medium", "Tall" };

    public Vector2 spawnPos;
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
                "instance of singleton GameManager");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnScrollingObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnScrollingObjects()
    {
        while (!gamePaused)
        {
            yield return new WaitForSeconds(Random.Range(2, 4));
            ObjectPooler.instance.SpawnFromPool(obstacleTags[Random.Range(0,2)], spawnPos, Quaternion.identity);
        }
    }
}
