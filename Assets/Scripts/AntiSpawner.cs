using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class AntiSpawner : MonoBehaviour 
{
    public float glycoprotein = 20;
    public float aminoAcid = 50;
    public float glycoproteinProduceRate = 10;
    public float aminoAcidProduceRate = 20;
    public GameObject[] antis;
    public int currentIndex = 0;
    private static AntiSpawner _antiSpawner;
    public static AntiSpawner AS => _antiSpawner;

    private void Awake () {
        _antiSpawner = this;
    }
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
            var o = Instantiate(cell);
            o.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position;
            o.GetComponent<Transform>().position +=new Vector3((float)Math.Cos(Random.Range(0,100))*0.5f,(float)Math.Sin(Random.Range(0,100))*0.5f,0);
            
            currentIndex++;
            glycoprotein -= anti.glycoproteinCost;
            aminoAcid -= anti.aminoAcidCost;
        }
    }
    
}
