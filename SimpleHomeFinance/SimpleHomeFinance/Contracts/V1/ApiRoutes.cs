namespace SimpleHomeFinance.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Version = "v1";

        public const string Root = "api";

        public const string Base = Root + "/" + Version;

        public static class Operations
        {
            public const string GetAll = Base + "/operations";
            
            public const string Get = Base + "/operations/{operationId}";
            
            public const string Update = Base + "/operations/{operationId}";
            
            public const string Create = Base + "/operations";
        }
    }
}