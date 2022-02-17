namespace StandSPS;
public class TestProgramsPresenter
{
    private Model model;
    private TestProgramsForm form;
    
    
    public TestProgramsPresenter(TestProgramsForm form , Model model)
    {
        this.model = model;
        this.form = form;
        model.Notify+= ModelOnNotify;
    }

    
    private void ModelOnNotify(string programName, int indexProgram)
    {
        form.NameTestProgram = programName;
    }
    
    public void CreateNewProgram()
    {
       model.CreateNewProgram(form.NameTestProgram);
    }

    public void ChangeTestProgram()
    {
        throw new NotImplementedException();
    }

    public void DeleteTestProgram()
    {
        throw new NotImplementedException();
    }

    public void SelectTestProgram()
    {
        form.NameTestProgram = model.GetNameTestProgram();
    }

    public void ApplyTestProgram()
    {
        throw new NotImplementedException();
    }

    public void CancelTestProgram()
    {
        throw new NotImplementedException();
    }

    public void SaveElement()
    {
        throw new NotImplementedException();
    }

    public void CancelElement()
    {
        throw new NotImplementedException();
    }

    public void AddModule()
    {
        //TODO оформить в фабрику
        // switch (form.GetTypeTestProgram)
        // {
        //     case TypeTestProgram.Test1:
        //         model.CreateNewProgram(new Test1(form.NameTestProgram));
        //         break;
        //     case TypeTestProgram.Test2:
        //         model.CreateNewProgram(new Test2(form.NameTestProgram));
        //         break;
        //     case TypeTestProgram.None:
        //         form.CreateMessage("Выберите тип программы");
        //         break;
        // }
        throw new NotImplementedException();
    }

    public void DeleteModule()
    {
        throw new NotImplementedException();
    }

    public void MoveUpModule()
    {
        throw new NotImplementedException();
    }

    public void MoveDownModule()
    {
        throw new NotImplementedException();
    }

    public void SelectModule()
    {
        throw new NotImplementedException();
    }
}