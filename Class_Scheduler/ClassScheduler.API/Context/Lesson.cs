namespace ClassScheduler.API.Context
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }

        public int TeacherId { get; set; }

        public int studentCount { get; set; }

        public int RoomId { get; set; }
    }
}
