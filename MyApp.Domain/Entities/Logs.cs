using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities
{
    public class Logs
    {
        [Key]
        public int LogId { get; set; }
        
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime Log_Date { get; set; } = DateTime.Now;
        public string LogAction { get; set; }
    }
}
