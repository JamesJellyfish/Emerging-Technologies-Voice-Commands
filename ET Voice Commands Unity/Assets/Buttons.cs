using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Buttons : MonoBehaviour
{
    public GameObject Mute;
    public GameObject Unmute;
    public GameObject RaiseHand;
    bool Toggle = true;
    bool ToggleHand = true;
    public TextMeshProUGUI Language;

    // Start is called before the first frame update
    void Start()
    {
        Language.text = "English";
    }

    // Update is called once per frame
    void Update()
    {
        //Mute and Unmute
        if (Input.GetKeyDown(KeyCode.M)) {
            if (Toggle)
            {
                Mute.active = true;
                Unmute.active = false;
               
                Toggle = false;
            }
            else
            {
                Mute.active = false;
                Unmute.active = true;

                Toggle = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (ToggleHand)
            {
                RaiseHand.active = true;

                ToggleHand = false;
            }
            else
            {
                RaiseHand.active = false;
               
                ToggleHand = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
            Language.text = "French";
        if (Input.GetKeyDown(KeyCode.E))
            Language.text = "English";
        if (Input.GetKeyDown(KeyCode.V))
            Language.text = "Vietnamese";
    }
}
