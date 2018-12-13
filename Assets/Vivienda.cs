using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vivienda : MonoBehaviour
{

    public float m2, costom2 = 5;
    public int habs;
    public int baths;
    public int pisosonum;
    public float beneficios;
    public Vivienda(float im2, int ihabs, int ibaths, int ipisonum, bool tuyo)
    {
        m2 = im2;
        habs = ihabs;
        baths = ibaths;
        pisosonum = ipisonum;
        beneficios = im2 * costom2 + habs * 50 + ibaths * 25;
    }
    public Vivienda(float im2, int ihabs, int ibaths, int ipisonum, float icostom2, bool tuyo)
    {
        costom2 = icostom2;
        m2 = im2;
        habs = ihabs;
        baths = ibaths;
        pisosonum = ipisonum;
        beneficios = (im2* costom2 + habs* 50 + ibaths* 25)*pisosonum;
    }
}
