using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GhidProcedura : MonoBehaviour
{
    public TextMeshProUGUI textGhid;
    public List<string> instructiuni = new List<string>();

    private int pasCurent = 0;

    void Start()
    {
        AfiseazaPas();
    }

    public void PasUrmator()
    {
        if (pasCurent < instructiuni.Count - 1)
        {
            pasCurent++;
            AfiseazaPas();
        }
        else
        {
            pasCurent = instructiuni.Count;
            AfiseazaPas();
        }
    }

    public void PasInapoi()
    {
        if (pasCurent > 0)
        {
            pasCurent--;
            AfiseazaPas();
        }
    }

    void AfiseazaPas()
    {
        if (textGhid == null) return;

        if (pasCurent == 0)
        {
            textGhid.text = instructiuni[0];
        }
        else if (pasCurent < instructiuni.Count)
        {
            textGhid.text = "Pas " + pasCurent + "/" + (instructiuni.Count - 1) + "\n\n" + instructiuni[pasCurent];
        }
        else
        {
            textGhid.text = "FELICITARI!\n\nAi finalizat procedura laparoscopica cu succes!";
        }
    }
}