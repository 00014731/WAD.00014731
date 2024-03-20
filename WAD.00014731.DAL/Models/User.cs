using System.Diagnostics;

namespace WAD._00014731.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
