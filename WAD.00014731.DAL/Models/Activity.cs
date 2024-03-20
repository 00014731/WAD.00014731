namespace WAD._00014731.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double DurationInMinutes { get; set; }
        public int CaloriesBurned { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
