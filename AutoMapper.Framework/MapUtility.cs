using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper.Framework
{
    public static class MapUtility
    {
        public static T Map<T>(this object obj) where T : new()
        {
            var result = new T();
            var properties = obj.GetType().GetProperties();

            //存储源对象属性
            Dictionary<string, PropertyInfo> propertiesDic = new Dictionary<string, PropertyInfo>();
            //Dictionary<string, PropertyInfo> propertiesDic = properties.ToDictionary(f => f.Name, f => f);
            foreach (var item in properties)
            {
                propertiesDic.Add(item.Name, item);
            }

            var resultProperties = result.GetType().GetProperties();

            foreach (var j in resultProperties)
            {
                try
                {
                    ////自定义属性处理别名
                    DescriptionAttribute desc = (DescriptionAttribute)j.GetCustomAttributes(false).FirstOrDefault(f => f.GetType() == typeof(DescriptionAttribute));
                    if (desc != null)
                    {
                        var desName = desc.Description;
                        if (propertiesDic.ContainsKey(desName))
                        {
                            j.SetValue(result, propertiesDic[desName].GetValue(obj));
                            continue;
                        }
                    }
                    else
                    {
                        if (propertiesDic.ContainsKey(j.Name))
                        {
                            j.SetValue(result, propertiesDic[j.Name].GetValue(obj));
                        }
                    }
                }
                catch (System.Exception)
                {
                    j.SetValue(result, Activator.CreateInstance(j.PropertyType));
                }
            }
            return result;
        }

        public static IList<TOut> MapList<TIn, TOut>(this List<TIn> list) where TOut : new()
        {
            var result = new List<TOut>();
            foreach (var item in list)
            {
                try
                {
                    result.Add(item.Map<TOut>());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }
    }
}
