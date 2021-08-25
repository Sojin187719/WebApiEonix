namespace Eonix.Configuration
{
    public class GlobalSettings
    {
        public virtual string ProjectName { get; set; }
        public virtual string LogDirectory { get; set; }
        public virtual SqlServerSettings SqlServer { get; set; } = new SqlServerSettings();
        public virtual SwaggerSettings Swagger { get; set; } = new SwaggerSettings();
        public virtual BaseServiceUriSettings BaseServiceUri { get; set; } = new BaseServiceUriSettings();


        public class SqlServerSettings
        {
            private string _eonixConnectionString;

            public string EonixConnectionString
            {
                get => _eonixConnectionString;
                set => _eonixConnectionString = value.Trim('"');
            }

        }
        public class BaseServiceUriSettings
        {
            public string Api { get; set; }
        }

        public class SwaggerSettings
        {
            public bool IsActive { get; set; }
        }
    }
}
