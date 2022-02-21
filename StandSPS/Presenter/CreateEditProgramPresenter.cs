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

    private void ProgramModel_ChangedModuleList(List<AbstractTestModule> modulesList)
    {
    }

    public void AddModule()
    {
        var module = Form.SuperPresenter.ModuleLib.GetSelectedModule();
        programModel.AddModule(module);
    }

    public void RemoveModule()
    {
        //+ как ты и сказал без ндесков
        //- надо получать список в этот метод те писать метод получения значений списка или напрямую его поулчать
        //var name = ((AbstractTestModule)Form.dGridModulesList.CurrentCell.Value).Name;
        
        //+оптимально на мой взгляд 
        //+по примеру кнопок 
        //-прошлось делать элеменыт формы пять публичными
        var index = Form.dGridModulesList.CurrentCell.RowIndex;
        
        if (index >=0)
        {
            programModel.DeleteModule(index);
        }
        else
        {
            Form.CreateMessage("Выберите что удалять");
        }
    }

    public void Save()
    {
        TestProgram t = new TestProgram();
    }
}