using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖注入
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    /// <summary>
    /// 假设，现在程序需要一个获取不同时间格式的的当前时间。 
    ///我们定义一个接口ITimeProvider。
    /// </summary>
    public interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }


    //ITimeProvider的不同实现，提供不同的时间格式。

    public class SystemTimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }

    public class UtcNowTimeProvider : ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.UtcNow; } }
    }

    //需要一个装配工Assembler将所需的类型名称和实体类型一一对应
    public class Assembler
    {
        /// <summary>
        /// 保存“类型名称/实体类型”对应关系的字典
        /// </summary>
        private static Dictionary<string, Type> dictionary = new Dictionary<string, Type>();

        static Assembler()
        {
            dictionary.Add("SystemTimeProvider", typeof(SystemTimeProvider));
            dictionary.Add("UtcNowTimeProvider", typeof(UtcNowTimeProvider));
        }

        static void RegisterType(string name, Type type)
        {
            if (type == null || dictionary.ContainsKey(name))
            {
                throw new NullReferenceException();
            }
            dictionary.Add(name, type);
        }

        static void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NullReferenceException();
            }
            dictionary.Remove(name);
        }

        public ITimeProvider Create(string type)
        {
            if ((type == null) || !dictionary.ContainsKey(type))
            {
                throw new NullReferenceException();
            }
            Type targetType = dictionary[type];
            return (ITimeProvider)Activator.CreateInstance(targetType);
        }

        //此时出现一个问题，程序如何获取所需的时间格式的实现类呢？通过注入的方式。 
        //注入的方式有以下几种。

        //构造函数（Constructor）注入
        //构造函数注入，顾名思义，就是在构造函数的时候，通过Assembler或其它机制把抽象类型作为返回给所需的程序。

        /// <summary>
        /// 在构造函数中注入
        /// </summary>
        class Client
        {
            private ITimeProvider timeProvider;

            public Client(ITimeProvider timeProvider)
            {
                this.timeProvider = timeProvider;
            }
        }

        class ConstructorInjectionTest
        {
            public static void Test()
            {
                ITimeProvider timeProvider = (new Assembler()).Create("SystemTimeProvider");
                Client client = new Client(timeProvider);//在构造函数中注入
            }
        }
    }
}
