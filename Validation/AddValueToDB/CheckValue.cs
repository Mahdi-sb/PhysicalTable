using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Validation.AddValueToDB
{
    public class CheckValue : ICheckValue
    {
        
        public string CheckBool(List<TypesDTO> values)
        {
            foreach (var item in values)
            {

                if (item.FieldType == ColumnTypes.BOOL && (item.Value.ToLower() != "true" && item.Value.ToLower() != "false"))
                {
                    return Massage.IsBool;
                }


            }
            return Massage.IsOk;
        }

        public string CheckInt(List<TypesDTO> values)
        {
            foreach (var item in values)
            {
                if (item.FieldType == ColumnTypes.INT && item.Value.Any(char.IsLetter))
                {
                    return Massage.IsInt;

                }

            }
            return Massage.IsOk;
        }

        public string CheckString(List<TypesDTO> values)
        {
            foreach (var item in values)
            {
                if (item.FieldType == ColumnTypes.STRING && item.Value.All(char.IsDigit))
                {
                    return Massage.IsString;
                }
            }
            return Massage.IsOk;
        }

        public string CheckValues(List<TypesDTO> values)
        {
            if (CheckString(values) != "ok") return CheckString(values);
            if (CheckInt(values) != "ok") return CheckInt(values);
            if (CheckBool(values) != "ok") return CheckBool(values);
            return Massage.IsOk;
        }
    }
}
