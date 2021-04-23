using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IPS.ContentManagementSystem.Domain.Entities
{
    public class AssessmentQuestions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public Guid AssessmentTypeId { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }
        public int Points { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}
