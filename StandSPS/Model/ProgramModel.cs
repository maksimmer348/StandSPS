namespace StandSPS;

public class ProgramModel : AbstractModel
{
    public string Name { get; set; }
    
    public event Action<List<AbstractTestModule>> OnChangedModuleList;
    private List<AbstractTestModule> moduleList = new List<AbstractTestModule>();
    
    public void AddModule(AbstractTestModule module)
    {
        moduleList.Add(module);
        OnChangedModuleList?.Invoke(moduleList);
    }
    public void RemoveModule(int index)
    {
        moduleList.RemoveAt(index);
        OnChangedModuleList?.Invoke(moduleList);
    }

   
}