using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

public class Virus : Cell
{
    public int copyRate = 5;
    private float _remainTime;
    public int glycoproteinProduce = 10;
    public int aminoAcidProduce = 20;
    // Start is called before the first frame update
    void Start()
    {
        _remainTime = copyRate;
    }

    // Update is called once per frame
    void Update()
    {
        AttackOrMove("anti");
        CheckAlive();
        CheckCopy();
    }

    void CheckCopy()
    {
        _remainTime -= Time.deltaTime;
        if (_remainTime < 0)
        {            
            _remainTime = copyRate;
            Instantiate(gameObject);
        }
    }
    
    void CheckAlive()
    {
        if (health < 0)
        {
            var antiManager = GameObject.FindGameObjectWithTag("AntiManager");
            var antiSpawner = antiManager.GetComponent<AntiSpawner>();
            antiSpawner.glycoprotein += glycoproteinProduce;
            antiSpawner.aminoAcid += aminoAcidProduce;
            Destroy(gameObject);
        }
    }
}
