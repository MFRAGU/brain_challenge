using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableObject : MonoBehaviour
{
    [SerializeField]
     public DifficultyLevel difficultyLevel = DifficultyLevel.Default;

     public DifficultyLevel DifficultyLevel
    {
        get { return difficultyLevel; }
        set { difficultyLevel = value; }
    }
    
}
