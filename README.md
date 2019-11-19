# AutoMapUtility
实体属性自动映射,支持对象间属性值复制和List复制  
Install-Package AutoMapUtility -Version 1.0.2
```
//定义实体，可通过Description指定映射的属性
public class T
    {
        public int a { get; set; }
        public int b { get; set; }

    }

    public class T2
    {
        public string a { get; set; }
        [Description("b")]
        public int bb { get; set; }

    }
//使用
var t = new T { a = 1, b = 2 };
var t2 = t.Map<T2>();
Console.WriteLine(JsonConvert.SerializeObject(t2));

var list1 = new List<T> { new T{a=1,b=2},new T { a = 3, b = 4 } };
IList<T2> list2 = list1.MapList<T, T2>();
Console.WriteLine(JsonConvert.SerializeObject(list2));\
```
