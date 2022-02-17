namespace StandSPS;


public class Model
{
    private TestProgram testProgram;
    public bool TestProgramIsAlive { get; set; }
    public delegate void TestProgramHandler(string programName, int indexProgram);
    public event TestProgramHandler? Notify;         
    public void CreateNewProgram(string nameProgram)
    {
        testProgram = new TestProgram(nameProgram);
        TestProgramIsAlive = true;
    }

    public string GetNameTestProgram()
    {
        throw new NotImplementedException();
    }
}