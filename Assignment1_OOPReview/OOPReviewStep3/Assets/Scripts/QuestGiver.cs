using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * QuestGiver.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains the implemented code for questgiver
 */
public class QuestGiver : NPC, IFriendly, IImportant
{
    private string dialogue;
    private bool questCompleted;

    //constructors
    public QuestGiver()
    {
        this.health = 1;
        this.dialogue = "Hello! I'm a QuestGiver and I'm talking!";
        this.questCompleted = false;
    }
    public QuestGiver(float health, string dialouge, bool questCompleted)
    {
        this.health = health;
        this.dialogue = dialouge;
        this.questCompleted = questCompleted;
    }

    //needed a setter
    public void SetQuestCompleted(bool questCompleted)
    {
        this.questCompleted = questCompleted;
    }

    //abstract methods needed to be implemented
    public override void Die()
    {
        if (!questCompleted)
        {
            Invincible();
        }
        else
        {
            Debug.Log("A QuestGiver just died!");
        }
    }
    public void Talk()
    {
        Debug.Log("A QuestGiver is talking! They say: \"" + dialogue + "\"");
    }
    public void Invincible()
    {
        Debug.Log("QuestGiver cannot die until quest is completed!");
    }
}
