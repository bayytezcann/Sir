using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score", fileName = "Score/Variable")]
public class ScoreVariable : ScriptableObject
{
    [SerializeField] private int scoreVariable;

    public int Score
    {
        get
        {
            return scoreVariable;
        }
        set
        {
            scoreVariable = value;
        }
    }
}
