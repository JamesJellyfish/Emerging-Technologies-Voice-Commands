// https://www.youtube.com/watch?v=dzD0qP8viLw
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

    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    // Audio
    public AudioSource source;
    public AudioDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    //

    //private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    //private KeyWordRecognizer keywordRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        //keywordActions.Add("mute", MuteMic);
        //keywordActions.Add("unmute", UnMute);
        //keywordActions.Add("rise hand", RiseHand);
        //keywordActions.Add("drop hand", DropHand);
        //keywordActions.Add("english", English);
        //keywordActions.Add("french", French);
        //keywordActions.Add("vietnamese", Vietnamese);

        English();

        Language.text = "English";

        //keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        //keywordRecognizer.OnPhraseRecognized + OnKeyworldsRecognized;
        //keywordRecognizer.Start();
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
        
        //Audio

        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
            loudness = 0;
        
        if (loudness > 0)
        {
            RaiseHand.active = true;
            Unmute.active = true;
            Mute.active = false;
        }
        else
        {
            RaiseHand.active = false;
            Mute.active = true;
            Unmute.active = false;
        }
    }

    private void English()
    {
       Language.text = "English";
    }

    private void French()
    {
        Language.text = "French";
    }

    private void Vietnamese()
    {
        Language.text = "Vietnamese";
    }

    private void RiseHand()
    {
        RaiseHand.active = true;
    }

    private void DropHand()
    {
        RaiseHand.active = false;
    }

    private void MuteMic()
    {
        Mute.active = true;
        Unmute.active = false;
    }

    private void UnMute()
    {
        Mute.active = false;
        Unmute.active = true;
    }

    //private void OnKeyworldsRecognized(PhraseRecognizedEventArgs args)
    //{
    //    Debug.Log("Keyword: " + args.text);
    //    keywordActions[args.text].Invoke();
    //}

}
