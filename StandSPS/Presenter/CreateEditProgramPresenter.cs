namespace StandSPS;

public class CreateEditProgramPresenter : AbstractPresenter<TestProgramsForm>
{
    private TestProgram testProgram;
    public event Action<TestProgram> OnSave;
    public event Action<bool> OnClose;
    public CreateEditProgramPresenter(TestProgramsForm form, TestProgram testProgram) : base(form)
    {
        this.testProgram = testProgram;
        //testProgram.OnChangedModuleList += ProgramModel_ChangedModuleList;
        //this.programModel = programModel;
    }

    private void ProgramModel_ChangedModuleList(List<AbstractTestModule> modulesList)
    {
        var tupleList = new List<(string, string, int)>();

        foreach (var module in modulesList)
        {
            tupleList.Add((module.Name, module.Description(), module.Index));
        }
    }

    public void SaveProgram()
    {
        if (!string.IsNullOrWhiteSpace(Form.tBoxTestProgramName.Text))
        {
            testProgram.Name = Form.tBoxTestProgramName.Text;
        }
        else
        {
            Form.CreateMessage("Назоваитье прграмму");
            return;
        }
        OnSave?.Invoke(testProgram);
    }
    public void AddModule()
    {
        var module = Form.SuperPresenter.ModuleLib.GetSelectedModule();
        //testProgram.AddModule(module);
    }

    public void RemoveModule()
    {
       
        var index = Form.dGridModulesList.CurrentCell.RowIndex;
        
        if (index >=0)
        {
            //testProgram.RemoveModule(index);
        }
        else
        {
            Form.CreateMessage("Выберите что удалять");
            return;
        }
    }
    
}