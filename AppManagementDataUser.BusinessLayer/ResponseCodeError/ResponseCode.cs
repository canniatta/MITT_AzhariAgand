using System.ComponentModel;
using System.Reflection;

namespace AppManagementDataUser.BusinessLayer.ResponseCodeError
{
    public class ResponseCode
    {
        public enum errorList
        {
            [Description("Success")] MI000 = 000,
            [Description("Username already exist")] MI001 = 001,
            [Description("email already exist")] MI002 = 002,
            [Description("Skill not found")] MI003 = 003,
            [Description("Skill ID not found")] MI004 = 004,
            [Description("Api Key not correct")] MI005 = 005,

            [Description("Unhanlde exception")] MI999 = 999
        }
        public string GetEnumDesc(errorList value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
