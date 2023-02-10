using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum HandType
{ Left, Right }

public class XRHandController : MonoBehaviour
{
    public HandType handType;
    public float thumbMoveSpeed = 0.1f;
    private Animator animator;
    private InputDevice inputDevice;
    private float indexValue;
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        while (!inputDevice.isValid)
        {
            inputDevice = GetInputDevice();
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        AnimateHand();
    }
    private InputDevice GetInputDevice()
    {
        InputDeviceCharacteristics characteristics =
        InputDeviceCharacteristics.HeldInHand |
        InputDeviceCharacteristics.Controller;
        if (handType == HandType.Left)
        {
            characteristics = characteristics |
            InputDeviceCharacteristics.Left;
        }
        else
        {
            characteristics = characteristics |
            InputDeviceCharacteristics.Right;
        }
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics,
        inputDevices);
        if (inputDevices.Count > 0)
        {
            return inputDevices[0];
        }
        else
        {
            return new InputDevice();
        }
    }
    void AnimateHand()
    {
        inputDevice.TryGetFeatureValue(CommonUsages.trigger,
        out indexValue);
        animator.SetFloat("index", indexValue);
    }
}
// Sample Code