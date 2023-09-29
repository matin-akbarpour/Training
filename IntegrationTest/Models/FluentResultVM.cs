namespace IntegrationTest.Models
{
    public class FluentResultVM<TValue>
    {
        public bool isFailed { get; set; }
        public bool isSuccess { get; set; }
        public List<Reason> reasons { get; set; }
        public List<Error> errors { get; set; }
        public List<Success> successes { get; set; }
        public TValue valueOrDefault { get; set; }
        public TValue value { get; set; }
    }

    public class FluentResultVM
    {
        public bool isFailed { get; set; }
        public bool isSuccess { get; set; }
        public List<Reason> reasons { get; set; }
        public List<Error> errors { get; set; }
        public List<Success> successes { get; set; }
    }

    public class FluentResultWithListVM<TValue>
    {
        public bool isFailed { get; set; }
        public bool isSuccess { get; set; }
        public List<Reason> reasons { get; set; }
        public List<Error> errors { get; set; }
        public List<Success> successes { get; set; }
        public List<TValue> valueOrDefault { get; set; }
        public List<TValue> value { get; set; }
    }

    public class Reason
    {
        public string message { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Metadata
    {
        public string additionalProp1 { get; set; }
        public string additionalProp2 { get; set; }
        public string additionalProp3 { get; set; }
    }
    public class Error
    {
        public string[] reasons { get; set; }
        public string message { get; set; }
        public Metadata metadata { get; set; }
    }

    public class Success
    {
        public string message { get; set; }
        public Metadata metadata { get; set; }
    }
}
