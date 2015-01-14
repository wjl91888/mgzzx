using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace RICH.Common
{
    /// <summary>
    /// Summary description for GenerateImage
    /// </summary>
    public class GenerateImage
    {
        //***************************************************** 
        //  Function Name:  GetStringImage
        /// <summary>
        /// 生成验证码图片数据
        /// </summary>
        /// <returns>
        /// 验证码图片数据内存二进制数据流
        /// </returns>
        //******************************************************
        public static MemoryStream GetStringImage(string strIdenteifyCode, int intWidth, int intHeight, int intFontSize, int intFontSpace,float sngNoseRate)
        {
            Random rand = new Random();
            //根据字符长度自动更改图片宽度和高度
            Bitmap bmpReturn = new Bitmap(intWidth, intHeight);
            Graphics graphics = Graphics.FromImage(bmpReturn);
            //绘制与图像大小相同的填充矩形
            graphics.FillRectangle((new SolidBrush(Color.WhiteSmoke)), 0, 0, intWidth, intHeight);
            //根据噪声比例生成噪声数量
            int intNoseNumber = Convert.ToInt16(intWidth * intHeight * sngNoseRate);
            for (int i = 0; i < intNoseNumber; i++)
            {
                int intPointX = Convert.ToInt16(rand.NextDouble() * intWidth);
                int intPointY = Convert.ToInt16(rand.NextDouble() * intHeight);
                graphics.DrawLine((new Pen(new SolidBrush(Color.Black))), intPointX, intPointY, intPointX + 1, intPointY + 1);
            }
            //在矩形内绘制字串（字串，字体，画笔颜色，左上x.左上y）
            for (int i = 0; i < strIdenteifyCode.Length; i++)
            {
                int intColorR = Convert.ToInt16(rand.NextDouble() * 125);
                int intColorG = Convert.ToInt16(rand.NextDouble() * 125);
                int intColorB = Convert.ToInt16(rand.NextDouble() * 125);
                //intPointX = Convert.ToInt16(rand.NextDouble() * intWidth);
                //intPointY = Convert.ToInt16(rand.NextDouble() * intHeight/5);
                int intPointY = intHeight/3;
                graphics.DrawString(strIdenteifyCode[i].ToString(), (new Font("Arial", intFontSize, FontStyle.Bold)), (new SolidBrush(Color.FromArgb(intColorR, intColorG, intColorB))), intFontSpace * i + intFontSize * i, intPointY);
                //graphics.DrawString(strIdenteifyCode[i].ToString(), (new Font("Arial", intFontSize, FontStyle.Bold)), (new SolidBrush(Color.Black)), 5 + intFontSize * i, intPointY);
            }
            MemoryStream memoryStream = new MemoryStream();
            bmpReturn.Save(memoryStream, ImageFormat.Png);
            graphics.Dispose();
            bmpReturn.Dispose();
            return memoryStream;
        }
    }
}
