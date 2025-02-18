using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseToMap : MonoBehaviour
{
    public AudioSource transitionSound; // AudioSource für den Übergangssound

    public void LoadScene()
    {
       
            // Sound abspielen
             SceneManager.LoadScene("Map");
            transitionSound.Play();


    }
