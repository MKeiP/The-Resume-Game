using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumePanal : MonoBehaviour
{
    public Image img;

    [System.Obsolete]
    IEnumerator Start()
    {
        WWW www = new WWW("http://gameassets.net/GameAssetsLogo.png");
        yield return www;
        img.sprite = Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
        img.SetNativeSize();
    }
}
