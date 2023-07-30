namespace ClassScheduler.API.Context
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
