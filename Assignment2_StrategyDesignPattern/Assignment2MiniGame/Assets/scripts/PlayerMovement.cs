using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float horizontal;
    public float moveLimiter = 0.7f;
    public float movementSpeed = 3f;

    public AudioSource fruitCollected;
    public AudioSource fruitDropped;
    public AudioSource winSound;

    public string tagAccepted;

    public BowlBehavior bowlBehavior;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bowlBehavior = gameObject.AddComponent<CatchYellow>();
    }

    // Update is called once per frame
    void Update()
    {
        tagAccepted = bowlBehavior.Catch();
        Debug.Log(tagAccepted);

        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            horizontal *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * movementSpeed, 0);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchRed>();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchOrange>();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(GetComponent<BowlBehavior>());
            bowlBehavior = gameObject.AddComponent<CatchYellow>();
        }
    }
}
