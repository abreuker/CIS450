using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCreator : SpaceFolkCreator
{
    public GameObject allyPrefab;
    public override GameObject CreatePrefab(string type)
    {
        if (type.Equals("normalShip"))
        {
            allyPrefab = Resources.Load<GameObject>("Prefabs/ally ship");
        }
        else if (type.Equals("shotgunShip"))
        {
            allyPrefab = Resources.Load<GameObject>("Prefabs/ally ship shotgun");
        }
        return allyPrefab;
    }

    public override GameObject AddScript(GameObject prefab, string type)
    {
        if (type.Equals("normalShip"))
        {
            if (prefab.GetComponent<AllyShip>() == null)
            {
                prefab.AddComponent<AllyShip>();
            }
        }
        else if (type.Equals("shotgunShip"))
        {
            if (prefab.GetComponent<AllyShipShotgun>() == null)
            {
                prefab.AddComponent<AllyShipShotgun>();
            }
        }
        return prefab;
    }

}
