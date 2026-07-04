using UnityEngine;
using UnityEngine.XR;

public class LaparoscopCameraControl : MonoBehaviour
{
    public Transform laparoscop;
    public Transform cameraLaparoscop;
    public XRNode hand = XRNode.RightHand;
    private Quaternion rotatieInitialaLaparoscop;
    private Quaternion rotatieInitialaCamera;
    private bool activ = false;
    private bool butonApasatInainte = false;

    void Update()
    {
        if (laparoscop == null || cameraLaparoscop == null) return;

        var device = InputDevices.GetDeviceAtXRNode(hand);
        bool buton = false;
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out buton);

        if (buton && !butonApasatInainte)
        {
            activ = !activ;

            if (activ)
            {
                rotatieInitialaLaparoscop = laparoscop.rotation;
                rotatieInitialaCamera = cameraLaparoscop.rotation;
            }
        }

        butonApasatInainte = buton;

        if (activ)
        {
            Quaternion delta = laparoscop.rotation * Quaternion.Inverse(rotatieInitialaLaparoscop);
            cameraLaparoscop.rotation = delta * rotatieInitialaCamera;
        }
    }
}

