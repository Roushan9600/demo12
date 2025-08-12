using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo1.Models {
    public class Quiz {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int QuizType { get; set; }

        public string AccessibleOfficeId { get; set; }

        public int? CompanyAccessibleLevel { get; set; }

        public int State { get; set; }

        public string PublishedCode { get; set; }

    }
}
