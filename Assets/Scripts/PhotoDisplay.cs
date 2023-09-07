using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoDisplay : MonoBehaviour
{

    public RawImage currentPhoto;
    public Image flicker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushPhoto(Texture2D newPhoto)
    {
        currentPhoto.texture = newPhoto;
        Color c = flicker.color;
        c.a = 1;
        flicker.color = c;
        c.a = 0;
        LeanTween.value(flicker.gameObject, setColorCallback, flicker.color, c, .2f).setEase(LeanTweenType.easeOutQuint).setDelay(.05f);
    }

    private void setColorCallback(Color c)
    {
        flicker.color = c;
    }
}
