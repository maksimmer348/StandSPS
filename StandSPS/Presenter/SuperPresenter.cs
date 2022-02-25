namespace StandSPS;

public class SuperPresenter : AbstractPresenter<TestProgramsForm>
{
    private TestProgramsForm form;
    public ProgramListPresenter ProgramList;
    public ModuleLibPresenter ModuleLib;
    public CreateEditProgramPresenter CreateEditProgram;

    public SuperPresenter(TestProgramsForm form) : base(form)
    {
        this.form = form;
        ProgramList = new ProgramListPresenter(form, new ProgramListModel());
        ModuleLib = new ModuleLibPresenter(form);
       
        ProgramList.OnChangedProgram += ProgramList_ChangedProgram;
    }

    private void CreateEditProgram_Close(bool isClosed)
    {
        Form.UiModeEditProgramList();
            CreateEditProgram = null;
    }

    private void CreateEditProgram_SavedTestProgram(TestProgram programModel)
    {                              
        ProgramList.AddProgram(programModel);
        Form.UiModeEditProgramList();
        CreateEditProgram = null;
    }

    private void ProgramList_ChangedProgram(TestProgram testProgram, bool readOnly)
    {
        CreateEditProgram = new CreateEditProgramPresenter(form, testProgram);
        CreateEditProgram.OnSave += CreateEditProgram_SavedTestProgram;
        CreateEditProgram.OnClose += CreateEditProgram_Close;
        Form.UiModeEditProgram();
    }
    
}