using System.Data;

namespace StandSPS;

public partial class TestProgramsForm : Form
{
    public SuperPresenter SuperPresenter;
    
    
    //+используется только здесь
    //+не является какойто логикой просто данные
    //не придется делать листвью/гриедвью публичным
    //- веротно нарушает паттерн(инфы в интернет не нашел можно при mvc зранить в форме индексы)
    //private int indexModule;
    public TestProgramsForm()
    {
        InitializeComponent();
        SuperPresenter = new SuperPresenter(this);
        
        UiModeEditProgramList();
    }
    
    #region додбавление программы в список и работа с этим списком

    /// <summary>
    /// создать новую программу
    /// </summary>
    /// <param name="sender">создать</param>
    /// <param name="e"></param>
    private void btnCreateTestProgram_Click(object sender, EventArgs e)
    {
        //CreateNewTestProgram?.Invoke();
        //SuperPresenter.();
    }

    /// <summary>
    /// изменить программу
    /// </summary>
    /// <param name="sender">измениить</param>
    /// <param name="e"></param>
    private void btnChangeTestProgram_Click(object sender, EventArgs e)
    {
        //ChangeIndexTestProgram?.Invoke();
        //presenter.ChangeTestProgram();
    }

    /// <summary>
    /// удалить программу
    /// </summary>
    /// <param name="sender">удалить</param>
    /// <param name="e"></param>
    private void btnDelTestProgram_Click(object sender, EventArgs e)
    {
        //presenter.DeleteTestProgram();
    }

    /// <summary>
    /// выбрать программу из списка для изменения, удаления илли применения
    /// </summary>
    /// <param name="sender">listBoxProgramList</param>
    /// <param name="e"></param>
    private void listBoxProgramsList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //var index = listBoxProgramsList.SelectedIndex;
        //SelectTestProgram?.Invoke(index);
        ////presenter.SelectTestProgram();
    }
    private void listBoxProgramsList_MouseClick(object sender, MouseEventArgs e)
    {
        var index = listBoxProgramsList.SelectedIndex;
        //SelectTestProgram?.Invoke(index);
        ////presenter.SelectTestProgram();
    }
    /// <summary>
    /// применить выбранную программу 
    /// </summary>
    /// <param name="sender">ок</param>
    /// <param name="e"></param>
    private void btnSelectTestProgram_Click(object sender, EventArgs e)
    {
        //presenter.ApplyTestProgram();
    }

    /// <summary>
    /// отменить операцию выбора програамы
    /// </summary>
    /// <param name="sender">отмена</param>
    /// <param name="e"></param>
    private void btnCancelTestProgram_Click(object sender, EventArgs e)
    {
        //presenter.CancelTestProgram();
    }

    #endregion

    #region создание программы и работа с модулями

    /// <summary>
    /// сохранить программу в список программ/цикл в программу
    /// </summary>
    /// <param name="sender">сохранить</param>
    /// <param name="e"></param>
    private void btnSaveTestProgram_Click(object sender, EventArgs e)
    {
        //presenter.SaveElement();
    }

    /// <summary>
    /// отменить изменение или создание программы/цикла
    /// </summary>
    /// <param name="sender">отменить</param>
    /// <param name="e"></param>
    private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
    {
        //presenter.CancelElement();
    }

    /// <summary>
    /// добавление модуля в программу
    /// </summary>
    /// <param name="sender">добавить</param>
    /// <param name="e"></param>
    private void btnAddModule_Click(object sender, EventArgs e)
    {
        SuperPresenter.CreateEditProgram.AddModule();
        //presenter.AddModule();
    }

    /// <summary>
    /// удаление модуля из программы
    /// </summary>
    /// <param name="sender">удалить</param>
    /// <param name="e"></param>
    private void btnDelModule_Click(object sender, EventArgs e)
    {
        SuperPresenter.CreateEditProgram.RemoveModule();
        //SuperPresenter.CreateEditProgram.RemoveModule(indexModule);
        //presenter.DeleteModule();
    }

    /// <summary>
    /// подвинуть модуль в проргамме на одну позицию вверх
    /// </summary>
    /// <param name="sender">↑</param>
    /// <param name="e"></param>
    private void btnUpModule_Click(object sender, EventArgs e)
    {
        
        //presenter.MoveUpModule();
    }

    /// <summary>
    ///  подвинуть модуль в проргамме на одно позицию вниз
    /// </summary>
    /// <param name="sender">↓</param>
    /// <param name="e"></param>
    private void btnDownModule_Click(object sender, EventArgs e)
    {
        //presenter.MoveDownModule();
    }

    /// <summary>
    /// выбор модуля для изменения или удаления
    /// </summary>
    /// <param name="sender">модуль в гридлисте</param>
    /// <param name="e"></param>
    private void dGridModulesList_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        //SuperPresenter.SetIndexModule(e.RowIndex);
    }
    private void dGridModulesList_MouseClick(object sender, MouseEventArgs e)
    {

    }
    #endregion


    #region GetSetData

    public string NameTestProgram
    {
        get => tBoxTestProgramName.Text;
        set => tBoxTestProgramName.Text = value;
    }

    public int GetIndexTestProgram => listBoxProgramsList.SelectedIndex;

    public TypeTestModule GetTypeTestProgram
    {
        get
        {
            return TypeTestModule.None;
        }
    }

    public void ModulesListUpdate(DataTable dt)
    {
        dGridModulesList.DataSource = dt;
    }

    #endregion

    #region MessagesInfo

    public void CreateMessage(string text)
    {
        MessageBox.Show(text);
    }

    private void TextBoxProgramNameClear()
    {
        tBoxTestProgramName.Text = String.Empty;
    }

    public void UpdateProgramsList(List<string> programsNames)
    {
        listBoxProgramsList.DataSource = programsNames;
    }
    public void UpdateProgramsIndex(int index)
    {
        listBoxProgramsList.SetSelected(index, true);
    }

    #endregion

    #region UiController

    //Controlos state
    void EnableAllControls()
    {
        foreach (Control control in Controls)
        {
            control.Enabled = true;
        }
    }

    void DisableSelectedControl(params Control[] controls)
    {
        foreach (var control in controls)
        {
            control.Enabled = false;
        }
    }
    
    public void UiModeEditProgram()
    {
        EnableAllControls();
        DisableSelectedControl(gBoxTestProgramList);
    }

    public void UiModeEditProgramList()
    {
        EnableAllControls();
        DisableSelectedControl(gBoxModule, gBoxCreateOrChangeTestProgramOrCycle,
            btnUpModule, btnDownModule, btnAddModule, btnDelModule);
       
    }

    public void UiModeEditCycle()
    {
        EnableAllControls();
        DisableSelectedControl(gBoxTestProgramList);
    }

    //Controls colors
    void ResetColorsAllControls()
    {
        foreach (Control control in Controls)
        {
            control.BackColor = default;
        }
    }

    void ChangeColorsControls(Color color, params Control[] controls)
    {
        foreach (Control control in Controls)
        {
            control.BackColor = default;
        }
    }

    public void ChangeColorForModule(Color moduleColor)
    {
        ResetColorsAllControls();
        ChangeColorsControls(moduleColor, rBtnCycle, pBoxCycle, labelCycleHour,
            labelCycleMin,
            pBoxCreateOrChangeTestProgramOrCycle, rBtnParamMeasureVoltage, rBtnParamMeasureTemperature,
            pBoxModuleInProgramOrCycle, rBtnDelayBetwenMesaure, labelDelayBetwenMesaureMin,
            labelDelayBetwenMesaureSec);
    }


    #endregion

   
}