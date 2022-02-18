namespace StandSPS;
public class TestProgram
{
    
    public int Id { get; set; }
    public bool ReadOnly { get; set; }
   
    public event Action<AbstractTestModule> OnModuleChanged;
    //меняем или изменяем имя вызывается ивент
    public event Action<string> OnNameChanged;
    
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnNameChanged?.Invoke(Name);
            }
        }
    }
    /// <summary>
    /// список модулей
    /// </summary>
    public List<AbstractTestModule> ModulesList{ get; set; }

    public TestProgram()
    {
        ModulesList = new();
    }
    
    /// <summary>
    /// добаавить один модуль в программу
    /// </summary>
    /// <param name="module">добаавляемый модуль</param>
    public void AddModuleToList(AbstractTestModule module)
    {
        ModulesList.Add(module);
        OnModuleChanged?.Invoke(module);
    }
    
    /// <summary>
    /// изменить модуль в программе
    /// </summary>
    /// <param name="module">изменяяемый модуль</param>
    public void ChangeModuleInList(AbstractTestModule module)
    {
        ModulesList = ModulesList.OrderBy(m => m.Id == module.Id).ToList();
    }

  
}