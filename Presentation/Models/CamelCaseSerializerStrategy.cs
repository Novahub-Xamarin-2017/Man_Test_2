using SimpleJson;

namespace Presentation.Models
{
    public class CamelCaseSerializerStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            return clrPropertyName[0].ToString().ToLower() + clrPropertyName.Substring(1);
        }
    }
}