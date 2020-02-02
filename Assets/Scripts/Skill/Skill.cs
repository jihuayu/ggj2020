using UnityEngine;


public interface ISkill
{
    string Name { get; }
    float CoolDownTime { get; }
    float CoolDownTimeRemain { get; set; }
    bool active { get; set; }
    void Start();
}
