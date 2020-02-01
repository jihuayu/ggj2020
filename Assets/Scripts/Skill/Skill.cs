using UnityEngine;


public interface ISkill
{
    string Name { get; }
    float CoolDownTime { get; }
    float CoolDownTimeRemain { get; set; }
    void Start();
}
