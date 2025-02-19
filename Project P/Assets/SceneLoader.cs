using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transitionAnimator;
    public string sceneLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene("Scene 1");
    }
}
