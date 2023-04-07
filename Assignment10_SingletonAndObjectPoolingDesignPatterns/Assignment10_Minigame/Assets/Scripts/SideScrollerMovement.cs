using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerMovement : MonoBehaviour
{
    public float obstacleBoundary;
    public string poolerTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.gamePaused)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.left * GameManager.instance.sideScrollerSpeed;
        }
        if (gameObject.transform.position.x < obstacleBoundary)
        {
            ObjectPooler.instance.ReturnObjectToPool(poolerTag, gameObject);
        }
    }
}
