namespace StandSPS;

public class ModuleLibPresenter : AbstractPresenter<TestProgramsForm>
{
    public ModuleLibPresenter(TestProgramsForm form) : base(form)
    {
    }

    public AbstractTestModule GetSelectedModule()
    {
        if (Form.rBtnCycle.Checked)
        {
            return new Cycle() with
            {
                Hour = Form.numUpCycleHour.Value,
                Min = Form.numUpCycleMin.Value
            };
        }

        if (Form.rBtnDelayBetwenMesaure.Checked)
        {
            return new DelayBetweenMeasurement()
                {Min = Form.numUpDelayBetwenMesaureMin.Value, Sec = Form.numUpDelayBetwenMesaureSec.Value};
        }

        if (Form.rBtnParamMeasureVoltage.Checked)
        {
            return new OutputVoltageMeasure();
        }

        if (Form.rBtnSetTemperature.Checked)
        {
            return new SetTemperature() {Temperature = Form.numUpSetTemperature.Value};
        }

        if (Form.rBtnSupplyOn.Checked)
        {
            return new SupplyOn();
        }

        if (Form.rBtnContactCheck.Checked)
        {
            return new ContactCheck();
        }

        if (Form.rBtnSupplyOff.Checked)
        {
            return new SupplyOff();
        }

        if (Form.rBtnParamMeasureTemperature.Checked)
        {
            return new ParamMeasurementTemperature();
        }

        return null;
    }
}