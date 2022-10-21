namespace ActiveRecordNET.Lib
{
    public abstract class AdoConfigurationFactory
    {
        public AdoConnectionString CreateConnectionString()
        {
            AdoConnectionStringBuilder adoConnectionStringBuilder =
                new AdoConnectionStringBuilder();

            Configure(adoConnectionStringBuilder);

            return adoConnectionStringBuilder.Build();
        }

        protected abstract void Configure(AdoConnectionStringBuilder adoConnectionStringBuilder);
    }
}
