//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CAD
{
    public partial class RectangleTool : BaseTool
    {
        public override void mouseDown(object sender, MouseEventArgs e, CADFrame objC)//��д�ߵ���갴��
        {
            this.setOperShape(new RectangleShape());
            this.getOperShape().setP1(this.getDownPoint());
            this.getOperShape().penColor = objC.clr;
            this.getOperShape().penwidth = objC.lineWidth;
            this.getRefCADPanel().getCurrentShapes().Add(this.getOperShape());//
        }

        public override void mouseDrag(object sender, MouseEventArgs e)//��д�ߵ�����϶�
        {
            this.getOperShape().setP2(this.getNewDragPoint());
            this.getRefCADPanel().Refresh();
        }

        public override void mouseMove(object sender, MouseEventArgs e)
        {
        }

        public override void mouseUp(object sender, MouseEventArgs e)
        {
        }

        public override void unSet()
        {
        }

        public override void set()
        {
        }
    }
}
