//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CAD
{
    public abstract class BaseTool
    {
        private CADFrame refCADPanel = null;//��������

        private Point upPoint = new Point();//��굯���
        private Point downPoint = new Point();//��갴�µ�
        private Point newMovePoint = new Point();//�µ�����ƶ���
        private Point oldMovePoint = new Point();//�ϵ�����ƶ���
        private Point newDragPoint = new Point();//�µ�����϶���
        private Point oldDragPoint = new Point();//�ϵ�����϶���

        private BaseShape operShape = null;//����ͼ��

        public Point getDownPoint()
        {
            return downPoint;
        }
        public void setDownPoint(Point downPoint)
        {
            this.downPoint = downPoint;
        }
        public Point getNewDragPoint()
        {
            return newDragPoint;
        }
        public void setNewDragPoint(Point newDragPoint)
        {
            this.newDragPoint = newDragPoint;
        }
        public Point getNewMovePoint()
        {
            return newMovePoint;
        }
        public void setNewMovePoint(Point newMovePoint)
        {
            this.newMovePoint = newMovePoint;
        }
        public Point getOldDragPoint()
        {
            return oldDragPoint;
        }
        public void setOldDragPoint(Point oldDragPoint)
        {
            this.oldDragPoint = oldDragPoint;
        }
        public Point getOldMovePoint()
        {
            return oldMovePoint;
        }
        public void setOldMovePoint(Point oldMovePoint)
        {
            this.oldMovePoint = oldMovePoint;
        }
        public Point getUpPoint()
        {
            return upPoint;
        }
        public void setUpPoint(Point upPoint)
        {
            this.upPoint = upPoint;
        }
        public CADFrame getRefCADPanel()
        {
            return refCADPanel;
        }
        public void setRefCADPanel(CADFrame refCADPanel)
        {
            this.refCADPanel = refCADPanel;
        }
        public BaseShape getOperShape()
        {
            return operShape;
        }
        public void setOperShape(BaseShape operShape)
        {
            this.operShape = operShape;
        }

        public abstract void mouseUp(object sender, MouseEventArgs e);//��굯��Ĵ���
        public abstract void mouseDown(object sender, MouseEventArgs e,CADFrame objC);//��갴�µĴ���
        public abstract void mouseMove(object sender, MouseEventArgs e);//����ƶ��Ĵ���
        public abstract void mouseDrag(object sender, MouseEventArgs e);//����϶��Ĵ���

        public void superMouseUp(object sender, MouseEventArgs e)//����ͷ�
        {
            this.setUpPoint(new Point(e.X, e.Y));//���ĵ������趨
            this.mouseUp(sender, e);//���ĵ�����趨
            this.setUpPoint(new Point());//��굯�����趨
            this.setDownPoint(new Point());//��갴�µ���趨
            this.setOldMovePoint(new Point());//�ϵ�����ƶ�����趨
            this.setNewMovePoint(new Point());//�µ�����ƶ�����趨
            this.setOldDragPoint(new Point());//�ϵ�����϶�����趨
            this.setNewDragPoint(new Point());//�µ�����϶�����趨
            this.getRefCADPanel().record();//����
        }

        public void superMouseDown(object sender, MouseEventArgs e,CADFrame objCAD)//��갴��
        {
            this.setUpPoint(new Point(e.X, e.Y));//���ĵ������趨
            this.setDownPoint(new Point(e.X, e.Y));//��갴�µ���趨
            this.setOldMovePoint(new Point(e.X, e.Y));//�ϵ�����ƶ�����趨
            this.setNewMovePoint(new Point(e.X, e.Y));//�µ�����ƶ�����趨
            this.setOldDragPoint(new Point(e.X, e.Y));//�ϵ�����϶�����趨
            this.setNewDragPoint(new Point(e.X, e.Y));//�µ�����϶�����趨
            this.mouseDown(sender, e,objCAD);//��갴�µĴ���
        }

        public void superMouseMove(object sender, MouseEventArgs e)//����ƶ�
        {
            this.setNewMovePoint(new Point(e.X, e.Y));//�µ�����ƶ�����趨
            this.mouseMove(sender, e);//����ƶ�
            this.setOldMovePoint(this.getNewMovePoint());//�ϵ�����ƶ�����趨
        }

        public void superMouseDrag(object sender, MouseEventArgs e)//����϶�
        {
            this.setNewDragPoint(new Point(e.X, e.Y));//�µ�����϶�����趨
            this.mouseDrag(sender, e);//����϶�
            this.setOldDragPoint(this.getNewDragPoint());//�ϵ�����϶�����趨
        }

        public abstract void set();//װ��
        public abstract void unSet();//ж��
    }
}
