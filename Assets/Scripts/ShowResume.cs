using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResume : MonoBehaviour
{
    public void DownloadResume()
    {
        Application.OpenURL("http://msomsap.com/download/Resume2019-10-22.pdf");
    }

    public void Linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/keittisak-phasomsap-72491413b/");
    }

    public void Gmail()
    {
        Application.OpenURL("https://mail.google.com/mail/?view=cm&fs=1&to=keittisakcpm@gmail.com&su=The Resume Game&body=Hi Keittisak");
    }
}
