namespace E2EStarter
{
    public sealed class BusRoute
    {
        BusRoute() { }

        public int Id
        {
            get;
            set;
        }

        public bool Active
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Origin
        {
            get;
            set;
        }

        public string Destionation
        {
            get;
            set;
        }
    }
}
