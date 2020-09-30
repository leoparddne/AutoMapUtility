# AutoMapUtility
将实体属性自动映射到另一个对象中,支持对象间属性值复制和List复制  
默认使用同名复制的方法，也可以通过添加Description来映射对象，
即默认是将A对象的Name复制给B对象的Name，此时希望将A.Name复制给
B.OldName,便可对B.OldName添加[Description("Name")]的别名即可
  
使用方法
1. 安装(使用nuget方式或者复制整个项目)
Install-Package AutoMapUtility -Version 1.0.2
2. 定义实体类
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

```
3. 使用方式
```
var t = new T { a = 1, b = 2 };
var t2 = t.Map<T2>();
Console.WriteLine(JsonConvert.SerializeObject(t2));

var list1 = new List<T> { new T{a=1,b=2},new T { a = 3, b = 4 } };
IList<T2> list2 = list1.MapList<T, T2>();
Console.WriteLine(JsonConvert.SerializeObject(list2));
```
