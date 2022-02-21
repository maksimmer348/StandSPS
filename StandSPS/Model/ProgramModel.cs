namespace StandSPS;

public class ProgramModel : AbstractModel
{
    public event Action<List<AbstractTestModule>> OnChangedModuleList;
    private List<AbstractTestModule> moduleList = new List<AbstractTestModule>();
    public void AddModule(AbstractTestModule module)
    {
       moduleList.Add(module);
       OnChangedModuleList?.Invoke(moduleList);
    }
    public void DeleteModule(int index)
    {
        moduleList.RemoveAt(index);
        OnChangedModuleList?.Invoke(moduleList);
    }
    
}