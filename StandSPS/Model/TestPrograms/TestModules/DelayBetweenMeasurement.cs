namespace StandSPS;
    public class DelayBetweenMeasurement : AbstractTestModule
    {
        //просто задержка между операциями без изменения их 
        
        
        public decimal Min { get; set; }
        public decimal Sec { get; set; }
        
        public DelayBetweenMeasurement()
        {
            //TODO где производить каст
        }
        

        public override string Description()
        {
            return $"{Min}мин. ;{Sec}сек.";
        }
    }
