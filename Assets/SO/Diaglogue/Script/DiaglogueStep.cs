using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Diaglogue Step", menuName = "Add Diaglogue/Diaglogue Step")]
public class DiaglogueStep : ScriptableObject
{

    [TextArea(4, 5)]
    public string npcReplic;
    public List<DiaglougeAnswer> answer;





}
