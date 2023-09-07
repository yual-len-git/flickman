using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initHints : MonoBehaviour
{
    public Toggle m_Toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (loadScenes.hintToggle)
            m_Toggle.isOn = true;
    }
}
