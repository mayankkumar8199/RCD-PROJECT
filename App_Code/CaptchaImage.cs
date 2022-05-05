using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace CaptchaImage
{
    /// <summary>
    /// Summary description for CaptchaImage.
    /// </summary>
    public class CaptchaImage
    {
        // Public properties (all read-only).
        public string Text
        {
            get { return this.text; }
        }
        public Bitmap Image
        {
            get { return this.image; }
        }
        public int Width
        {
            get { return this.width; }
        }
        public int Height
        {
            get { return this.height; }
        }

        // Internal properties.
        private string text;
        private int width;
        private int height;
        private string familyName;
        private Bitmap image;

        // For generating random numbers.
        private Random random = new Random();

        // ====================================================================
        // Initializes a new instance of the CaptchaImage class using the
        // specified text, width and height.
        // ====================================================================
        public CaptchaImage(string s, int width, int height)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.GenerateImage();
        }

        // ====================================================================
        // Initializes a new instance of the CaptchaImage class using the
        // specified text, width, height and font family.
        // ====================================================================
        public CaptchaImage(string s, int width, int height, string familyName)
        {
            this.text = s;
            this.SetDimensions(width, height);
            this.SetFamilyName(familyName);
            this.GenerateImage();
        }

        // ====================================================================
        // This member overrides Object.Finalize.
        // ====================================================================
        ~CaptchaImage()
        {
            Dispose(false);
        }

        // ====================================================================
        // Releases all resources used by this object.
        // ====================================================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        // ====================================================================
        // Custom Dispose method to clean up unmanaged resources.
        // ====================================================================
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                // Dispose of the bitmap.
                this.image.Dispose();
        }

        // ====================================================================
        // Sets the image width and height.
        // ====================================================================
        private void SetDimensions(int width, int height)
        {
            // Check the width and height.
            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Argument out of range, must be greater than zero.");
            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Argument out of range, must be greater than zero.");
            this.width = width;
            this.height = height;
        }

        // ====================================================================
        // Sets the font used for the image text.
        // ====================================================================
        private void SetFamilyName(string familyName)
        {
            // If the named font is not installed, default to a system font.
            try
            {
                Font font = new Font(this.familyName, 12F);
                this.familyName = familyName;

                font.Dispose();
            }
            catch (Exception ex)
            {
                this.familyName = System.Drawing.FontFamily.GenericSerif.Name;
            }
        }

        HatchStyle[] hsBrush =
        {
            HatchStyle.BackwardDiagonal,
            HatchStyle.Cross, HatchStyle.Divot,
            HatchStyle.DarkDownwardDiagonal,
            HatchStyle.DarkHorizontal, HatchStyle.ForwardDiagonal,
            HatchStyle.DarkUpwardDiagonal,
            HatchStyle.DarkVertical, HatchStyle.HorizontalBrick,
            HatchStyle.DashedDownwardDiagonal,
            HatchStyle.DashedHorizontal,
            HatchStyle.DashedVertical, HatchStyle.LargeCheckerBoard,
            HatchStyle.DiagonalBrick, HatchStyle.Horizontal,
            HatchStyle.DiagonalCross, HatchStyle.DottedGrid,
            HatchStyle.DottedDiamond, HatchStyle.LightUpwardDiagonal,  
            HatchStyle.LargeConfetti, HatchStyle.LargeGrid,
            HatchStyle.LightDownwardDiagonal, HatchStyle.OutlinedDiamond,
            HatchStyle.LightHorizontal, HatchStyle.LightVertical
        };

        Color[] ForeColors =
        {
            Color.FromArgb(0, 0, 255), Color.FromArgb(200, 0, 0),
            Color.Salmon, Color.Navy, Color.Pink,
            Color.FromArgb(255, 0, 255), Color.FromArgb(255, 128, 0),
            Color.FromArgb(0, 128, 192), Color.Green,
            Color.Firebrick, Color.Fuchsia, Color.Moccasin,
            Color.Goldenrod, Color.Gainsboro, Color.Khaki,
            Color.Maroon, Color.DarkCyan, Color.Purple,
            Color.MistyRose, Color.RoyalBlue, Color.Red,
            Color.SaddleBrown, Color.Olive, Color.SeaGreen,
            Color.PowderBlue
        };

        Color[] BackColors =
        {
            Color.Azure, Color.DarkBlue, Color.AntiqueWhite,
            Color.Aqua, Color.DarkGray, Color.Aquamarine,
            Color.Azure, Color.Beige, Color.DarkGoldenrod,
            Color.Bisque, Color.DarkKhaki, Color.BlanchedAlmond,
            Color.Brown, Color.DarkCyan, Color.AliceBlue,
            Color.BurlyWood, Color.CadetBlue, Color.DarkMagenta,
            Color.Coral, Color.Chartreuse, Color.CornflowerBlue,
            Color.Cornsilk, Color.Crimson, Color.Cyan,
            Color.DarkGreen
        };


        // ====================================================================
        // Creates the bitmap image.
        // ====================================================================
        private void GenerateImage()
        {
            // Create a new 32-bit bitmap image.
            Bitmap bitmap = new Bitmap(this.width, this.height, PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);
            Random rnd = new Random();
            // Fill in the background.
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.SmallConfetti, Color.LightBlue, Color.White);
            //HatchBrush hatchBrush = new HatchBrush(hsBrush[rnd.Next(hsBrush.Length)], ForeColors[rnd.Next(hsBrush.Length)], BackColors[rnd.Next(hsBrush.Length)]);
            g.FillRectangle(hatchBrush, rect);

            // Set up the text font.
            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            // Adjust the font size until the text fits within the image.
            do
            {
                fontSize--;
                font = new Font(this.familyName, fontSize, FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } while (size.Width > rect.Width);

            // Set up the text format.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.
            GraphicsPath path = new GraphicsPath();
            path.AddString(this.text, font.FontFamily, (int)font.Style, font.Size, rect, format);
            float v = 4F;
            PointF[] points =
			{
				new PointF(this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, this.random.Next(rect.Height) / v),
				new PointF(this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v),
				new PointF(rect.Width - this.random.Next(rect.Width) / v, rect.Height - this.random.Next(rect.Height) / v)
			};
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            

            //HatchBrush brushForeDiag =new HatchBrush(hsBrush[rnd.Next(25)],ForeColors[rnd.Next(25)], BackColors[rnd.Next(25)]);

            // Draw the text.
            hatchBrush = new HatchBrush(HatchStyle.LargeConfetti, ForeColors[rnd.Next(25)], Color.DarkGray);
            g.FillPath(hatchBrush, path);

            // Add some random noise.
            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up.
            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            // Set the image.
            this.image = bitmap;
        }
    }
}
