using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PetAIStateManager petAIStateManager;
    public bool barkCalled;

    public GameObject howToPlayScreen;
    public TextMeshProUGUI petText;
    public int numOfPets;

    public PetHunger petHunger;

    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomBark());
    }

    // Update is called once per frame
    void Update()
    {
        petText.text = "Times Pet: " + numOfPets;
        petAIStateManager.Move();
        if (!barkCalled)
        {
            petAIStateManager.Bark();
            barkCalled = true;
        }


        if (petHunger.hunger < 30)
        {
            petAIStateManager.currentState = petAIStateManager.hungryState;
        }
        else if (petHunger.hunger < 50)
        {
            petAIStateManager.currentState = petAIStateManager.idleState;
        }
    }

    public IEnumerator RandomBark()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,6));
            petAIStateManager.Bark();
        }
    }

    public void FoodButtonPressed()
    {
        Instantiate(food);
    }

    public void HowToPlayButton()
    {
        if (howToPlayScreen.activeSelf)
        {
            howToPlayScreen.SetActive(false);
        }
        else
        {
            howToPlayScreen.SetActive(true);
        }
    }
}
