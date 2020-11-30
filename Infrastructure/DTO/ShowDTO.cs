using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTO
{
    public class ShowDTO
    {
        public ShowDTO()
        {

        }
        public ShowDTO(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public string Column { get; set; }
    }
}
