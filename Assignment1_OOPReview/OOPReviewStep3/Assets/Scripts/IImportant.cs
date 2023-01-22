using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Anna Breuker
 * IImportant.cs
 * Assignment1 - OOPReview - Easy Mode
 * This code contains an interface for imporant NPCs 
 * (NPCs that cannot be killed until their quest is 
 * completed.)
 */
public interface IImportant
{
    //prevents NPC from dying until quest has been completed.
    public void Invincible();
}
