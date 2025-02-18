using UnityEngine;
using UnityEngine.SceneManagement;

public class MapToLake
{
    public string lake;

    public void LoadScene()
    {
        SceneManager.LoadScene(lake);
    }
}
