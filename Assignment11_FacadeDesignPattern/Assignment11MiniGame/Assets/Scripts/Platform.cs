using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public float speed;
    public float goalPos;
    public Animator convayorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        convayorAnimator = GameObject.FindGameObjectWithTag("convayor").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (gameObject.transform.position.x < -15)
        {
            convayorAnimator.speed = 0;
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        if (gameObject.transform.position.x > goalPos)
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
            convayorAnimator.speed = 1;
        }
        else
        { 
            convayorAnimator.speed = 0;
        }
    }

    public void Done()
    {
        goalPos = -20;
    }

}
