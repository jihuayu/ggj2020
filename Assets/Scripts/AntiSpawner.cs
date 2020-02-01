using System;
using UnityEngine;
using UnityEngine.Serialization;


public class AntiSpawner : MonoBehaviour 
{
    public int glycoprotein = 10;
    public int aminoAcid = 20;
    public int glycoproteinProduceRate = 10;
    public int aminoAcidProduceRate = 20;
    public GameObject[] antis;
    public int currentIndex = 0;

    private void Update()
    {
        glycoprotein += glycoproteinProduceRate;
        aminoAcid += aminoAcidProduceRate;
        if (antis.Length == 0)
        {
            return;
        }
        if (antis.Length <= currentIndex)
        {
            currentIndex = 0;
        }
        var cell = antis[currentIndex];
        var anti = cell.GetComponent<Anti>();
        if (glycoprotein >= anti.glycoproteinCost && aminoAcid >= anti.aminoAcidCost)
        {
            Instantiate(cell);
            glycoprotein -= anti.glycoproteinCost;
            aminoAcid -= anti.aminoAcidCost;
        }
    }
    
}
