namespace StandSPS;


    public record Cycle : AbstractTestModule
    {
        //в цике должны сущетсвовавать замер парамтеров, задеркжка, вклл выкл источника
        public decimal Hour { get; set; }
        public decimal Min { get; set; }
        public byte[] Color { get; set; } = new byte[4];
        public int CycleNum
        {
            get;
            set;
        }

        // public DateTime CycleTime { get; set; }
        public Cycle()
        {
            //TODO придумать где будет преборазование
        }
        
        public override string Description()
        {
            return $"{Hour}час. ;{Min}мин.";
        }
    }