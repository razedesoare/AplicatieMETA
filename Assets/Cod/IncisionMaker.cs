using UnityEngine;

public class IncisionMaker : MonoBehaviour
{
    public GameObject incizie;
    public LayerMask layer_piele;
    public int nrmaxinci = 4;
    public float cooldown = 1f;
    public float inaltime = 0.001f;

    private int numarinci = 0;
    private float timpanterior = -10f;

    void OnTriggerEnter(Collider obiectAtins)
    {
        if (numarinci >= nrmaxinci) return;
        if (Time.time - timpanterior < cooldown) return;
        if (((1 << obiectAtins.gameObject.layer) & layer_piele) == 0) return;

        Vector3 punct = obiectAtins.ClosestPoint(transform.position);

        if (incizie != null)
        {
            GameObject marcaj = Instantiate(incizie, punct, Quaternion.identity);
            marcaj.transform.up = Vector3.up;
            marcaj.transform.position += Vector3.up * inaltime;
        }

        numarinci++;
        timpanterior = Time.time;
    }
}

