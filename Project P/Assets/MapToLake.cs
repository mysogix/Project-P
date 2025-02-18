using UnityEngine;
using UnityEngine.SceneManagement;

public class MapToLake : MonoBehaviour
{
    public string lake;

    public void LoadScene()
    {
        SceneManager.LoadScene(lake);
    }
}
