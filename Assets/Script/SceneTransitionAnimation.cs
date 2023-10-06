using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAnimation : MonoBehaviour
{
    public Animator animator;

	private void Start()
	{
        StartAnimation();

    }
	public void StartButton()
    {
        animator.SetTrigger("sceneEnd");
        StartCoroutine(DelayCoroutine(8, 1));
    }

    public void StartAnimation()
    {
        animator.SetTrigger("sceneStart");

    }

    private IEnumerator DelayCoroutine(float timeDelay, int scene)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(scene);
    }


    public void ExitButton()
    {
        animator.SetTrigger("sceneEnd");

    }

}
