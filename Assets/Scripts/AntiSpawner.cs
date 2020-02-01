using System;
using UnityEngine;
using UnityEngine.Serialization;


public class AntiSpawner : MonoBehaviour 
{
    public float glycoprotein = 10;
    public float aminoAcid = 20;
    public float glycoproteinProduceRate = 10;
    public float aminoAcidProduceRate = 20;
    public GameObject[] antis;
    public int currentIndex = 0;

    private void Update()
    {
        glycoprotein += glycoproteinProduceRate * Time.deltaTime;
        aminoAcid += aminoAcidProduceRate * Time.deltaTime;
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
            currentIndex++;
            glycoprotein -= anti.glycoproteinCost;
            aminoAcid -= anti.aminoAcidCost;
        }
    }
    
}
