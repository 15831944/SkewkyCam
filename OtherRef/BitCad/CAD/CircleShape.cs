//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CAD
{
    [Serializable]
    class CircleShape : BaseShape
    {
        public static bool IsInCircle(Point p1, Point p2, Point p3)//�ж����λ��p3�Ƿ����߶�p1��p2�ϣ�0.1��Χ�ڣ�������Ƿ����棬���򷵻ؼ�
        {
            int r = (int)Math.Pow(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2), 0.5);
            Point p4 = new Point();//������������ϵ�
            p4.X = p1.X - r;
            if (Math.Abs(Math.Pow(Math.Pow(p1.X-p3.X,2)+Math.Pow(p1.Y-p3.Y,2),0.5)-r)< 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool catchShape(Point testPoint)//��дͼ�εĲ�׽���������testPoint��ͼ����Χ�������棬���򷵻ؼ�
        {
            return IsInCircle(this.getP1(), this.getP2(), testPoint);
        }

        public override void draw(Graphics g)//��д��ͼ
        {
            g.DrawLine(new Pen(Color.Black, 1), this.getP1(), this.getP2());
        }

        public override Point[] getAllHitPoint()//���������ȵ�
        {
            Point[] allHitPoint = new Point[2];
            allHitPoint[0] = this.getP1();
            allHitPoint[1] = this.getP2();
            return allHitPoint;
        }

        public override void setHitPoint(int hitPointIndex, Point newPoint)//��д�����ȵ�ķ���
        {
            switch (hitPointIndex)
            {
                case 0:
                    {
                        Point tempPoint;//0������Ե�����
                        tempPoint = new Point();
                        tempPoint.X = this.getP1().X + newPoint.X;//����X���������
                        tempPoint.Y = this.getP1().Y + newPoint.Y;//����Y���������
                        this.setP1(tempPoint);
                        tempPoint = new Point();
                        tempPoint.X = this.getP2().X + newPoint.X;
                        tempPoint.Y = this.getP2().Y + newPoint.Y;
                        this.setP2(tempPoint);
                        break;
                    }
                case 1:
                    {
                        this.setP1(newPoint);//����P1���ȵ�
                        break;
                    }
                case 2:
                    {
                        this.setP2(newPoint);//����P2���ȵ�
                        break;
                    }
            }
        }

        public override BaseShape copySelf()//��д���Ʒ���
        {
            CircleShape copyCircleShape = new CircleShape();
            copyCircleShape.setP1(this.getP1());//�������
            copyCircleShape.setP2(this.getP2());//�����յ�
            copyCircleShape.penColor = this.penColor;
            copyCircleShape.penwidth = this.penwidth;
            return copyCircleShape;
        }
    }
}
