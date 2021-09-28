using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
namespace RectTestClass
{
    public partial class Form2 : Form
    {
        Graphics gg;
        int NumX = 9;
        int NumY = 10;
        int Num = 90;
        SuperRect[] demoArr = new SuperRect[100];
        public Form2()
        {
            InitializeComponent();
            
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            gg = this.CreateGraphics();

            //this.ShowWarningTip("warn");
            //this.ShowErrorTip("initing");
            //this.ShowInfoNotifier("notify");
            if (LogIForm())
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
        private bool LogIForm()
        {
            UILoginForm frm = new UILoginForm();
            frm.ShowInTaskbar = true;
            frm.Text = "Login";
            frm.Title = "SuperRect Login Form";
            frm.SubText = new Version(10,1).ToString();
            frm.OnLogin += Frm_OnLogin;
            frm.LoginImage = UILoginForm.UILoginImage.Login6;
            frm.ShowDialog();
            if (frm.IsLogin)
            {
                //UIMessageTip.ShowOk("登录成功");
                frm.ShowInfoNotifier("登录成功");
                frm.Hide();
                return true;
            }
            else
            {
                frm.ShowErrorNotifier("取消登录");
                return false;
            }
            
        }
        private bool Frm_OnLogin(string userName, string password)
        {
            //在此处校验
            
            return userName == "admin" && password == "1";
        }
        /// <summary>
        /// 画出初始状态的rect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawInitRect(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < NumX; i++)
            {
                for (int j = 0; j < NumY; j++)
                {
                    demoArr[10 * i + j] = new SuperRect(i, new int[] { i, j }, 50 + (50 + 10) * j, 60 + (50 + 10) * i, "" + (10 * i + j).ToString(), gg);
                    demoArr[10 * i + j].DrawSuperRect();
                }
            }
        }
        private void DrawInitRect()
        {
            for (int i = 0; i < NumX; i++)
            {
                for (int j = 0; j < NumY; j++)
                {
                    demoArr[10 * i + j] = new SuperRect(i, new int[] { i, j }, 50 + (50 + 10) * j, 60 + (50 + 10) * i, "" + (10 * i + j).ToString(), gg);
                    demoArr[10 * i + j].DrawSuperRect();
                }
            }
        }
        /// <summary>
        /// clicked 只会把点选的值传递出来，本身并不会重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            //SolidBrush Clickedbrush = new SolidBrush(Color.Blue);
            
            for (int i = 0; i < Num; i++)
            {
                if (demoArr[i]!=null&&demoArr[i].Contains(e.X, e.Y))
                {
                    logrtx2.AppendText(i + "choosed!" + '\n');
                    //var sg2 = RectGroup.CreateGraphics();
                    demoArr[i].ChangeColor(Color.Red, gg);
                    break;
                }
            }
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
                    demoArr[i].ChangeColor(Color.Black, gg);
                    logrtx2.AppendText(i + "double choosed!" + '\n');
                    break;
                }
            }
            //this.Refresh();
            logrtx2.AppendText("doubleclicked!" + '\n');
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
            gg.FillRectangle(new SolidBrush(Color.Red), demorect);
            //this.Refresh();
        }
        private void Init()
        {
            DrawInitRect();
        }
        int ii = 0;
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //Init();
            //logrtx2.AppendText("refreshed:" + ii++ + "\n");
            
        }
        private void logrtx2_TextChanged(object sender, EventArgs e)
        {
            logrtx2.SelectionStart = logrtx2.Text.Length;
            logrtx2.ScrollToCaret();
        }
        private void Form2_Activated(object sender, EventArgs e)
        {
         
        }

       

        private void Form2_Shown(object sender, EventArgs e)
        {
            //Init();
            gg.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(10, 10), new Size(30, 30)));
            Init();
            //this.Refresh();
        }
    }
}
