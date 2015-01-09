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
        /// ������֤��ͼƬ����
        /// </summary>
        /// <returns>
        /// ��֤��ͼƬ�����ڴ������������
        /// </returns>
        //******************************************************
        public static MemoryStream GetStringImage(string strIdenteifyCode, int intWidth, int intHeight, int intFontSize, int intFontSpace,float sngNoseRate)
        {
            Random rand = new Random();
            //�����ַ������Զ�����ͼƬ��Ⱥ͸߶�
            Bitmap bmpReturn = new Bitmap(intWidth, intHeight);
            Graphics graphics = Graphics.FromImage(bmpReturn);
            //������ͼ���С��ͬ��������
            graphics.FillRectangle((new SolidBrush(Color.WhiteSmoke)), 0, 0, intWidth, intHeight);
            //������������������������
            int intNoseNumber = Convert.ToInt16(intWidth * intHeight * sngNoseRate);
            for (int i = 0; i < intNoseNumber; i++)
            {
                int intPointX = Convert.ToInt16(rand.NextDouble() * intWidth);
                int intPointY = Convert.ToInt16(rand.NextDouble() * intHeight);
                graphics.DrawLine((new Pen(new SolidBrush(Color.Black))), intPointX, intPointY, intPointX + 1, intPointY + 1);
            }
            //�ھ����ڻ����ִ����ִ������壬������ɫ������x.����y��
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
