namespace ClassScheduler.API.Context
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Subject { get; set; }
    }
}
