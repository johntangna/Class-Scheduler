namespace ClassScheduler.API.Context.DTOs
{
    /// <summary>
    /// 教师类数据实体
    /// </summary>
    public class TeacherDTO : BaseDTO
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Subject { get; set; }
    }
}
