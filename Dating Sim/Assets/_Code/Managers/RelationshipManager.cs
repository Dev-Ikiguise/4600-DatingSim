using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public CharacterInfo characterInfo;

    void Start()
    {

    }

   
    void Update()
    {
        
    }

    public void IncreaseRelationshipLevel(float LoveValue)
    {
        characterInfo.relationshipLevel = Mathf.Clamp(characterInfo.relationshipLevel + LoveValue, -1f, 1f);
    }

    public void DecreaseRelationshipLevel(float LoveValue)
    {
        characterInfo.relationshipLevel = Mathf.Clamp(characterInfo.relationshipLevel - LoveValue, -1f, 1f);
    }
}
