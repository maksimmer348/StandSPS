using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StandSPS;

public class TestProgramsPresenter
{
    private TestProgramsModel model;
    private TestProgramsForm form;

    public TestProgramsPresenter(TestProgramsForm form, TestProgramsModel model)
    {
        this.model = model;
        this.form = form;
        form.CreateNewTestProgram += CreateNewTestProgram;
        form.ChangeIndexTestProgram += ChangeTestProgram;
        form.SelectTestProgram += SelectTestProgram;
        model.OnListProgramOnChanged += ModelOnListProgramOnChanged;
        model.OnSelectedTestProgram += ModelOnOnSelectedTestProgram;
    }

    private void ModelOnOnSelectedTestProgram(TestProgram testProgram)
    {
        foreach (var VARIABLE in testProgram.ModulesList)
        {
            
        }
        
    }

    private void ModelOnListProgramOnChanged(List<TestProgram> testPrograms)
    {
        var testProgramsNames = testPrograms.Select(x => x.Name).ToList();
        form.UpdateProgramsList(testProgramsNames);
    }

    public void CreateDefaultProgram()
    {
        if (!model.DataBaseExist)
        {
            model.CreateNewTestProgram();
            model.SaveProgramToList("По умолчанию");
        }
    }

    public void CreateNewTestProgram()
    {
        model.CreateNewTestProgram();
    }

    public void SelectTestProgram(int index)
    {
    }


    public void ChangeTestProgram()
    {
        if (model.TestProgramIsAlive)
        {
            form.CreateMessage($"Сперва сохранитье текущую программу " +
                               $"{model.GetNameTestProgram()}");
            return;
        }

        model.SetProgramFromList(form.GetIndexTestProgram);
        form.NameTestProgram = model.GetNameTestProgram();

        //OnChangeModuleTestProgram?.Invoke(new DataTable());
    }


    public bool ValidateNameCollision(string name)
    {
        return true;
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
        throw new NotImplementedException();
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