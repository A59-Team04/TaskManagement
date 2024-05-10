using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class ActivityHistory
    {
        public ActivityHistory(string description)
        {
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.Time = DateTime.Now;
        }

        public string Description { get; }

        public DateTime Time { get; }

        public string ViewInfo()
        {
            return $"[{this.Time.ToString("yyyyMMdd|HH:mm:ss.ffff")}]{this.Description}";
        }
    }
}
