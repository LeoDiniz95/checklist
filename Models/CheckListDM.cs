using checklist_api.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace checklist_api.Models
{
    [Table("todolist")]
    public class CheckListDM
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        [MinLength(3, ErrorMessage = Messages.Errors.length)]
        public string name { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        public decimal done { get; set; }

        [Required(ErrorMessage = Messages.Errors.required)]
        [StringLength(1)]
        public string status { get; set; }
    }
}
