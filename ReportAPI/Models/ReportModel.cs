using System.ComponentModel.DataAnnotations.Schema;

namespace ReportAPI.Models
{
    public class ReportDefinition
    {
        public long ID { get; set; }

        public string ReportName { get; set; }

        public long TemplateType { get; set; }

        public string Definition { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? InsertDate { get; set; }
    }
}