namespace StandSPS;

// public class TestProgramCreator
// {
//     public event Action<TestProgram> ListProgramOnChanged;
//     private TestProgram testProgram;
//     private List<TestProgram> TestPrograms = new ();
//
//     public void CreateTestProgram(string name)
//     {
//         testProgram = new TestProgram(name);
//         TestPrograms.Add(testProgram);
//         ListProgramOnChanged?.Invoke(testProgram);
//     }
//     public void RemoveTestProgram(TestProgram testProgram)
//     {
//         TestPrograms.Remove(testProgram);
//         ListProgramOnChanged?.Invoke(testProgram);
//     }
//     
// }