using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace RICH.Common
{
    /// <summary>
    /// Summary description for IdentifyCodeLibrary
    /// </summary>
    public class IdentifyCodeLibrary
    {
        //***************************************************** 
        //  Function Name:  GetIdentifyCode
        /// <summary>
        /// �õ����������֤���ַ���
        /// </summary>
        /// <param name="intLength">������֤���ַ���</param>
        /// <param name="intType">������֤������</param>
        /// <returns>
        /// ���ɵ���֤���ַ���
        /// </returns>
        //******************************************************
        public static string GetIdentifyCode(int intLength, int intType)
        {
            //char[] arrIdentifyCodeChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] arrIdentifyCodeChar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            string strReturn = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < intLength; i++)
            {
                strReturn = strReturn + arrIdentifyCodeChar[Convert.ToInt32((rand.NextDouble() * (arrIdentifyCodeChar.Length-1)))];
            }
            return strReturn;
        }

        //***************************************************** 
        //  Function Name:  GetIdentifyCodeImage
        /// <summary>
        /// ������֤��ͼƬ����
        /// </summary>
        /// <returns>
        /// ��֤��ͼƬ�����ڴ������������
        /// </returns>
        //******************************************************
        public static MemoryStream GetIdentifyCodeImage(string strIdenteifyCode)
        {
            const float sngNoseRate = ConstantsManager.IDENTIFY_CODE_NOISE_RATE;
            const int intFontSize = ConstantsManager.IDENTIFY_CODE_FONTSIZE;
            Random rand = new Random();
            //�����ַ������Զ�����ͼƬ��Ⱥ͸߶�
            int intWidth = Convert.ToInt32(strIdenteifyCode.Length * (intFontSize + 1.2));
            const int intHeight = intFontSize * 2-4;
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
                int intPointY = Convert.ToInt16(rand.NextDouble() * intHeight/5);
                graphics.DrawString(strIdenteifyCode[i].ToString(), (new Font("Arial", intFontSize, FontStyle.Bold)), (new SolidBrush(Color.FromArgb(intColorR, intColorG, intColorB))), 3 + intFontSize * i, intPointY);
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
