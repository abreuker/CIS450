using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceFolkCreator : MonoBehaviour
{
    public abstract GameObject CreatePrefab(string type);
    public abstract GameObject AddScript(GameObject prefab, string type);
}
