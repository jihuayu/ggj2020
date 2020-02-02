using System;
using Skill;
using UnityEngine;
using UnityEngine.Serialization;

public class SkillManager : MonoBehaviour
{
    public ISkill[] skills = {new Antibiotics(), new CoolDown(), new RadiationTherapy()};
    
    private void Update()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            var o = skills[i];
            {
                if (o.active)
                {
                    if (Math.Floor(o.CoolDownTimeRemain) != Math.Floor(o.CoolDownTimeRemain -= Time.deltaTime))
                    {
                        o.Start();
                        Debug.Log(111);
                    }

                    o.CoolDownTimeRemain -= Time.deltaTime;
                    if (o.CoolDownTimeRemain < 0)
                    {
                        o.CoolDownTimeRemain = o.CoolDownTime;
                        o.active = false;
                    }
                }
            }
        }
    }

    void OnGUI()
    {
        var go = GameObject.FindGameObjectWithTag("skill");
        var size = go.GetComponent<SpriteRenderer>().bounds.size;
        var tran = go.transform.position;
        // GUILayout.BeginArea(new Rect(tran.x - size.x / 2, tran.y - size.y / 2, tran.x + size.x / 2,
            // tran.y + size.y / 2));
        {
            if (GUILayout.Button("降温"))
            {
                foreach (var sk in skills)
                {
                    if (sk.Name == "CoolDown")
                    {
                        sk.active = true;
                        sk.CoolDownTimeRemain = sk.CoolDownTime;
                    }
                }
            }

            if (GUILayout.Button("化疗"))
            {
                foreach (var sk in skills)
                {
                    if (sk.Name == "RadiationTherapy")
                    {
                        sk.active = true;
                        sk.CoolDownTimeRemain = sk.CoolDownTime;

                    }
                }
            }

            if (GUILayout.Button("抗生素"))
            {
                foreach (var sk in skills)
                {
                    if (sk.Name == "Antibiotics")
                    {
                        sk.active = true;
                        sk.CoolDownTimeRemain = sk.CoolDownTime;

                    }
                }
            }
        }
        // GUILayout.EndArea();
    }
}