using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator transitionAnim;
    void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
        new WaitForSeconds(3);
    }
    IEnumerator Transition(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
