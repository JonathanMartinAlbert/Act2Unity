using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadLevelByName (string level)
    {
        SceneManager.LoadScene(level);
    }
}
