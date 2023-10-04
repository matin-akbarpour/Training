using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            MakeShape();
        }

        public void MakeShape()
        {
            GraphicsPath Graph = new GraphicsPath();
            Graph = RoundedRect.Create(0, 0, Width, Height, 7, RoundedRect.RectangleCorners.All);
            this.Region = new Region(Graph);
            Point Orgin = this.PointToScreen(new Point(0, 0));
        }

        public  void btnCancelLoading_Click(object sender, EventArgs e)
        {

        }
    }
}
