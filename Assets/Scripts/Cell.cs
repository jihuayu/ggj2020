using UnityEngine;


public class Cell : MonoBehaviour
{
    public float health = 100;
    public float speed = 5;
    public float attack = 10;
    public float defense = 3;
    public float attackRange = 2;
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
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * (cell.transform.position - transform.position).normalized);
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
