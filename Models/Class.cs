using System.ComponentModel.DataAnnotations.Schema;

namespace checklist_api.Models
{
    [Table("todolist")]
    public class CheckList
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal done { get; set; }

        public string status { get; set; }
    }
}
