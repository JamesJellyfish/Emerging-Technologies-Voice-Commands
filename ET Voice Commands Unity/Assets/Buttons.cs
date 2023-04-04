// https://www.youtube.com/watch?v=dzD0qP8viLw
// https://www.youtube.com/watch?v=29vyEOgsW8s
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;



public class Buttons : MonoBehaviour
{
    public Transform transform;
    public GameObject Mute;
    public GameObject Unmute;
    public GameObject VoiceDisable;
    public GameObject RaiseHand;
    public GameObject help;
    bool Toggle = true;
    bool ToggleHand = true;
    bool ToggleVoiceRec = true;
    public TextMeshProUGUI Language;

    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    //

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    //

    // Start is called before the first frame update
    void Start()
    {
        //UI
        actions.Add("mute", MuteMic);
        actions.Add("unmute", UnMute);

        actions.Add("hand up", RiseHand);
        actions.Add("hand down", DropHand);

        actions.Add("setting english", English);
        actions.Add("setting french", French);
        actions.Add("setting vietnamese", Vietnamese);

        actions.Add("help", Help);
        actions.Add("exit", Exit);

        //Movements
        actions.Add("move forward", Forward);
        actions.Add("move back", Back);
        actions.Add("move left", Left);
        actions.Add("move right", Right);

        actions.Add("Desk 1", Desk1);
        actions.Add("Desk 2", Desk2);
        actions.Add("Desk 3", Desk3);


        //
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        English();

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

        //UI Language Setting
        if (Input.GetKeyDown(KeyCode.F))
            Language.text = "French";
        if (Input.GetKeyDown(KeyCode.E))
            Language.text = "English";
        if (Input.GetKeyDown(KeyCode.V))
            Language.text = "Vietnamese";

        //Start and Stop
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (ToggleVoiceRec)
            {
                keywordRecognizer.Stop();
                VoiceDisable.SetActive(true);

                ToggleVoiceRec = false;
            }
            else
            {
                keywordRecognizer.Start();
                VoiceDisable.SetActive(false);

                ToggleVoiceRec = true;
            }
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

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {
        transform.position = transform.position + new Vector3(0f, 0f, 2f);
    }

    private void Back()
    {
        transform.position = transform.position + new Vector3(0f, 0f, -2f);
    }

    private void Left()
    {
        transform.position = transform.position + new Vector3(-2f, 0f, 0f);
    }

    private void Right()
    {
        transform.position = transform.position + new Vector3(2f, 0f, 0f);
    }

    private void Help()
    {
        help.SetActive(true);
    }

    private void Exit()
    {
        help.SetActive(false);
    }

    private void Desk1()
    {
        transform.position = new Vector3(0f, -0.05f, 5.79f);
    }

    private void Desk2()
    {
        transform.position = new Vector3(0f, -0.05f, -0.2f);
    }

    private void Desk3()
    {
        transform.position = new Vector3(0.04f, -0.05f, -5.28f);
    }

}
