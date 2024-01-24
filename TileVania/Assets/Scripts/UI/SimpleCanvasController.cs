using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCanvasController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _screens;

    private void Reset()
    {
        foreach(Transform child in transform)        
            _screens.Add(child.gameObject);        
    }

    public void ShowScreen (GameObject current)
    {
        foreach (GameObject screen in _screens)
        {
            if (current == screen)
                current.SetActive(true);
            else
                screen.SetActive(false);
        }
    }
}
