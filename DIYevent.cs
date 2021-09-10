
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    /// <summary>
    /// 发布事件类
    /// </summary>
    public class TestEventSource
    {
        /// <summary>
        /// 定义事件参数类
        /// </summary>
        public class TestEventArgs : EventArgs
        {
            public readonly char KeyToRaiseEvent;
            public TestEventArgs(char keyToRaiseEvent)
            {
                KeyToRaiseEvent = keyToRaiseEvent;
            }
        }

        ///定义一个委托
        public delegate void TestEventHandler(object sender, TestEventArgs e);
        ///用event关键字声明事件对象
        public event TestEventHandler TestEvent;

        //事件触发的方法
        protected void OnTestEvent(TestEventArgs e)
        {
            if (TestEvent != null)
            {
                TestEvent(this, e);
            }
        }

        //引发事件的方法
        public void RaiseEvent(char keyToRaiseEvent)
        {
            TestEventArgs e = new TestEventArgs(keyToRaiseEvent);
            OnTestEvent(e);
        }
    }

    //监听事件类
    public class TestEventListener
    {
        //定义本地处理事件的方法，他与声明事件的delegate具有相同的参数和返回值类型 
        public void KeyPressed(object sender, TestEventSource.TestEventArgs e)
        {
            Console.WriteLine("发送者：{0}，所按得健为：{1}", sender, e.KeyToRaiseEvent);
        }

        //订阅事件 
        public void Subscribe(TestEventSource evenSource)
        {
            evenSource.TestEvent += new TestEventSource.TestEventHandler(KeyPressed);
        }

        //取消订阅事件 
        public void UnSubscribe(TestEventSource evenSource)
        {
            evenSource.TestEvent -= new TestEventSource.TestEventHandler(KeyPressed);
        }

    }

    class Program
    {
        static void Main2(string[] args)
        {
            ///创建事件源对象
            TestEventSource es = new TestEventSource();

            ///创建监听对象
            TestEventListener el = new TestEventListener();

            ///订阅事件
            Console.WriteLine("订阅事件\t");
            el.Subscribe(es);

            ///引发事件
            Console.WriteLine("输入一个字符，再按enter键");
            string str = Console.ReadLine();
            es.RaiseEvent(str.ToCharArray()[0]);

            //取消订阅事件 
            Console.WriteLine("\n取消订阅事件\n");
            el.UnSubscribe(es);


            //引发事件 
            Console.WriteLine("输入一个字符，再按enter健");
            str = Console.ReadLine();
            es.RaiseEvent(str.ToCharArray()[0]);
            Console.ReadLine();

        }
    }
}