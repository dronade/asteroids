using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}