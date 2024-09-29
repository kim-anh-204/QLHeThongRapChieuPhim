using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRapChieuPhim.UserControls
{
    public partial class RoundedCornerPictureBox : UserControl
    {
        private int _cornerRadius = 70;

        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                Invalidate();  // Gọi lại vẽ khi giá trị thay đổi
            }
        }
        public Image Image
        {
            get => pictureBox1.Image;
            set
            {
                pictureBox1.Image = value;
                Invalidate();
            }
        }

        public RoundedCornerPictureBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (pictureBox1.Image != null)
            {
                // Vẽ ảnh với góc bo tròn
                Image roundedImage = RoundCorners(pictureBox1.Image, _cornerRadius);
                e.Graphics.DrawImage(roundedImage, new Rectangle(0, 0, this.Width, this.Height));
            }
            else
            {
                base.OnPaint(e); // Vẽ phần nền trước khi vẽ hình ảnh

            }
        }

        private Image RoundCorners(Image image, int cornerRadius)
        {
            cornerRadius *= 2;
            Bitmap roundedImage = new Bitmap(image.Width, image.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            gp.AddArc(roundedImage.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            gp.AddArc(roundedImage.Width - cornerRadius, roundedImage.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gp.AddArc(0, roundedImage.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            gp.CloseFigure();

            using (Graphics g = Graphics.FromImage(roundedImage))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.SetClip(gp);
                g.DrawImage(image, Point.Empty);
            }
            return roundedImage;
        }
    }

}
