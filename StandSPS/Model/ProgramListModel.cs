namespace StandSPS;

public class ProgramListModel : AbstractModel
{
    private List<TestProgram> testPrograms = new List<TestProgram>();
    public event Action<List<TestProgram>> OnChangedPrograms; 
    
   
    
    public void CreateNewProgram(TestProgram testProgram)
    {
        //testProgram = new TestProgram();
        //testPrograms.Add(testProgram);
        //OnChangedPrograms?.Invoke(testPrograms);
        
    }

    public void RemoveProgram(TestProgram testProgram)
    {
       testPrograms.Remove(testProgram);
       OnChangedPrograms?.Invoke(testPrograms);
    }


    public void ChangeProgram(TestProgram testProgram)
    {
        //var currentProgram = testPrograms.FirstOrDefault(t => t == testProgram);
    }

    public void SaveProgram(TestProgram testProgram)
    {
        testPrograms.Add(testProgram);
        OnChangedPrograms?.Invoke(testPrograms);
    }

}