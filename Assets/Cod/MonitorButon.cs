using UnityEngine;

public class MonitorButton : MonoBehaviour
{
    public Camera laparoscopCamera;

    public void PornesteMonitor()
    {
        if (laparoscopCamera != null)
        {
            laparoscopCamera.gameObject.SetActive(true);
            laparoscopCamera.enabled = true;
        }
    }

    public void OpresteMonitor()
    {
        if (laparoscopCamera != null) laparoscopCamera.enabled = false;
    }
}