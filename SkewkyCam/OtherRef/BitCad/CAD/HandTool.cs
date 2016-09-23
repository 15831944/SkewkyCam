//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace CAD
{
    public partial class HandTool : BaseTool
    {
        public int catchPointIndex = -1;//��׽�ȵ������

        public override void mouseDown(object sender, MouseEventArgs e,CADFrame objC)//��д���İ���
        {
            catchPointIndex = -1;//���ò�׽�ȵ������
            if (this.getOperShape() != null) this.getOperShape().setUnSelected();//���ǰ����������ѡ�е�״̬
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();//�õ������ϵ�����ͼ��
            int catchPoint = -1;
            int i = 0;
            for (; i < allShapes.Count; i++)//��ÿ��ͼ�ν��в�׽����
            {
                catchPoint = ((BaseShape)allShapes[i]).catchShapPoint(this.getNewMovePoint());//��׽�����е�һ��ͼ��
                if (catchPoint > -1) break;//���񵽺�����ѭ��
            }
            if (catchPoint > -1)
            {
                catchPointIndex = catchPoint;//���񵽺󣬽���ʱ���ȵ����õ�����������
                ((BaseShape)allShapes[i]).setSelected();//���ò�׽����ͼ��Ϊѡ��״̬
                this.setOperShape(((BaseShape)allShapes[i]));//��ѡ�е�ͼ���趨������Ĳ���ͼ�ε�״̬��
            }
            this.getRefCADPanel().Refresh();//ˢ�»���
        }
        public override void mouseDrag(object sender, MouseEventArgs e)//��д�����϶��¼�
        {
            if (this.getOperShape() != null)//����ѡ�е�ͼ��ʱ
            {
                Point setPoint = this.getNewDragPoint();
                if (catchPointIndex == 0)//�����׽���ƶ���ʱ
                {
                    setPoint = new Point();
                    setPoint.X = this.getNewDragPoint().X - this.getOldDragPoint().X;//����������
                    setPoint.Y = this.getNewDragPoint().Y - this.getOldDragPoint().Y;//����������
                }
                this.getOperShape().setHitPoint(catchPointIndex, setPoint);//�����ȵ�
                this.getRefCADPanel().Refresh();//ˢ�»���
            }
        }

        public BaseShape oldMoveShap = null;//�ƶ������ͼ��

        public override void mouseMove(object sender, MouseEventArgs e)//��д�����ƶ�
        {
            if (oldMoveShap != null) oldMoveShap.setUnSelected();//����ƶ�ͼ��ѡ�е�״̬
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();//�õ������ϵ�ͼ�μ���
            int catchPoint = -1;//��ʱ����Ĳ�׽�ȵ�
            int i = 0;
            for (; i < allShapes.Count; i++)//��ÿ��ͼ�β�׽����
            {
                catchPoint = ((BaseShape)allShapes[i]).catchShapPoint(this.getNewMovePoint());
                if (catchPoint > -1) break;//��׽������ѭ��
            }
            if (catchPoint > -1)//��׽����
            {
                ((BaseShape)allShapes[i]).setSelected();//�趨��׽����ͼ��Ϊѡ��״̬
                oldMoveShap = (BaseShape)allShapes[i];//��ѡ�е�ͼ���趨������Ĳ���ͼ�ε�״̬��ȥ
            }
            this.getRefCADPanel().Refresh();//ˢ�»���
        }

        public override void mouseUp(object sender, MouseEventArgs e)//��д�����ͷ�
        {
            this.getRefCADPanel().Refresh();//ˢ�»���
        }

        public override void unSet()//���ߵ�ж��
        {
            ArrayList allShapes = this.getRefCADPanel().getCurrentShapes();//�õ������ϵ�ͼ�μ���
            for (int i = 0; i < allShapes.Count; i++)//�������ͼ�ε�ѡ��״̬
            {
                ((BaseShape)allShapes[i]).setUnSelected();
            }
            this.getRefCADPanel().Refresh();
        }

        public override void set()
        {
            
        }
    }
}
