namespace StandSPS;

public class ProgramModel : AbstractModel
{
    public event Action<List<AbstractTestModule>> OnChangedModuleList;
    private List<AbstractTestModule> ModuleList = new List<AbstractTestModule>();
    public void AddModule(AbstractTestModule module)
    {
       ModuleList.Add(module);
       OnChangedModuleList?.Invoke(ModuleList);
    }
}