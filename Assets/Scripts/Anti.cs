public class Anti : Cell
{
    public float glycoproteinCost = 10;
    public float aminoAcidCost = 20;

    private void Update()
    {
        AttackOrMove("virus");
        CheckAlive();
    }   
    void CheckAlive()
    {
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
