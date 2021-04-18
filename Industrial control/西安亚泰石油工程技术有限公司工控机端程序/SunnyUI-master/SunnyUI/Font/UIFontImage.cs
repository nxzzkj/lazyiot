/******************************************************************************
 * SunnyUI ��Դ�ؼ��⡢������⡢��չ��⡢��ҳ�濪����ܡ�
 * CopyRight (C) 2012-2020 ShenYongHua(������).
 * QQȺ��56829229 QQ��17612584 EMail��SunnyUI@qq.com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * �����ʹ�ô˴��룬�뱣����˵����
 ******************************************************************************
 * �ļ�����: UFontImage.cs
 * �ļ�˵��: ����ͼƬ������
 * ��ǰ�汾: V2.2
 * ��������: 2020-01-01
 *
 * 2020-01-01: V2.2.0 �����ļ�˵��
 * 2020-05-21: V2.2.5 ��������Դ�ļ��м������壬�������Ϊ�ļ���
 *                    ��л����Ǳ� https://gitee.com/maikebing
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace Sunny.UI
{
    /// <summary>
    /// ����ͼƬ������
    /// </summary>
    public static class FontImageHelper
    {
        /// <summary>
        /// AwesomeFont
        /// </summary>
        public static FontImages AwesomeFont;

        /// <summary>
        /// ElegantFont
        /// </summary>
        public static FontImages ElegantFont;

        /// <summary>
        /// ���캯��
        /// </summary>
        static FontImageHelper()
        {
            AwesomeFont = new FontImages(ReadFontFileFromResource("Sunny.UI.Font.FontAwesome.ttf"));
            ElegantFont = new FontImages(ReadFontFileFromResource("Sunny.UI.Font.ElegantIcons.ttf"));
        }

        /// <summary>
        /// ��ϵͳ��Դ�б��������ļ�
        /// </summary>
        /// <param name="file">�����ļ���</param>
        /// <param name="resource">��Դ����</param>
        private static void CreateFontFile(string file, string resource)
        {
            if (!File.Exists(file))
            {
                Stream fontStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
                if (fontStream != null)
                {
                    byte[] buffer = new byte[fontStream.Length];
                    fontStream.Read(buffer, 0, (int)fontStream.Length);
                    fontStream.Close();

                    File.WriteAllBytes(file, buffer);
                }
            }
        }

        private static byte[] ReadFontFileFromResource(string name)
        {
            byte[] buffer = null;
            Stream fontStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            if (fontStream != null)
            {
                buffer = new byte[fontStream.Length];
                fontStream.Read(buffer, 0, (int)fontStream.Length);
                fontStream.Close();
            }
            return buffer;
        }

        /// <summary>
        /// ��ȡ�����С
        /// </summary>
        /// <param name="graphics">GDI��ͼ</param>
        /// <param name="symbol">�ַ�</param>
        /// <param name="symbolSize">��С</param>
        /// <returns>�����С</returns>
        public static SizeF GetFontImageSize(this Graphics graphics, int symbol, int symbolSize)
        {
            Font font = GetFont(symbol, symbolSize);
            if (font == null)
            {
                return new SizeF(0, 0);
            }

            return graphics.MeasureString(char.ConvertFromUtf32(symbol), font);
        }

        /// <summary>
        /// ��������ͼƬ
        /// </summary>
        /// <param name="graphics">GDI��ͼ</param>
        /// <param name="symbol">�ַ�</param>
        /// <param name="symbolSize">��С</param>
        /// <param name="color">��ɫ</param>
        /// <param name="left">��</param>
        /// <param name="top">��</param>
        /// <param name="xOffset">����ƫ��</param>
        /// <param name="yOffSet">����ƫ��</param>
        public static void DrawFontImage(this Graphics graphics, int symbol, int symbolSize, Color color, float left, float top, int xOffset = 0, int yOffSet = 0)
        {
            //����
            Font font = GetFont(symbol, symbolSize);
            if (font == null)
            {
                return;
            }

            string text = char.ConvertFromUtf32(symbol);
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, color, left + xOffset, top + yOffSet);
            graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
        }

        /// <summary>
        /// ��������ͼƬ
        /// </summary>
        /// <param name="graphics">GDI��ͼ</param>
        /// <param name="symbol">�ַ�</param>
        /// <param name="symbolSize">��С</param>
        /// <param name="color">��ɫ</param>
        /// <param name="rect">����</param>
        /// <param name="xOffset">����ƫ��</param>
        /// <param name="yOffSet">����ƫ��</param>
        public static void DrawFontImage(this Graphics graphics, int symbol, int symbolSize, Color color, Rectangle rect, int xOffset = 0, int yOffSet = 0)
        {
            SizeF sf = graphics.GetFontImageSize(symbol, symbolSize);
            graphics.DrawFontImage(symbol, symbolSize, color, rect.Left + ((rect.Width - sf.Width) / 2.0f).RoundEx(),
                rect.Top + ((rect.Height - sf.Height) / 2.0f).RoundEx(), xOffset, yOffSet);
        }

        /// <summary>
        /// ��������ͼƬ
        /// </summary>
        /// <param name="graphics">GDI��ͼ</param>
        /// <param name="symbol">�ַ�</param>
        /// <param name="symbolSize">��С</param>
        /// <param name="color">��ɫ</param>
        /// <param name="rect">����</param>
        /// <param name="xOffset">����ƫ��</param>
        /// <param name="yOffSet">����ƫ��</param>
        public static void DrawFontImage(this Graphics graphics, int symbol, int symbolSize, Color color, RectangleF rect, int xOffset = 0, int yOffSet = 0)
        {
            SizeF sf = graphics.GetFontImageSize(symbol, symbolSize);
            graphics.DrawFontImage(symbol, symbolSize, color, rect.Left + ((rect.Width - sf.Width) / 2.0f).RoundEx(),
                rect.Top + ((rect.Height - sf.Height) / 2.0f).RoundEx(), xOffset, yOffSet);
        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        /// <param name="symbol">�ַ�</param>
        /// <param name="size">��С</param>
        /// <param name="color">��ɫ</param>
        /// <returns>ͼƬ</returns>
        public static Image CreateImage(int symbol, int size, Color color)
        {
            Bitmap image = new Bitmap(size, size);

            using (Graphics g = image.Graphics())
            {
                SizeF sf = g.GetFontImageSize(symbol, size);
                g.DrawFontImage(symbol, size, color, (image.Width - sf.Width) / 2.0f, (image.Height - sf.Height) / 2.0f);
            }

            return image;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="symbol">�ַ�</param>
        /// <param name="imageSize">��С</param>
        /// <returns>����</returns>
        public static Font GetFont(int symbol, int imageSize)
        {
            if (symbol > 0xF000)
                return AwesomeFont.GetFont(symbol, imageSize);
            else
                return ElegantFont.GetFont(symbol, imageSize);
        }
    }

    /// <summary>
    /// ����ͼ��ͼƬ
    /// </summary>
    public class FontImages
    {
        private readonly PrivateFontCollection ImageFont;
        private readonly Dictionary<int, Font> Fonts = new Dictionary<int, Font>();
        private const int MinFontSize = 8;
        private const int MaxFontSize = 43;
        private readonly IntPtr memoryFont = IntPtr.Zero;

        /// <summary>
        /// ��С
        /// </summary>
        public int IconSize { get; set; } = 128;

        /// <summary>
        /// ����ɫ
        /// </summary>
        public Color BackColor { get; set; } = Color.Transparent;

        /// <summary>
        /// ǰ��ɫ
        /// </summary>
        public Color ForeColor { get; set; } = Color.Black;

        public FontImages(byte[] buffer)
        {
            ImageFont = new PrivateFontCollection();
            memoryFont = Marshal.AllocCoTaskMem(buffer.Length);
            Marshal.Copy(buffer, 0, memoryFont, buffer.Length);
            ImageFont.AddMemoryFont(memoryFont, buffer.Length);
            Loaded = true;
            LoadDictionary();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="filename">�����ļ���</param>
        public FontImages(string filename)
        {
            if (File.Exists(filename))
            {
                ImageFont = new PrivateFontCollection();
                ImageFont.AddFontFile(filename);
                Loaded = true;
                LoadDictionary();
            }
        }

        /// <summary>
        /// ���������ɱ�־
        /// </summary>
        public bool Loaded { get; }

        private void LoadDictionary()
        {
            int size = MinFontSize;
            for (int i = 0; i <= MaxFontSize - MinFontSize; i++)
            {
                Fonts.Add(size, GetFont(size));
                size += 1;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        ~FontImages()
        {
            foreach (var font in Fonts.Values)
            {
                font.Dispose();
            }

            if (memoryFont != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(memoryFont);
            }

            Fonts.Clear();
        }

        /// <summary>
        /// ��ȡͼ��
        /// </summary>
        /// <param name="iconText">���</param>
        /// <param name="imageSize">ͼ���С</param>
        /// <returns>ͼ��</returns>
        public Icon GetIcon(int iconText, int imageSize)
        {
            Bitmap image = GetImage(iconText, imageSize);
            return image != null ? ToIcon(image, IconSize) : null;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="iconText">ͼ��</param>
        /// <param name="imageSize">ͼ���С</param>
        /// <returns>����</returns>
        public Font GetFont(int iconText, int imageSize)
        {
            int item = GetFontSize(iconText, imageSize);
            if (Fonts.ContainsKey(item))
            {
                return Fonts[GetFontSize(iconText, imageSize)];
            }

            return null;
        }

        /// <summary>
        /// ��ȡ�����С
        /// </summary>
        /// <param name="iconText">ͼ��</param>
        /// <param name="imageSize">ͼ���С</param>
        /// <returns>�����С</returns>
        public int GetFontSize(int iconText, int imageSize)
        {
            int size = MaxFontSize;
            int interval = MaxFontSize - MinFontSize;
            using (Bitmap bitmap = new Bitmap(48, 48))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i <= interval; i++)
                {
                    Font font = Fonts[size];
                    SizeF sf = GetIconSize(iconText, graphics, font);

                    if (sf.Width < imageSize && sf.Height < imageSize)
                    {
                        break;
                    }

                    size -= 1;
                }
            }

            return size;
        }

        /// <summary>
        /// ��ȡͼƬ
        /// </summary>
        /// <param name="iconText">ͼ��</param>
        /// <param name="imageSize">ͼ���С</param>
        /// <returns>ͼƬ</returns>
        public Bitmap GetImage(int iconText, int imageSize)
        {
            Font imageFont = Fonts[MinFontSize];
            SizeF textSize = new SizeF(imageSize, imageSize);
            using (Bitmap bitmap = new Bitmap(48, 48))
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                int size = MaxFontSize;
                for (int i = 0; i <= MaxFontSize - MinFontSize; i++)
                {
                    Font font = Fonts[size];
                    SizeF sf = GetIconSize(iconText, graphics, font);

                    if (sf.Width < imageSize && sf.Height < imageSize)
                    {
                        imageFont = font;
                        textSize = sf;
                        break;
                    }

                    size -= 1;
                }
            }

            Size iconSize = textSize.ToSize();
            Bitmap srcImage = new Bitmap(iconSize.Width, iconSize.Height);
            using (Graphics graphics = Graphics.FromImage(srcImage))
            {
                string s = char.ConvertFromUtf32(iconText);
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                //graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawString(s, imageFont, ForeColor, new PointF(0.0f, 0.0f));
                graphics.TextRenderingHint = TextRenderingHint.SystemDefault;
                graphics.InterpolationMode = InterpolationMode.Default;
            }

            Bitmap result = new Bitmap(imageSize, imageSize);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImage(srcImage, imageSize / 2.0f - textSize.Width / 2.0f, imageSize / 2.0f - textSize.Height / 2.0f);
            }

            srcImage.Dispose();
            return result;
        }

        private Size GetIconSize(int iconText, Graphics graphics, Font font)
        {
            string text = char.ConvertFromUtf32(iconText);
            return graphics.MeasureString(text, font).ToSize();
        }

        private Icon ToIcon(Bitmap srcBitmap, int size)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException(nameof(srcBitmap));
            }

            Icon icon;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                new Bitmap(srcBitmap, new Size(size, size)).Save(memoryStream, ImageFormat.Png);
                Stream stream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(stream);
                if (stream.Length <= 0L)
                {
                    return null;
                }

                binaryWriter.Write((byte)0);
                binaryWriter.Write((byte)0);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1);
                binaryWriter.Write((byte)size);
                binaryWriter.Write((byte)size);
                binaryWriter.Write((byte)0);
                binaryWriter.Write((byte)0);
                binaryWriter.Write((short)0);
                binaryWriter.Write((short)32);
                binaryWriter.Write((int)memoryStream.Length);
                binaryWriter.Write(22);
                binaryWriter.Write(memoryStream.ToArray());
                binaryWriter.Flush();
                binaryWriter.Seek(0, SeekOrigin.Begin);
                icon = new Icon(stream);
                stream.Dispose();
            }

            return icon;
        }

        private Font GetFont(float size)
        {
            return Loaded ? new Font(ImageFont.Families[0], size, FontStyle.Regular, GraphicsUnit.Point) : null;
        }
    }
}