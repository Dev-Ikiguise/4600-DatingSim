using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public static RelationshipManager Instance;
    public CharacterInfo characterInfo;

    void Start()
    {
        Instance = this;
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
