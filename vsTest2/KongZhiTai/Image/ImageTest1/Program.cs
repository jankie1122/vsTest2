using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建白色背景图
            Bitmap bmp;

            Graphics tengxunGra;

            RectangleF descRect;


            using (bmp = new Bitmap(604, 941))
            {
                tengxunGra = Graphics.FromImage(bmp);
                //将矩形填充为白色     
                tengxunGra.FillRectangle(Brushes.WhiteSmoke, new Rectangle(0, 0, 604, 941));

                //an English string and 一个中文字符串现在在这里写着作业@@##￥￥%% 
                string goodTitle = " 999999999913an English string and 一个中文字符串现在在这里写着作业@@##￥￥%%24545678787英文是你吗，不是的";

                //charNumber为要截取的每段的长度
                float charNumber = 550;
                int fontSize = 25;//商品标题字体大小

                //标识一个矩形的位置和大小
                descRect = new RectangleF();
                //设置左上角的坐标
                descRect.Location = new Point(25, 626);

                //文本格式
                Font font = new Font("黑体", fontSize, FontStyle.Bold);
                //行数=总宽度/每行宽度
                int lineCount = (int)Math.Ceiling(tengxunGra.MeasureString(goodTitle, font).Width / charNumber);
                //矩形宽度
                int juXingWidth = (int)Math.Ceiling(charNumber);
                //矩形高度
                float juXingHeightFloat = tengxunGra.MeasureString(goodTitle, font, juXingWidth, StringFormat.GenericTypographic).Height * lineCount;
                int juXingHeight = (int)Math.Ceiling(Convert.ToDouble(juXingHeightFloat));
                //矩形大小
                descRect.Size = new Size(juXingWidth, juXingHeight);
                //文本布局
                StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
                //绘制字符串图片
                tengxunGra.DrawString(goodTitle, font, Brushes.Black, descRect, sf);
                //保存图片
                bmp.Save("D:\\桌面\\图片测试\\" + DateTime.Now.ToString("yyMMddHHmmssfff") + ".jpg");

                if (tengxunGra != null)
                {
                    Console.WriteLine("tengxunGra还没释放");
                }
                else
                {
                    Console.WriteLine("tengxunGra已经释放");
                }
                if (descRect != null)
                {
                    Console.WriteLine("descRect还没释放");
                }
                else
                {
                    Console.WriteLine("descRect已经释放");
                }
            }

            if (bmp != null)
            {
                Console.WriteLine("bmp还没释放");
                bmp.Dispose();
            }
            else
            {
                Console.WriteLine("bmp已经释放");
            }
            if (tengxunGra != null)
            {
                Console.WriteLine("tengxunGra还没释放");
                tengxunGra.Dispose();
            }
            else
            {
                Console.WriteLine("tengxunGra已经释放");
            }
            if (descRect != null)
            {
                Console.WriteLine("descRect还没释放");
            }
            else
            {
                Console.WriteLine("descRect已经释放");
            }

            Console.ReadKey();

            //SizeF sizeF = tengxunGra.MeasureString(goodTitle, font);//测量长度

            //string txtDescription = "这是一段非常长的字符串";
            //RectangleF descRect = new RectangleF();
            //using (Font useFont = new Font("SimSun", 28, FontStyle.Bold))
            //{
            //    descRect.Location = new Point(30, 105);
            //    descRect.Size = new Size(600, ((int)tengxunGra.MeasureString(txtDescription, useFont,600, StringFormat.GenericTypographic).Height));
            //    tengxunGra.DrawString(txtDescription, useFont, Brushes.Black, descRect);
            //}

            //Font font = new Font("黑体", 25, FontStyle.Bold);
            //SizeF sizeF = tengxunGra.MeasureString(goodTitle, font, 500);

            //Console.WriteLine("高度：" + sizeF.Height);
            //Console.WriteLine("宽度:" + sizeF.Width);

            //string s = "an English string and 一个中文字符串";
            //Graphics g = this.CreateGraphics();
            //g.PageUnit = GraphicsUnit.Pixel;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            //StringFormat sf = new StringFormat();
            //sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

            //Font font = new Font("黑体", 25, FontStyle.Bold);
            //SizeF sizeF = g.MeasureString(s, font, 500, sf);

            //g.DrawRectangle(Pens.Red, new Rectangle(100, 400, Convert.ToInt32(sizeF.Width), Convert.ToInt32(sizeF.Height)));
            //g.DrawString(s, this.Font, new SolidBrush(Color.Green), 100, 400);

        }
    }
}
