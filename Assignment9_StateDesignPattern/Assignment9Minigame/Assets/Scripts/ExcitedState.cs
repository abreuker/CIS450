using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExcitedState : PetState
{
    PetAIStateManager petAIStateManager;

    SpriteRenderer spriteRenderer;
    Animator animator;
    ParticleSystem hearts;

    public GameManager gameManager;

    public float horizontal;

    private float changeTimeCount = 0;
    public float changeTimeLow = .5f;
    public float changeTimeHigh = 2;

    public float horizontalLimit = 8;

    public float moveSpeed = 5;
    private Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.zero };
    public int currentMoveDirection;

    GameObject excitedBark;

    // Start is called before the first frame update
    void Start()
    {
        petAIStateManager = gameObject.GetComponent<PetAIStateManager>();
        excitedBark = GameObject.FindGameObjectWithTag("ExcitedBark");
        excitedBark.GetComponent<TextMeshProUGUI>().enabled = false;
        animator = GameObject.FindGameObjectWithTag("Pet").GetComponent<Animator>();
        spriteRenderer = GameObject.FindGameObjectWithTag("Pet").GetComponent<SpriteRenderer>();
        hearts = GameObject.FindGameObjectWithTag("Hearts").GetComponent<ParticleSystem>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public override void Bark()
    {
        StartCoroutine(ShowBark());
    }

    public IEnumerator ShowBark()
    {
        excitedBark.GetComponent<TextMeshProUGUI>().enabled = true;
        yield return new WaitForSeconds(2);
        excitedBark.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public override void BePetted()
    {
        gameManager.numOfPets++;
        hearts.Play();
        Debug.Log("Is currently excited! Can't be more excited!");
    }

    public override void Eat()
    {
        Debug.Log("Ate while excited!");
        petAIStateManager.currentState = petAIStateManager.idleState;
    }

    public override void Move()
    {
        this.transform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

        if (changeTimeCount > 0)
        {
            changeTimeCount -= Time.deltaTime;
        }
        else
        {
            changeTimeCount = UnityEngine.Random.Range(changeTimeLow, changeTimeHigh);

            currentMoveDirection = Mathf.FloorToInt(UnityEngine.Random.Range(0, moveDirections.Length));
            if (currentMoveDirection == 0 && transform.position.x > horizontalLimit)
            {
                currentMoveDirection = 1;
            }
            else if (currentMoveDirection == 1 && transform.position.x < -horizontalLimit)
            {
                currentMoveDirection = 0;
            }
            if (currentMoveDirection == 0)
            {
                horizontal = 1;
            }
            else if (currentMoveDirection == 1)
            {
                horizontal = -1;
            }
        }

        if (horizontal > 0.01f)
        {
            if (spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (horizontal < -0.01f)
        {
            if (spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }
        if (currentMoveDirection == 0 || currentMoveDirection == 1)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

