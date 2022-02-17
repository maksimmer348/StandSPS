namespace StandSPS;
    public class SetTemperature : AbstractTestModule
    {
        public SetTemperature()
        {
            //TODO придумтаь где будет преобразование
        }

        //дождатся леши
        public decimal Temperature { get; set; }

        public void SetTemperatureMeasurement(double temperature)
        {
        }
        

        public override string Description()
        {
            return $"{Temperature} °C";
        }
    }
