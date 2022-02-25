namespace StandSPS;

public class ProgramListPresenter : AbstractPresenter<TestProgramsForm>
{
    private ProgramListModel listModel;
    public event Action<TestProgram, bool> OnChangedProgram;
    public ProgramListPresenter(TestProgramsForm form, ProgramListModel listModel) : base(form)
    {
        this.listModel = listModel;
        listModel.OnChangedPrograms += ListModel_ChangedPrograms;
    }

    //находится здесь тк относится к совему презентеру
    private void ListModel_ChangedPrograms(List<TestProgram> testPrograms)
    {
        Form.listViewPrograms.Clear();
        foreach (var program in testPrograms)
        {
            ListViewItem item = new()
            {
                Text = program.Name,
                Tag = program,
            };
            
            Form.listViewPrograms.Items.Add(item);
        }
    }

    public void CreateNewProgram()
    {
        var testProgram = new TestProgram()
        {
            Name = "Test"
        };
       
        OnChangedProgram?.Invoke(testProgram, false);
    }
    public void AddProgram(TestProgram testProgram)
    {
        listModel.SaveProgram(testProgram);
    }
    public void RemoveProgram()
    {
        if (ProgramExist("Выберите что удалять",out var testProgram))
        {
            listModel.RemoveProgram(testProgram);
            OnChangedProgram?.Invoke(testProgram, false);
        }
    }

    public void ChangeProgram()
    {
        if (ProgramExist("Выберите что изменять",out var testProgram))
        {
            listModel.ChangeProgram(testProgram);
            OnChangedProgram?.Invoke(testProgram, false);
        }
    }
    
    public void SelectedProgram()
    {
        if (ProgramExist("Вы ничего не выбрали",out var testProgram))
        {
            //listModel.ChangeProgram(testProgram);
            OnChangedProgram?.Invoke(testProgram, true);
        }
    }

    private bool ProgramExist(string message, out TestProgram program )
    {
        if (Form.listViewPrograms.SelectedItems.Count > 0)
        {
            program = (TestProgram)Form.listViewPrograms.SelectedItems[0].Tag;
            return true;
        }
        Form.CreateMessage(message);
        program = null;
        return false;
    }
}