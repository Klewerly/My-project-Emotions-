using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//[CreateAssetMenu(fileName = "New Diaglogue Answer", menuName = "Add Diaglogue/Diaglogue Answer")]
[Serializable] public class DiaglougeAnswer //: ScriptableObject
{
    [TextArea(4, 5)]
    public string answer;
    public int diaglogueRepPoint;
    public DiaglogueStep nextStep;


     

}
