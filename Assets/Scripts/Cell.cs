using System;
using UnityEngine;


public class Cell : MonoBehaviour
{
    public int health = 100;
    public int speed = 5;
    public int attack = 10;
    public int defense = 3;
    public int attackRange = 2;

    protected void AttackOrMove(string cellType)
    {
        var obj = FindNearestCell(cellType);
        float dis = Vector3.Distance(obj.transform.position, transform.position);
        var cell = obj.GetComponent<Cell>();
        if (dis < attackRange)
        {
            cell.health = cell.health - attack + cell.defense;
        }
        else
        {
            transform.Translate(speed * Time.deltaTime * (cell.transform.position - transform.position).normalized);
        }
    }

    GameObject FindNearestCell(string cellType)
    {
        var targetArr = GameObject.FindGameObjectsWithTag(cellType);
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
