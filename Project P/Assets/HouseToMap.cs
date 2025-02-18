using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseToMap : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Map");
    }
}
