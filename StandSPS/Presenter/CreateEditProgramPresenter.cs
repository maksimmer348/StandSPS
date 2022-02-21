namespace StandSPS;

public class CreateEditProgramPresenter : AbstractPresenter<TestProgramsForm>
{
    private ProgramModel programModel;
    public CreateEditProgramPresenter(TestProgramsForm form, ProgramModel programModel) : base(form)
    {
        this.programModel = programModel;
        programModel.OnChangedModuleList += ProgramModel_ChangedModuleList;
        //this.programModel = programModel;
    }
   
    private void ProgramModel_ChangedModuleList(List<AbstractTestModule> obj)
    {
        
    }

    public void Add()
    {
       var module = Form.SuperPresenter.ModuleLib.GetSelectedModule();
       programModel.AddModule(module);
    }

    public void Save()
    {
        TestProgram t = new TestProgram();
    }
}