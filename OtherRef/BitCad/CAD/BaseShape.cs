//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CAD
{
    [Serializable]
    public abstract class BaseShape
    {
        private bool isSelected = false;//��ʶͼ���Ƿ�ѡ��
        
        private Point p1;//��һ����
        private Point p2;//�ڶ�����

        public  Color penColor;
        public  int penwidth ;

        public void setSelected()//����Ϊѡ��״̬
        {
            this.isSelected = true;
        }
        public void setUnSelected()//����Ϊ��ѡ��״̬
        {
            this.isSelected = false;
        }
        public Point getP1()
        {
            return p1;
        }
        public void setP1(Point p1)
        {
            this.p1 = p1;
        }
        public Point getP2()
        {
            return p2;
        }
        public void setP2(Point p2)
        {
            this.p2 = p2;
        }

        public abstract void draw(Graphics g);//��ͼ��

        public abstract Point[] getAllHitPoint();//�õ�����ͼ��
        public abstract void setHitPoint(int hitPointIndex, Point newPoint);//�趨�ȵ�
        public abstract BaseShape copySelf();//����


        public bool catchHitPoint(Point hitPoint, Point testPoint)//�����ȵ㲶׽
        {
            return this.getHitPointRectangle(hitPoint).Contains(testPoint);
        }

        public int catchShapPoint(Point testPoint)//��׽ͼ��
        {
            int hitPointIndex = -1;
            Point[] allHitPoint = this.getAllHitPoint();//�ĵ����е��ȵ�
            for (int i = 0; i < allHitPoint.Length; i++)//ѭ����׽�ж�
            {
                if (this.catchHitPoint(allHitPoint[i], testPoint))
                {
                    return i + 1;//�����׽�����ȵ㣬�����ȵ������
                }
            }
            if(this.catchShape(testPoint)) return 0;//û�в�׽���ȵ㣬��׽����ͼ�Σ������ر��ȵ�
            return hitPointIndex;//���ز�׽�����˵�
            }
        public void drawHitPoint(Point hitPoint, Graphics g)//���ȵ�
        {
            g.DrawRectangle(new Pen(Color.Red,1), this.getHitPointRectangle(hitPoint));
        }

        public void drawAllHitPoint(Graphics g)//�������ȵ�
        {
            Point[] allHitPoint=this.getAllHitPoint();
            for(int i=0;i<2;i++)
            {
                this.drawHitPoint(allHitPoint[i],g);
            }
        }

        public Rectangle getHitPointRectangle(Point hitPoint)//�õ��ȵ���Σ����ȵ�Ϊ���ĸ߿�5���صľ���
        {
            Rectangle rect=new Rectangle();
            rect.X=hitPoint.X-2;
            rect.Y=hitPoint.Y-2;
            rect.Width=5;
            rect.Height=5;
            return rect;
        }

        public abstract bool catchShape(Point testPoint);//ͼ�β�׽

        public void superDraw(Graphics g)//��������
        {
            if(this.isSelected) this.drawAllHitPoint(g);
        }

        public static Pen getPen(CADFrame objCAD)//�õ�����
        {
            return new Pen(objCAD.clr,objCAD.lineWidth);
        }
    }
}