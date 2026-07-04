using UnityEngine;

public class ButonButelie : MonoBehaviour
{
    public Material materialRosu;     
    public Material materialVerde;    
    private Renderer rend;
    private bool pornit = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        if (rend != null && materialRosu != null) rend.material = materialRosu;
    }
    public void Apasa()
    {
        if (pornit) return;
        pornit = true;

        if (rend != null && materialVerde != null) rend.material = materialVerde;
        
    }
}