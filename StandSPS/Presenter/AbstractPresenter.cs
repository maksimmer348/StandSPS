namespace StandSPS;

public abstract class AbstractPresenter<TForm> where TForm : Form
{
    protected TForm Form;

    protected AbstractPresenter(TForm form)
    {
        this.Form = form;
    }
}