using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneLoader : MonoBehaviour
{
    public AudioSource transitionSound;
    public AudioSource doorSound;
    public string SoundName;

    public string SceneName;
    public Animator transition;
    public float transitionTime = 1f;
   public void ChangeScene(string SceneName)
    {
        StartCoroutine(LoadLevel(SceneName));
    }

    public void PlaySound(string SoundName)
    {
        switch (SoundName)
        {
            case "Door":
                doorSound.Play();
                break;

            case "Transition":
                transitionSound.Play();
                break;

            default:
                Debug.LogWarning("MissingInput");
                break;
        }
    }

    public IEnumerator LoadLevel(string SceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneName);
    }
}
