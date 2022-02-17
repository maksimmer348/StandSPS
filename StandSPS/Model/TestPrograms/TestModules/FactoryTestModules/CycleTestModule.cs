namespace StandSPS;

public class CycleTestModule : AbstractTestModule
{
    /// <summary>
    /// список модулей
    /// </summary>
    public List<AbstractTestModule> ModulesList{ get; set; }

    /// <summary>
    /// добаавить один модуль в программу
    /// </summary>
    /// <param name="module">добаавляемый модуль</param>
    public void AddModuleToList(AbstractTestModule module)
    {
        ModulesList.Add(module);
    }
        
    /// <summary>
    /// изменить модуль в программе
    /// </summary>
    /// <param name="module">изменяяемый модуль</param>
    public void ChangeModuleInList(AbstractTestModule module)
    {
        ModulesList = ModulesList.OrderBy(m => m.Id == module.Id).ToList();
    }
    public CycleTestModule()
    {
        ModulesList = new();
    }
    
    public override string Description()
    {
        throw new NotImplementedException();
    }
}