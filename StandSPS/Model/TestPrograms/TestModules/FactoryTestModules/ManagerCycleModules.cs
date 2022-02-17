namespace StandSPS;
public class ManagerCycleModules : ManagerTestModules
{
    public ManagerCycleModules(TypeTestModule type) : base(type)
    {
    }

    public override AbstractTestModule TestModule()
    {
        var cycle = new Cycle
        {
            Name = "Cycle"
        };
        return cycle;
    }
}