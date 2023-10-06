using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Emotion", menuName = "Add Emotion")]

public class Emotion : ScriptableObject
{
    public string emotionName;
    [TextArea(4, 5)]
    public string description;
    public int emotionPoints;
}
