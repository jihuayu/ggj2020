using UnityEngine;
using Random = UnityEngine.Random;


public class Cell : MonoBehaviour
{
    public float health = 100;
    public float speed = 1;
    public float attack = 10;
    public float defense = 3;
    public float attackRange = 0.5f;
    public float backRange = 0.02f;
    public float damage = 0.1f;

    protected void CheckHealth()
    {
        GameManager.GM.hp -= damage;
    }
    
    protected void AttackOrMove(string cellType)
    {
        var obj = FindNearestCell(cellType);
        if (obj == null)
        {
            return;
        }
        float dis = Vector3.Distance(obj.transform.position, transform.position);
        var cell = obj.GetComponent<Cell>();
        if (dis < attackRange)
        {
            cell.health = cell.health - attack * Time.deltaTime + cell.defense * Time.deltaTime;
            obj.GetComponent<Transform>().position+=new Vector3((float)Math.Cos(Random.Range(0,100))*backRange,(float)Math.Sin(Random.Range(0,100))*backRange,0);
        }
        else
        {
            var d = (cell.transform.position - transform.position);
            
            transform.Translate(speed * Time.deltaTime * ((d.x*d.x+d.y*d.y)*new Vector3((float)Math.Cos(Random.Range(0,100)),(float)Math.Sin(Random.Range(0,100)),0)+d).normalized);
        }
    }

    GameObject FindNearestCell(string cellType)        
    {        
        var targetArr = GameObject.FindGameObjectsWithTag(cellType);
        if (targetArr.Length == 0){
            return null;
        }
        var distance = 999999999.0;
        var index = 0;
        for(var i = 0;i < targetArr.Length;++i)
        {
            float dis = Vector3.Distance(targetArr[i].transform.position, transform.position);
            if (dis < distance)
            {
                distance = dis;
                index = i;
            }
        }
        return targetArr[index];
    }
}
