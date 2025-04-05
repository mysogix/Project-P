using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioSource transitionSound;

    public string SceneName;
    public Animator transition;
    public float transitionTime = 1f;
   public void ChangeScene(string SceneName)
    {
        StartCoroutine(LoadLevel(SceneName));
    }

    public IEnumerator LoadLevel(string SceneName)
    {
        transition.SetTrigger("Start");
        
        transitionSound.Play();

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneName);
    }
}
