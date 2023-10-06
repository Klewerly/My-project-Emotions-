using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour
{

    [SerializeField] GameObject target;
    MouseLook mouseLook;
    CharacterController characterController;
    public GameObject deadGhoulPanel;
    public GameObject deadGhoulAten;

    private void Start()
	{
        target = GameObject.Find("Player").gameObject;
        mouseLook = target.GetComponentInChildren<MouseLook>();
        characterController = target.GetComponent<CharacterController>();

        StartCoroutine(DelayCoroutine(3));
    }

	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (target != null)
            {
                float dist = Vector3.Distance(gameObject.transform.position, target.transform.position);
                if (dist <= 5)
                {



                    Cursor.lockState = CursorLockMode.None;
                    mouseLook.enabled = false;
                    characterController.enabled = false;
                    deadGhoulPanel.SetActive(true);

                }
            }

        }
    }

    private IEnumerator DelayCoroutine(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        deadGhoulAten.SetActive(true);
        yield return new WaitForSeconds(timeDelay);
        deadGhoulAten.SetActive(false);
    }


    public void StartWaveButton() //назначить на кнопку дл€ продолжени€ след волны
    {
        deadGhoulPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        characterController.enabled = true;
    }
}
