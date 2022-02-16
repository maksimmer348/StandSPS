namespace StandSPS.Model;

public enum TypeTestProgram
{
    Test1,
    Test2,
    None
}
public class TestProgramsModel
{
    private TestProgram testProgram;
    public bool TestProgramIsAlive { get; set; }
    public delegate void TestProgramHandler(string programName, int indexProgram);
    public event TestProgramHandler? Notify;         
    public void CreateNewProgram(TestProgram program)
    {
        TestProgram newTestProgram = testProgram;
        TestProgramIsAlive = true;
    }

    public string GetNameTestProgram()
    {
        throw new NotImplementedException();
    }
}

public class Test2 : TestProgram
{
    public Test2(string name) : base(name)
    {
      
    }

    public override void Operation()
    {
        throw new NotImplementedException();
    }
}

public class Test1 : TestProgram
{
    public Test1(string name) : base(name)
    {
    }

    public override void Operation()
    {
        throw new NotImplementedException();
    }
}

public abstract class TestProgram
{
    public string Name { get; set; }

    protected TestProgram(string name)
    {
        Name = name;
    }

    public abstract void Operation();

}