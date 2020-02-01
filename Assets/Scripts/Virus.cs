using UnityEngine;

public class Virus : Cell
{
    public float copyRate = 5;
    private float _remainTime;
    public float glycoproteinProduce = 10;
    public float aminoAcidProduce = 20;
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
            Debug.Log("copy");

        }
    }
    
    void CheckAlive()
    {
        if (health < 0)
        {
            AntiSpawner.AS.glycoprotein += glycoproteinProduce;
            AntiSpawner.AS.aminoAcid += aminoAcidProduce;
            Destroy(gameObject);
            Debug.Log("die");

        }
    }
}
