namespace StandSPS;


public class TestProgramsModel
{
    

    
    private TestProgram testProgram;
    private List<TestProgram> testPrograms = new ();
    private AbstractTestModule testModule;
    
    //private TestProgramCreator creator;
    public event  Action<TestProgram> OnSelectedTestProgram;
    public event Action<List<TestProgram>> OnListProgramChanged;
    public event Action<int> OnIndexProgramChanged;
    public event Action<string> OnProgramNameChanged
    {
        add => testProgram.OnNameChanged += value;
        remove => testProgram.OnNameChanged  -= value;
    }
    public event Action<AbstractTestModule> OnModuleChanged
    {
        add => testProgram.OnModuleChanged += value;
        remove => testProgram.OnModuleChanged  -= value;
    }
    public bool TestProgramIsAlive { get; private set; }
    public bool DataBaseExist { get; set; }
    
    public bool ReadOnly { get; set; }

    //TODO как сделать оптимальнее
    public void CreateDefaultTestProgram()
    {
        //TODO как сделать оптимальнее
        testProgram = new (){Id = 1,Name = "По умолчанию", ReadOnly = true};;
        InitTestProgram();
        SaveProgramToList(testProgram.Name);
    }

    public void CreateNewTestProgram()
    {
        testProgram = new TestProgram();
        InitTestProgram();
    }

    private Random r = new Random();
    void InitTestProgram()
    { 
        //TODO как сделать оптимальнее
        ContactCheck defaultModule = new (){Id = 1,Name = "Насртойка контактирования", ContactsCount = 1};
        testProgram.AddModuleToList(defaultModule);
        testProgram.AddModuleToList(new Cycle(){Name = "kfldk", Hour = r.Next(),Min = r.Next()});
        TestProgramIsAlive = true;
        OnSelectedTestProgram?.Invoke(testProgram);
    }
    public string GetNameTestProgram()
    {
        return testProgram.Name;
    }

    public void SelectedTestProgram(int index)
    {
        testProgram = testPrograms[index];
        TestProgramIsAlive = true;
        OnSelectedTestProgram?.Invoke(testProgram);
    }
    // public TestProgram SetProgramFromList(int index)
    // {
    //     testProgram = testPrograms[index];
    //     TestProgramIsAlive = true;
    //     
    //     return testProgram;
    // }
    public void RemoveTestProgram(TestProgram testProgram)
    {
        testPrograms.Remove(testProgram);
        OnListProgramChanged?.Invoke(testPrograms);
        testProgram = null;
        TestProgramIsAlive = false;
    }
    
    public void RenameTestProgram(string newName)
    {
         testProgram.Name = newName;
         OnListProgramChanged?.Invoke(testPrograms);
    }

    public void SaveProgramToList(string name)
    {
        testProgram.Name = name;
        testPrograms.Add(testProgram);
        OnListProgramChanged?.Invoke(testPrograms);
        OnSelectedTestProgram?.Invoke(testProgram);
        
        var index = testPrograms.IndexOf(testProgram);
        OnIndexProgramChanged?.Invoke(index);
        testProgram = null;
        TestProgramIsAlive = false;
    }


   
}