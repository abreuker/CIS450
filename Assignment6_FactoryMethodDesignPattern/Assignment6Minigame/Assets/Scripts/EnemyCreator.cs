using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : SpaceFolkCreator
{
    public GameObject enemyPrefab;

    public override GameObject CreatePrefab(string type)
    {
        if (type.Equals("eyeball"))
        {
            enemyPrefab = Resources.Load<GameObject>("Prefabs/eye monster");
        }
        else if (type.Equals("tentacle"))
        {
            enemyPrefab = Resources.Load<GameObject>("Prefabs/tentacle");
        }
        else if (type.Equals("enemyShip"))
        {
            enemyPrefab = Resources.Load<GameObject>("Prefabs/enemy ship");
        }
        return enemyPrefab;
    }
    public override GameObject AddScript(GameObject prefab, string type)
    {
        if (type.Equals("eyeball"))
        {
            if (prefab.GetComponent<EyeballMonster>() == null)
            {
                prefab.AddComponent<EyeballMonster>();
            }
        }
        else if (type.Equals("tentacle"))
        {
            if (prefab.GetComponent<FloatingTentacle>() == null)
            {
                prefab.AddComponent<FloatingTentacle>();
            }
        }
        else if (type.Equals("enemyShip"))
        {
            if (prefab.GetComponent<EnemyShip>() == null)
            {
                prefab.AddComponent<EnemyShip>();
            }
        }
        return prefab;
    }

}
