using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMusicByLevel : MonoBehaviour
{
    void Start()
    {
        string nameLevel = SceneManager.GetActiveScene().name;
        AudioSystem.Instance.PlayMusic(nameLevel);
    }
}
