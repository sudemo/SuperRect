using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RectTestClass
{
    public partial class Form1 : Form
    {
        Graphics gg;
        int NumX = 9;
        int NumY = 10;
        int Num = 90;
        SuperRect[] demoArr = new SuperRect[100];
        int? gSelectedIndex = null;
        int doubleSelectedIndex = 999; //直接添加到dict里面
        /// <summary>
        /// 这个dict,键值为rect索引号，值为true代表被单击了，目前没有false的情况，false的键直接被删除。
        /// 缓存修改
        /// </summary>
        Dictionary<int, bool> RectClickColorCache = new Dictionary<int, bool>();
        //Dictionary<int, bool> RectDoubleColorCache = new Dictionary<int, bool>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initEvent();
            gg = this.CreateGraphics();
        }
        private void initEvent()
        {
            this.MouseClick += new MouseEventHandler(OnMouseDown);
            this.MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
        }
        /// <summary>
        /// 画出初始状态的rect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawInitRect(object sender, PaintEventArgs e)
        {
            //SuperRect demo1 = new SuperRect(0, new int[] { 0, 0 }, 0, 10, "", e);
            //List<SuperRect> demolist = new List<SuperRect>();
            //SuperRect demo = null;
            Stopwatch st = new Stopwatch();
            SolidBrush Clickedbrush = new SolidBrush(Color.Blue);
            //st.Start();
            //此处 i是行，j是列
            for (int i = 0; i < NumX; i++)
            {
                for (int j = 0; j < NumY; j++)
                {
                    demoArr[10 * i + j] = new SuperRect(i, new int[] { i, j }, 50 + (50 + 10) * j, 60 + (50 + 10) * i, "" + (10 * i + j).ToString(), e);
                    demoArr[10 * i + j].DrawSuperRect();
                }
            }
            //st.Stop();
            //foreach (var index in RectClickColorCache.Keys)//这里面有的就是被单击的
            //{
            //    demoArr[index].DrawSuperRect(Clickedbrush);
            //}
            #region MyRegion
            //if (gSelectedIndex != null)
            //{
            //    SolidBrush brush = new SolidBrush(Color.Blue);
            //    int a = (int)gSelectedIndex;
            //    demoArr[a].DrawSuperRect(brush);
            //}
            //if (doubleSelectedIndex != 999)
            //{
            //    SolidBrush brush = new SolidBrush(Color.White);
            //    int a = doubleSelectedIndex;
            //    demoArr[a].DrawSuperRect(brush);
            //} 
            #endregion
        }
        /// <summary>
        /// clicked 只会把点选的值传递出来，本身并不会重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            SolidBrush Clickedbrush = new SolidBrush(Color.Blue);
            for (int i = 0; i < Num; i++)
            {
                if (demoArr[i].Contains(e.X, e.Y))
                {
                    //当在字典中不能确定是否存在该键时需要使用TryGetValue，
                    //以减少一次不必要的查找，同时避免了判断Key值是否存在而引发的“给定关键字不在字典中。”的错误
                    //if (!RectClickColorCache.ContainsKey(i))
                    if (!RectClickColorCache.TryGetValue(i, out bool res))
                    {
                        RectClickColorCache.Add(i, true);
                        richTextBox1.AppendText(i + "single added!" + '\n');
                    }
                    gSelectedIndex = i;
                    richTextBox1.AppendText(i + "choosed!" + '\n');
                    var sg2 = this.CreateGraphics();
                    demoArr[(int)gSelectedIndex].ChangeColor(Color.Red, sg2);
                    break;
                }
            }
            //this.Refresh();
            
            //foreach (var index in RectClickColorCache.Keys)//这里面有的就是被单击的
            //{
            //    demoArr[index].DrawSuperRect(Clickedbrush);
            //}
            //this.Invalidate();
        }
        /// <summary>
        /// 双击可以换成其他颜色，或者是删除恢复其原本颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < Num; i++)
            {
                if (demoArr[i].Contains(e.X, e.Y))
                {
                    //if (!RectDoubleColorCache.ContainsKey(i))
                    //if (RectClickColorCache.ContainsKey(i))
                    if (RectClickColorCache.TryGetValue(i, out bool res))
                    {
                        RectClickColorCache.Remove(i);
                        richTextBox1.AppendText(i + "double added!" + '\n');
                    }
                    doubleSelectedIndex = i;
                    richTextBox1.AppendText(i + "double choosed!" + '\n');
                    break;
                }
            }
            this.Invalidate();
            richTextBox1.AppendText("doubleclicked!" + '\n');
        }
        int ii = 0;
        /// <summary>
        /// 画出矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawInitRect(sender, e);
            richTextBox1.AppendText("refreshed:" + ii++ + "\n");
            //DrawCacheRect(sender, e);
        }
        /// <summary>
        /// 画出修改后的rect
        /// </summary>
        private void DrawCacheRect(object sender, PaintEventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Blue);
            //demoArr[0].DrawSuperRect(brush);
            Rectangle demorect = new Rectangle(10, 10, 100, 100);
            //demorect.X = demoArr[0].X; demorect.Y = demoArr[0].Y;demorect.Width = demorect.Height = 50;
            Brush ss = new SolidBrush(Color.Blue);
            gg.FillRectangle(ss, demorect);
            gg.FillRectangle(new SolidBrush(Color.Red),demorect);
            //this.Refresh();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
