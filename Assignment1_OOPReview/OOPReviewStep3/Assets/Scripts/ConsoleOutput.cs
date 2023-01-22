using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * ConsoleOutput.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains the 'main' function, testing all code.
 */
public class ConsoleOutput : MonoBehaviour
{
    Bandit bandit;
    Townsfolk townsfolk;
    QuestGiver questGiver;

    public List<NPC> npcs = new List<NPC>();
    public List<IFriendly> friendlies = new List<IFriendly>();

    // Start is called before the first frame update
    void Start()
    {
        //declaring the starting npcs
        bandit = new Bandit();
        townsfolk = new Townsfolk();
        questGiver = new QuestGiver();

        Debug.Log("All NPCs doing their independent action based on Interface: ");
        townsfolk.Talk();
        questGiver.Talk();
        bandit.Attack();

        Debug.Log("All NPCs taking damage:");
        townsfolk.BeAttacked(1);
        questGiver.BeAttacked(1);
        bandit.BeAttacked(1);

        Debug.Log("Setting QuestGiver's quest to completed...");
        questGiver.SetQuestCompleted(true);

        Debug.Log("Attack the quest giver again now that invincibility is gone:");
        questGiver.BeAttacked(1);

        //all the new npcs for the polymorphic lists
        Townsfolk townsfolk1 = new Townsfolk();
        Townsfolk townsfolk2 = new Townsfolk(2, "Hello! I am a different Townsfolk!");
        Bandit bandit1 = new Bandit();
        Bandit bandit2 = new Bandit(2, 3);
        QuestGiver questGiver1 = new QuestGiver(1, "Hello! I am certainly a QuestGiver!", true);
        QuestGiver questGiver2 = new QuestGiver();
        
        //add to npcs
        npcs.Add(townsfolk1);
        npcs.Add(townsfolk2);
        npcs.Add(bandit1);
        npcs.Add(bandit2);
        npcs.Add(questGiver1);

        //add to friendlies
        friendlies.Add(townsfolk1);
        friendlies.Add(townsfolk2);
        friendlies.Add(questGiver1);
        friendlies.Add(questGiver2);

    }

    // Update is called once per frame
    void Update()
    {
        //press '1' for polymorphic list of npcs
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Killing the list of NPCs.");
            foreach (NPC nPC in npcs)
            {
                nPC.Die();
            }
        }
        //press '2' for polymorphic list of friendlies (quest giver is both friendly and important)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Talking to the list of Friendlies");
            foreach (IFriendly friendly in friendlies)
            {
                friendly.Talk();
            }
        }
    }
}
