namespace StandSPS;

public class ManagerNormalModules : ManagerTestModules
{
    public ManagerNormalModules(TypeTestModule type) : base(type)
    {
    }

    public override AbstractTestModule TestModule()
    {
       // var testModule = new 
       return new Cycle();
    }
}