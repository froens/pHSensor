using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JetiAPI
{
    public abstract class JetiCommand
    {
        protected abstract string CmdStr { get; }
        protected abstract string SubCmdStr { get; }

        public bool IsQueryCommand 
        {
            get
            {
                var args = GetArgumentList();
                return Attribute.IsDefined(GetType(), typeof(QueryableCommandAttribute)) && !args.Any();
            }
        }

        public abstract string ExpectedResponse { get; }

        private IEnumerable<string> GetArgumentList()
        {
            var rtnList = new List<Tuple<int, string >>();
            var props = GetType().GetProperties();
            foreach (var propertyInfo in props.Where(x => Attribute.IsDefined(x, typeof(JetiArgumentAttribute))))
            {
                var attr = (JetiArgumentAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(JetiArgumentAttribute));
                var value = propertyInfo.GetValue(this);
                if (value != null)
                {
                    rtnList.Add(new Tuple<int, string>(attr.Order, GetPropertyStringValue(value)));
                }
            }
            return rtnList.OrderBy(x => x.Item1).Select(x => x.Item2).ToList();
        }

        public new string ToString()
        {
            var str = String.Format("*{0}", CmdStr);
            
            if (!String.IsNullOrEmpty(SubCmdStr))
            {
                str = String.Format("{0}:{1}", str, SubCmdStr);
            }
            
            var args = GetArgumentList().ToList();
            if (args.Any())
            {
                str = String.Format("{0} {1}", str, String.Join(" ", args));    
            }

            if (IsQueryCommand)
            {
                str = string.Format("{0}?", str);
            }

            return str;
        }

        private string GetPropertyStringValue(object value)
        {
            if (value == null)
            {
                return null;
            } 
            else if(value is bool)
            {
                return (bool) value ? "1" : "0";
            }
            else
            {
                return value.ToString();
            }
        }
    }


    public class QueryableCommandAttribute : Attribute
    {
    }

    public class JetiArgumentAttribute : Attribute
    {
        public int Order { get; private set; }
        private string ArgumentName { get; set; }

        public JetiArgumentAttribute(int order, string argStr)
        {
            Order = order;
            ArgumentName = argStr;
        }
    }

    public static class ArgumentStrings
    {
        public const string Tint = "tint";
        public const string Average = "";
        public const string Format = "";
        public const string Function = "";
        public const string WavelengthBegin = "";
        public const string WavelengthEnd = "";
        public const string WavelengthStep = "";
        public const string OtherArguments = "";
    }
}
