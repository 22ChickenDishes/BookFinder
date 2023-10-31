using BookFinder.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Servers
{
    public static class IOCContainer
    {
        private static readonly Dictionary<Type, object> ExampleContianerDictionary = new Dictionary<Type, object>();

        public static T GetSingleton<T>()
        {
            if (ExampleContianerDictionary.ContainsKey(typeof(T)))
            {
                return (T)ExampleContianerDictionary[typeof(T)];
            }
            else
            {
                object o = CreateObject(typeof(T));
                ExampleContianerDictionary.Add(typeof(T), o);
                return (T)o;
            }
        }

        public static void AddSingleton(object o)
        {
            ExampleContianerDictionary.Add(o.GetType(), o);
        }

        public static object CreateObject(Type type)
        {
            try
            {
                //获取构造函数
                ConstructorInfo[] cons = type.GetConstructors();

                List<object> paraList = new List<object>();

                //如果构造函数数量大于0
                if (cons.Count() > 0)
                {
                    //选择参数数量最多的构造函数
                    ConstructorInfo con = cons.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
                    foreach (ParameterInfo para in con.GetParameters())
                    {
                        Type paraType = para.ParameterType;
                        //字典容器查询出具体的参数对象类型
                        Type targetType = type;
                        //递归实例化所有参数对象，以及其依赖的对象，并添加到数组中
                        paraList.Add(CreateObject(targetType));
                    }
                }

                //返回对象
                return Activator.CreateInstance(type, paraList.ToArray());
            }
            catch
            {
                return null;
            }
        }

        public static void LoadAssmaly(string asmName)
        {
            Assembly assembly = Assembly.Load(asmName);
        
            Type[] types = assembly.GetTypes();//注意这里获取的是程序集中的所有定义的类型

            // 筛选出含有IOcServiceAttribute特性标签的类，存储其type类型
            foreach (Type type in types)
            {
                IocAttribute iOCService = type.GetCustomAttribute(typeof(IocAttribute)) as IocAttribute;//获取类上的自定义的特性标签
                if (iOCService != null)//如果是IOCServiceAttribute标注类，则把其类型存入类型容器中
                {
                    ExampleContianerDictionary.Add(type, CreateObject(type));
                }
            }

        }
    }
}
