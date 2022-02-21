namespace StandSPS;

public class SuperPresenter : AbstractPresenter<TestProgramsForm>
{
    public ProgramListPresenter ProgramList;
    public ModuleLibPresenter ModuleLib;
    public CreateEditProgramPresenter CreateEditProgram;
    
    public SuperPresenter(TestProgramsForm form) : base(form)
    {
        ProgramList = new ProgramListPresenter(form);
        ModuleLib = new ModuleLibPresenter(form);
        CreateEditProgram = new CreateEditProgramPresenter(form, new ProgramModel());
    }
    
    
}