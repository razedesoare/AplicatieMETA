using UnityEngine;
using UnityEngine.XR;

public class PensaProxy : MonoBehaviour
{
    public Transform pensa;
    public Transform proxy;
    public Transform tip;
    public XRNode hand = XRNode.RightHand;
    public float grabRange = 0.3f;
    public string organTag = "Organ";
    private bool activ;
    private bool butonInainte;
    private bool triggerInainte;
    private Vector3 offsetPozitie;
    private Quaternion offsetRotatie;
    private Transform organApucat;
    private Transform parinteOriginal;

    void Update()
    {
        if (pensa == null || proxy == null) return;
        var device = InputDevices.GetDeviceAtXRNode(hand);
        device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buton);
        if (buton && !butonInainte)
        {
            activ = !activ;
            if (activ)
            {
                offsetPozitie = proxy.position - pensa.position;
                offsetRotatie = Quaternion.Inverse(pensa.rotation) * proxy.rotation;
            }
        }
        butonInainte = buton;
        if (!activ) return;
        proxy.position = pensa.position + offsetPozitie;
        proxy.rotation = pensa.rotation * offsetRotatie;
        device.TryGetFeatureValue(CommonUsages.triggerButton, out bool trigger);
        if (trigger && !triggerInainte && organApucat == null)
            ApucaOrgan();

        if (!trigger && triggerInainte)
            ElibereazaOrgan();

        triggerInainte = trigger;
    }

    void ApucaOrgan()
    {
        Vector3 punct = tip != null ? tip.position : proxy.position;
        Collider[] coliziuni = Physics.OverlapSphere(punct, grabRange);
        Transform organGasit = null;
        float distantaMinima = grabRange;
        foreach (Collider col in coliziuni)
        {
            if (!col.CompareTag(organTag)) continue;
            float distanta = Vector3.Distance(punct, col.ClosestPoint(punct));
            if (distanta < distantaMinima)
            {
                distantaMinima = distanta;
                organGasit = col.transform;
            }
        }

        if (organGasit == null) return;
        organApucat = organGasit;
        parinteOriginal = organApucat.parent;
        organApucat.SetParent(tip != null ? tip : proxy, true);
    }

    void ElibereazaOrgan()
    {
        if (organApucat == null) return;
        organApucat.SetParent(parinteOriginal, true);
        organApucat = null;
    }
}