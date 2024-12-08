using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI output;
    public TMP_InputField username;

    public void Button()
    {
        output.text = username.text;
    }
}