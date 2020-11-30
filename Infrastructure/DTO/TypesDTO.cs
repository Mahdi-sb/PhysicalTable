using Infrastructure.Enum;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DTO
{
    public class TypesDTO
    {
        public TypesDTO()
        {

        }
        public TypesDTO(string name, ColumnTypes type , string value , string Table)
        {
            TableName = Table;
            FieldName = name;
            FieldType = type;
            Value = value;
        }
        public string TableName { get; set; }
        [Required]
        public string Value { get; set; }
        public string FieldName { get; set; }
        public ColumnTypes FieldType { get; set; }
    }
}
