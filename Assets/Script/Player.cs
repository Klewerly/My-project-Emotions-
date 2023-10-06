using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    DiaglogueStep diologManager;
    public bool diaglogueStarted;
    public GameObject diagloguePanel;
    public Collider closest;
    public HandCaster handCaster;
    public int buttonQuest; // 0 принимаю, 1 не принимаю
    NavMeshAgent player;
    NPC diaglogueNpc;
    public MouseLook mouseLook;
    CharacterController characterController;
    
    

    //взять квест у старосты
    VillageChief villageChief;
    public Quest currentQuest;
    public bool questPanel;
    public GameObject takeQuestPanel;

    //смерть игрока
    public bool playerDead;
    public GameObject deathPanel; //панель которая открывается при смерти перса

    //выход на другую локу
    Exit exit;
    public GameObject exitWindow;
    public bool exitWindowActive;

    //выбор заклинания
    public int spellChoise;
    public SpellEffect currentSpellEffect;
    SpellEffect1 spellEffect1;
    SpellEffect2 spellEffect2;
    SpellEffect3 spellEffect3;
    SpellEffect4 spellEffect4;




    // Start is called before the first frame update
    void Start()
    {
        villageChief = GameObject.Find("VillageChief").GetComponent<VillageChief>();
        exit = GameObject.Find("Exit").GetComponent<Exit>();
        player = GetComponent<NavMeshAgent>();
        mouseLook = mouseLook.gameObject.GetComponent<MouseLook>();
        characterController = GetComponent<CharacterController>();
        spellEffect1 = GetComponent<SpellEffect1>();
        spellEffect2 = GetComponent<SpellEffect2>();
        spellEffect3 = GetComponent<SpellEffect3>();
        spellEffect4 = GetComponent<SpellEffect4>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {

            DiaglogueCollider();
            DiagloguePanelOnOff();
            if (closest != null)
            {
                diaglogueNpc = closest.gameObject.GetComponent<NPC>();
                diaglogueNpc.ConversensionStart(diaglogueNpc);
            }
            TakeQuest();
            ExitWindow();
            //closest.gameObject.GetComponent<NPC>().ConversensionStart();

        }


    }



    public void DiaglogueCollider()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
        closest = null;
        float oldDist = 2;
        foreach (Collider go in colliders)
        {
            if (go.gameObject.tag == "CanTalk")
            {
                float dist = Vector3.Distance(transform.position, go.transform.position);



                if (dist < oldDist)
                {
                    closest = go;
                    oldDist = dist;

                }


            }



        }
        if (closest == null)
        {
            return;
        }
        else
        {
            diaglogueStarted = true;

        }






    }


    public void TakeQuest()
    {
        float dist = Vector3.Distance(transform.position, villageChief.transform.position);

        if (dist < 2)
        {
            takeQuestPanel.SetActive(true);
            takeQuestPanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = villageChief.quest.description;
            currentQuest = villageChief.quest;
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
            characterController.enabled = false;

        }
        else
        {
            return;
        }
    }

    public void DiagloguePanelOnOff()
    {
        if (diaglogueStarted == true)
        {
            diagloguePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
            characterController.enabled = false;

        }

        else
        {
            diagloguePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.enabled = true;
            characterController.enabled = true;
        }
    }

    public void PlayerDeath() // добавить как ивент на анимации врагов?
    {
        playerDead = true;
        player.speed = 0;
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;


    }

    public void RestartGame() //назначаю метод на кнопку и ставлю цифру сцены на кнопке.
    {
        DontDestroyOnLoad(GameObject.Find("Player"));
        //handCaster.spellEffect = null;
        SceneManager.LoadScene(1);

    }

    public void answerChoiseButton(int answerChoise)
    {
        if (diaglogueStarted == true)
        {

            closest.gameObject.GetComponent<NPC>().Answers(answerChoise);
            diaglogueStarted = closest.gameObject.GetComponent<NPC>().diaglogueStarted;
            DiagloguePanelOnOff();

        }
    }

    public void TakeQuestButton()
    {
        takeQuestPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        characterController.enabled = true;
    }

    public void ExitWindow()
    {
        float dist = Vector3.Distance(transform.position, exit.transform.position);

        if (currentQuest != null)
        {

            if (dist < 2)
            {
                exitWindow.SetActive(true);
                exitWindowActive = true;
                Cursor.lockState = CursorLockMode.None;
                mouseLook.enabled = false;
                characterController.enabled = false;

            }

            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
    public void ChangeScene(int scene) //назначаю метод на кнопку и ставлю цифру сцены на кнопке.
    {
        spellChoise = exit.spellChoise; //в момент нажатия кнопки перехода, плеер берет окончательный выбор закла.
        WhatSpellUse();
        StartCoroutine(DelayCoroutine(8, scene));
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        characterController.enabled = true;
        DontDestroyOnLoad(gameObject);
    }
    private IEnumerator DelayCoroutine(float timeDelay, int scene)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(scene);
    }
    public void WhatSpellUse()
    {
        if (spellChoise == 1)
        {
            currentSpellEffect = spellEffect1;
        }
        if (spellChoise == 2)
        {
            currentSpellEffect = spellEffect2;
        }
        if (spellChoise == 3)
        {
            currentSpellEffect = spellEffect3;
        }
        if (spellChoise == 4)
        {
            currentSpellEffect = spellEffect4;
        }
    }
}


