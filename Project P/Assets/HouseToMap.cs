using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseToMap : MonoBehaviour
{
    public AudioSource transitionSound; // AudioSource für den Übergangssound

    public void LoadScene()
    {
        if (transitionSound != null)
        {
            // Sound abspielen
            transitionSound.Play();

            // Szene erst nach der Länge des Sounds wechseln
            Invoke("ChangeScene", transitionSound.clip.length);
        }
        else
        {
            // Falls kein Sound gesetzt ist, sofort wechseln
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Map");
    }
}
