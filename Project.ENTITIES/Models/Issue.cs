using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Issue : BaseEntity
    {
        public Issue()
        {
            IssueStatus = IssueStatus.Open;
        }

        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public int? AppUserID { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }

    }
}
