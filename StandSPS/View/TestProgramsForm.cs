using System.Data;
using System.Diagnostics;
using StandSPS.Model;
using StandSPS.Presenter;

namespace StandSPS
{
    public partial class TestProgramsForm : Form
    {
        private TestProgramsPresenter presenter;
        public TestProgramsForm()
        {
            InitializeComponent();
            presenter = new TestProgramsPresenter(this, new TestProgramsModel());
        }
        
        #region додбавление программы в список и работа с этим списком

        /// <summary>
        /// создать новую программу
        /// </summary>
        /// <param name="sender">создать</param>
        /// <param name="e"></param>
        private void btnCreateTestProgram_Click(object sender, EventArgs e)
        {
            presenter.CreateNewProgram();
        }

        /// <summary>
        /// изменить программу
        /// </summary>
        /// <param name="sender">измениить</param>
        /// <param name="e"></param>
        private void btnChangeTestProgram_Click(object sender, EventArgs e)
        {
            presenter.ChangeTestProgram();
        }

        /// <summary>
        /// удалить программу
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelTestProgram_Click(object sender, EventArgs e)
        {
            presenter.DeleteTestProgram();
        }

        /// <summary>
        /// выбрать программу из списка для изменения, удаления илли применения
        /// </summary>
        /// <param name="sender">listBoxProgramList</param>
        /// <param name="e"></param>
        private void listBoxProgramsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.SelectTestProgram();
        }

        /// <summary>
        /// применить выбранную программу 
        /// </summary>
        /// <param name="sender">ок</param>
        /// <param name="e"></param>
        private void btnSelectTestProgram_Click(object sender, EventArgs e)
        {
            presenter.ApplyTestProgram();
        }

        /// <summary>
        /// отменить операцию выбора програамы
        /// </summary>
        /// <param name="sender">отмена</param>
        /// <param name="e"></param>
        private void btnCancelTestProgram_Click(object sender, EventArgs e)
        {
            presenter.CancelTestProgram();
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
            presenter.SaveElement();
        }

        /// <summary>
        /// отменить изменение или создание программы/цикла
        /// </summary>
        /// <param name="sender">отменить</param>
        /// <param name="e"></param>
        private void btnCancelCreateTestProgram_Click(object sender, EventArgs e)
        {
            presenter.CancelElement();
        }

        /// <summary>
        /// добавление модуля в программу
        /// </summary>
        /// <param name="sender">добавить</param>
        /// <param name="e"></param>
        private void btnAddModule_Click(object sender, EventArgs e)
        {
            presenter.AddModule();
        }

        /// <summary>
        /// удаление модуля из программы
        /// </summary>
        /// <param name="sender">удалить</param>
        /// <param name="e"></param>
        private void btnDelModule_Click(object sender, EventArgs e)
        {
            presenter.DeleteModule();
        }

        /// <summary>
        /// подвинуть модуль в проргамме на одну позицию вверх
        /// </summary>
        /// <param name="sender">↑</param>
        /// <param name="e"></param>
        private void btnUpModule_Click(object sender, EventArgs e)
        {
            presenter.MoveUpModule();
        }

        /// <summary>
        ///  подвинуть модуль в проргамме на одно позицию вниз
        /// </summary>
        /// <param name="sender">↓</param>
        /// <param name="e"></param>
        private void btnDownModule_Click(object sender, EventArgs e)
        {
            presenter.MoveDownModule();
        }

        /// <summary>
        /// выбор модуля для изменения или удаления
        /// </summary>
        /// <param name="sender">модуль в гридлисте</param>
        /// <param name="e"></param>
        private void dGridModulesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            presenter.SelectModule();
        }

        #endregion


        #region GetData
        
        public string NameTestProgram
        {
           get => tBoxTestProgramName.Text;
           set => tBoxTestProgramName.Text = value;
        }

        public int SetIndexTestProgram => listBoxProgramsList.SelectedIndex;

        public TypeTestProgram GetTypeTestProgram
        {
            get
            {
                if (rBtnContactCheck.Checked)
                {
                    return TypeTestProgram.Test1;
                }

                if (rBtnContactCheck.Checked)
                {
                    return TypeTestProgram.Test1;
                }
                return TypeTestProgram.None;
            }
        }

        #endregion

        #region MessagesInfo

        public void CreateMessage(string text)
        {
            MessageBox.Show(text);
        }

        #endregion
      
    }
}