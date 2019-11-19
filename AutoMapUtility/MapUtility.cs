using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoMapUtility
{
    public static class MapUtility
    {
        public static T Map<T>(this object obj)  where T: new()
        {
            var result = new T();
            var properties = obj.GetType().GetProperties();
                
            var resultProperties = result.GetType().GetProperties();
            foreach (var i in properties)
            {
                foreach (var j in resultProperties)
                {
                    try
                    {
                        var atts = j.GetCustomAttributes(false);
                        foreach (var item in atts)
                        {
                            if (item.GetType() == typeof(DescriptionAttribute))
                            {
                                var desName = ((DescriptionAttribute)item).Description;
                                if (i.Name == desName)
                                {
                                    var value = Convert.ChangeType(i.GetValue(obj), j.PropertyType);
                                    j.SetValue(result, value);
                                    break;
                                }
                            }
                        }
                        if (i.Name == j.Name)
                        {
                            var value = Convert.ChangeType(i.GetValue(obj),  j.PropertyType);
                            j.SetValue(result, value);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        j.SetValue(result, Activator.CreateInstance(j.PropertyType));
                        break;
                    }
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
