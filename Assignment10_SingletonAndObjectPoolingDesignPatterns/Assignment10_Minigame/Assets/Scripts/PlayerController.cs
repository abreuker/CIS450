using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 jumpHeight;
    public float groundLevel;
    public Animator animator;
    public bool isRolling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameObject.transform.position.y <= groundLevel)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
        if(Input.GetMouseButtonDown(1) && !isRolling && gameObject.transform.position.y <= groundLevel)
        {
            StartCoroutine(Roll());
        }

        if (gameObject.transform.position.y > groundLevel)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    public IEnumerator Roll()
    {
        isRolling = true;
        animator.SetBool("isRolling", true);
        yield return new WaitForSeconds(.5f);
        isRolling = false;
        animator.SetBool("isRolling", false);
    }
}
