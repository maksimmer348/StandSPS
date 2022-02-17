using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StandSPS;
public class TestProgramsPresenter
{
    private TestProgramsModel model;
    private TestProgramsForm form;
  
    //public event Action<DataTable> OnChangeModuleTestProgram;
    public event  Action<string,DataTable> OnSelectedTestProgram;
    public TestProgramsPresenter(TestProgramsForm form , TestProgramsModel model)
    {
        this.model = model;
        this.form = form;
       // form.CreateNewTestProgram += CreateNewTestProgram;
        //form.ChangeIndexTestProgram += ChangeTestProgram;
        //form.SelectTestProgram += SelectTestProgram;
        
    }
   
    public void CreateDefaultProgram()
    {
        if (!model.DataBaseExist)
        {
            model.CreateNewTestProgram();
            model.SaveProgramToList("По умолчанию");
            OnSelectedTestProgram?.Invoke(model.GetNameTestProgram(),new DataTable());
            //OnCreateNewTestProgram?.Invoke(new DataTable());
            //TODO добавить класс с информацией о всех модулях текущей программы в new DataTable()
            //OnChangeModuleTestProgram?.Invoke(new DataTable());
        }
    }
    public void CreateNewTestProgram()
    {
        model.CreateNewTestProgram();
        OnSelectedTestProgram?.Invoke(model.GetNameTestProgram(), new DataTable());
        //OnCreateNewTestProgram?.Invoke(new DataTable());
        //TODO добавить класс с информацией о всех модулях текущей программы в new DataTable()
        //OnChangeModuleTestProgram?.Invoke(new DataTable());
    }
    
    public void SelectTestProgram(int index)
    {
        OnSelectedTestProgram?.Invoke(model.GetNameTestProgram(),new DataTable());
        //TODO добавить класс с информацией о всех модулях текущей программы в new DataTable()
        //OnChangeModuleTestProgram?.Invoke(new DataTable());
        //form.NameTestProgram = model.GetNameTestProgram();
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