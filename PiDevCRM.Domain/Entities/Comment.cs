using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiDevCRM.Domain.Entities
{
    public class Comment
    {
        [Key]
        public int IdComment { get; set; }
        public int IdPoste { get; set; }
        public int IdUser { get; set; }
        public String Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CommentDate { get; set; }
        [ForeignKey("IdPoste")]
        public virtual Postes Postes { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

    }
}
