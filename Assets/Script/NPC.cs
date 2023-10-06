using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NPC : MonoBehaviour
{
    public Player player;
    public Inventory inventory;
    public Emotion goodEmotion;
    public Emotion badEmotion;

    //ниже UI диолога
    public List<DiaglougeAnswer> currentAnswers;
    public DiaglougeUI diaglogueUI;
    public DiaglogueStep oldStep;
    public DiaglogueStep lastStep;
    public bool diaglogueStarted;
    public int diaglogueRepPoints;
    public DiaglogueStep currentStep;
    public Diaglogue diaglogue;
    public string currentReplic;


    // Start is called before the first frame update
    void Start()
    {

        lastStep = diaglogue.Step.LastOrDefault();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
        


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ConversensionStart(NPC npc)
    {
        diaglogueStarted = player.diaglogueStarted;
        if (diaglogueStarted == true)
        {

            currentStep = npc.diaglogue.Step[0];
            currentReplic = currentStep.npcReplic;
            diaglogueUI.npcText.text = currentReplic;
            //Debug.Log(currentReplic);
            currentAnswers = currentStep.answer;

            for (int i = 0; i < currentAnswers.Count; i++)
            {
                diaglogueUI.buttonsText[i].text = currentAnswers[i].answer;
            }

        }

        else
        {
            return;
        }
    }





    public void Answers(int answerChoise)
    {

       
        if (answerChoise == 0)
        {
            ClearDialougeCash();
            if (currentStep.answer[answerChoise].nextStep == null)
            {
                diaglogueStarted = false;
                GiveEmotion();
                return;
            }
            diaglogueRepPoints += currentStep.answer[answerChoise].diaglogueRepPoint;
            oldStep = currentStep;
            currentStep = oldStep.answer[answerChoise].nextStep;
            currentReplic = currentStep.npcReplic;
            diaglogueUI.npcText.text = currentReplic;
            //Debug.Log(currentReplic);
            currentAnswers = currentStep.answer;

            for (int i = 0; i < currentAnswers.Count; i++)
            {
                diaglogueUI.buttonsText[i].text = currentAnswers[i].answer;
            }



        }
        if (answerChoise == 1)
        {
            ClearDialougeCash();
            if (currentStep.answer[answerChoise].nextStep == null)
            {
                diaglogueStarted = false;
                GiveEmotion();
                return;
            }
            diaglogueRepPoints += currentStep.answer[answerChoise].diaglogueRepPoint;
            oldStep = currentStep;
            currentStep = oldStep.answer[answerChoise].nextStep;
            currentReplic = currentStep.npcReplic;
            diaglogueUI.npcText.text = currentReplic;
            //Debug.Log(currentReplic);
            currentAnswers = currentStep.answer;

            for (int i = 0; i < currentAnswers.Count; i++)
            {
                diaglogueUI.buttonsText[i].text = currentAnswers[i].answer;
            }

        }
        if (answerChoise == 2)
        {
            ClearDialougeCash();
            if (currentStep.answer[answerChoise].nextStep == null)
            {
                diaglogueStarted = false;
                GiveEmotion();
                return;
            }
            diaglogueRepPoints += currentStep.answer[answerChoise].diaglogueRepPoint;
            oldStep = currentStep;
            currentStep = oldStep.answer[answerChoise].nextStep;
            currentReplic = currentStep.npcReplic;
            diaglogueUI.npcText.text = currentReplic;
            //Debug.Log(currentReplic);
            currentAnswers = currentStep.answer;

            for (int i = 0; i < currentAnswers.Count; i++)
            {
                diaglogueUI.buttonsText[i].text = currentAnswers[i].answer;
            }

        }


    }
    public void GiveEmotion()
    {
        if (diaglogueRepPoints > 0)
        {
            inventory.addEmotionInventory(goodEmotion);
        }
        
        if (diaglogueRepPoints < 0)
        {
            inventory.addEmotionInventory(badEmotion);
        }
    }
    public void ClearDialougeCash()
    {
        diaglogueUI.npcText.text = null;

        for (int i = 0; i < currentAnswers.Count; i++)
        {
            diaglogueUI.buttonsText[i].text = null;
        }

    }
    
}
