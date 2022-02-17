namespace StandSPS;

public abstract class ManagerTestModules
{
    private TypeTestModule type;

    protected ManagerTestModules(TypeTestModule type)
    {
        this.type = type;
    }

    public abstract AbstractTestModule TestModule();
}