using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScenes : MonoBehaviour
{
    public static float globalBalance = 839.29f;
    public static bool hintToggle = true;
    public Toggle m_Toggle;

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void setHintToggle() {
        loadScenes.hintToggle = m_Toggle.isOn;
        print("hint toggle set to: " + loadScenes.hintToggle);
    }
}
