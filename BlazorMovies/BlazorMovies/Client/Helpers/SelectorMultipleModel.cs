namespace BlazorMovies.Client.Helpers
{
    public class SelectorMultipleModel
    {
        public SelectorMultipleModel(string key, string value)
        {
            Value = value;
            Key = key;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
