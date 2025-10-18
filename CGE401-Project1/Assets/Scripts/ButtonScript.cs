using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for Button component


    public class ButtonScript : MonoBehaviour
    {
        public void OpenExternalURL(string url)
        {
            Application.OpenURL(url);
        }
    }