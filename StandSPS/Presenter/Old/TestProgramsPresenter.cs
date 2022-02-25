using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StandSPS;

public class TestProgramsPresenter
{
    private TestProgramsModel model;
    private TestProgramsForm form;
    DataTable dt;
    public TestProgramsPresenter(TestProgramsForm form, TestProgramsModel model)
    {
        this.model = model;
        this.form = form;
        InitDataTable();
        // form.CreateNewTestProgram += CreateNewTestProgram;
        // form.ChangeIndexTestProgram += ChangeTestProgram;
        // form.SelectTestProgram += SelectTestProgram;
        model.OnListProgramChanged += ModelOnListProgramOnChanged;
        model.OnSelectedTestProgram += OnSelectedTestProgram;
        model.OnIndexProgramChanged += OnIndexProgramChanged;
    }
    private void InitDataTable()
    {
        dt = new DataTable();
        dt.Columns.Add("Module", typeof(string));
        dt.Columns.Add("Descriprion", typeof(string));
        dt.Columns.Add("Index", typeof(int));
    }
    private void OnIndexProgramChanged(int index)
    {
        form.UpdateProgramsIndex(index);
    }
    
    private void OnSelectedTestProgram(TestProgram testProgram)
    {
        form.NameTestProgram = testProgram.Name;
        
        dt.Rows.Clear();
        foreach (var module in testProgram.ModulesList)
        {
            dt.Rows.Add(module.Name, module.Description(), module.Index);
        }
        form.UpdateModules(dt);
    }

    private void ModelOnListProgramOnChanged(List<TestProgram> testPrograms)
    {
        
        // var testProgramsNames = testPrograms.Select(x => x.Name).ToList();
        // form.UpdateProgramsList(testProgramsNames);
    }

    public void CreateDefaultProgram()
    {
        if (!model.DataBaseExist)
        {
            model.CreateDefaultTestProgram();
        }
    }

    public void CreateNewTestProgram()
    {
        form.UiModeEditProgram();
        model.CreateNewTestProgram();
    }

    public void SelectTestProgram(int index)
    {
        model.SelectedTestProgram(index);
    }


    public void ChangeTestProgram()
    {
        if (model.TestProgramIsAlive)
        {
            form.CreateMessage($"Сперва сохраните текущую программу " +
                               $"{model.GetNameTestProgram()}");
            return;
        }
        if (model.ReadOnly)
        {
            form.CreateMessage("Программа только для чтения");
            return;
        }
        //model.SelectedTestProgram(form.GetIndexTestProgram);
        form.NameTestProgram = model.GetNameTestProgram();
        form.UiModeEditProgram();
        //OnChangeModuleTestProgram?.Invoke(new DataTable());
    }


    public bool ValidateNameCollision(string name)
    {
        return false;
        //return testPrograms.Select(x => x.Name == name).First();
    }

    public void DeleteTestProgram()
    {
        if (model.TestProgramIsAlive)
        {
            // if (model)
            // {
            //     
            // }
        }
    }


    public void ApplyTestProgram()
    {
        throw new NotImplementedException();
    }

    public void CancelTestProgram()
    {
    }

    public void SaveElement()
    {
        var programNameText = form.NameTestProgram;

        if (string.IsNullOrWhiteSpace(programNameText))
        {
            form.CreateMessage("У программы дожно быть имя");
            return;
        }

        if (ValidateNameCollision(programNameText))
        {
            form.CreateMessage("Программа не дожна иметь имя, что уже есть в списке");
            return;
        }

        model.SaveProgramToList(form.NameTestProgram);
        form.UiModeEditProgramList();
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

    private void ModelOnNotify(string programName, int indexProgram)
    {
        form.NameTestProgram = programName;
    }
}