using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject info, Bottons;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Info()
    {
        Bottons.SetActive(false);
        info.SetActive(true);
    }
    public void NegativeInfo()
    {
        Bottons.SetActive(true);
        info.SetActive(false);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
