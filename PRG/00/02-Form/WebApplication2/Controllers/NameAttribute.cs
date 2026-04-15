using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Controllers
{
    public class NameAttribute : ValidationAttribute
    {
        public string Value { get; set; }

        public NameAttribute(string value)
        {
            Value = value;
        }
        public override bool IsValid(object? value)
        {
            return value.ToString() != this.Value;
        }
    }
}
