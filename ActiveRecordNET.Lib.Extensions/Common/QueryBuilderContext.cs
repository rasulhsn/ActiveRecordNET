namespace ActiveRecordNET.Lib.Extensions
{
    public struct QueryBuilderContext
    {
        public string Alias { get; }

        public bool HasAlias => !string.IsNullOrWhiteSpace(Alias);

        internal QueryBuilderContext(string alias)
        {
            Alias = alias;
        }
    }
}
