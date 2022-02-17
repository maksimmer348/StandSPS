namespace StandSPS;


public class TestProgramsModel
{
    //private TestProgramCreator creator;
    public event  Action<TestProgram> OnSelectedTestProgram;
    public event Action<List<TestProgram>> OnListProgramOnChanged;

    
    private TestProgram testProgram;
    private List<TestProgram> testPrograms = new ();
    
    public bool TestProgramIsAlive { get; private set; }
    public bool DataBaseExist { get; set; }

   
    public void CreateNewTestProgram(string name = "")
    {
        TestProgramIsAlive = true;
        testProgram = new TestProgram(name);
        testProgram.AddModuleToList(ContactCheck.Default);
        OnSelectedTestProgram?.Invoke(testProgram);
    }
    public string GetNameTestProgram()
    {
        return testProgram.Name;
    }

    public TestProgram SetProgramFromList(int index)
    {
        testProgram = testPrograms[index];
        TestProgramIsAlive = true;
        OnSelectedTestProgram?.Invoke(testProgram);
        return testProgram;
    }
    public void RemoveTestProgram(TestProgram testProgram)
    {
        testPrograms.Remove(testProgram);
        OnListProgramOnChanged?.Invoke(testPrograms);
        testProgram = null;
        TestProgramIsAlive = false;
    }
    
    public void RenameTestProgram(string newName)
    {
         testProgram.Name = newName;
         OnListProgramOnChanged?.Invoke(testPrograms);
    }

    public void SaveProgramToList(string name)
    {
        testProgram.Name = name;
        //TODO переделать под собтия
        testPrograms.Add(testProgram);
        OnListProgramOnChanged?.Invoke(testPrograms);
        OnSelectedTestProgram?.Invoke(testProgram);
        testProgram = null;
        TestProgramIsAlive = false;
    }
    
    
}