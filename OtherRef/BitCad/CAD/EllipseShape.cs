//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CAD
{
    [Serializable]
    class EllipseShape : BaseShape
    {
        public static bool IsInEllipse(Point p1, Point p2, Point p3)//�ж����λ��p3�Ƿ�����Բ�ϣ�0.1��Χ�ڣ�������Ƿ����棬���򷵻ؼ�
        {
            Point pa1 = new Point();//�󽹵�
            Point pa2 = new Point();//�ҽ���
            double iLen2 = 0;
            if (Math.Abs(p1.X - p2.X) > Math.Abs(p1.Y - p2.Y))//�����ڸ�
            {
                double iLen1 = Math.Pow(Math.Abs(Math.Pow(p2.X - p1.X, 2) - Math.Pow(p2.Y - p1.Y, 2)), 0.5) / 2;//����ĳ���
                iLen2 = Math.Abs(p2.X - p1.X);//������������Ĺ̶������
                if (p2.X > p1.X&&p2.Y>p1.Y)//���ϵ�����
                { 
                    pa1.X = (int)(p1.X + iLen2 / 2 - iLen1);
                    pa1.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2);
                    pa2.X = (int)(p1.X + iLen2 / 2 + iLen1);
                    pa2.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2);
                }
                if(p2.X<p1.X&&p2.Y>p1.Y)//���ϵ�����
                {
                    pa1.X = (int)(p2.X + iLen2 / 2 - iLen1);
                    pa1.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2);
                    pa2.X = (int)(p2.X + iLen2 / 2 + iLen1);
                    pa2.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2);
                }
                if (p2.X < p1.X && p2.Y < p1.Y)//���µ�����
                {
                    pa1.X = (int)(p2.X + iLen2 / 2 - iLen1);
                    pa1.Y = (int)(p2.Y + Math.Abs(p1.Y - p2.Y) / 2);
                    pa2.X = (int)(p2.X + iLen2 / 2 + iLen1);
                    pa2.Y = (int)(p2.Y + Math.Abs(p1.Y - p2.Y) / 2);
                }
                if (p1.X < p2.X && p1.Y > p2.Y)//���µ�����
                {
                    pa1.X = (int)(p1.X + iLen2 / 2 - iLen1);
                    pa1.Y = (int)(p2.Y + Math.Abs(p1.Y - p2.Y) / 2);
                    pa2.X = (int)(p1.X + iLen2 / 2 + iLen1);
                    pa2.Y = (int)(p2.Y + Math.Abs(p1.Y - p2.Y) / 2);
                }
            }
            else
            {
                double iLen1 = Math.Pow(Math.Abs(Math.Pow(p2.X - p1.X, 2) - Math.Pow(p2.Y - p1.Y, 2)), 0.5) / 2;//����ĳ���
                iLen2 = Math.Abs(p2.Y - p1.Y);//������������Ĺ̶������
                if (p2.X > p1.X && p2.Y > p1.Y)//���ϵ�����
                {
                    pa1.X = (int)(p1.X + Math.Abs(p2.X - p1.X) / 2);
                    pa1.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2 - iLen1);
                    pa2.X = (int)(p1.X + Math.Abs(p2.X - p1.X) / 2);
                    pa2.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2 + iLen1);
                }
                if (p2.X < p1.X && p2.Y < p1.Y)//���µ�����
                {
                    pa1.X = (int)(p2.X + Math.Abs(p2.X - p1.X) / 2);
                    pa1.Y = (int)(p2.Y + Math.Abs(p2.Y - p1.Y) / 2 - iLen1);
                    pa2.X = (int)(p2.X + Math.Abs(p2.X - p1.X) / 2);
                    pa2.Y = (int)(p2.Y + Math.Abs(p2.Y - p1.Y) / 2 + iLen1);
                }
                if (p2.X > p1.X && p2.Y < p1.Y)//���µ�����
                {
                    pa1.X = (int)(p1.X + Math.Abs(p2.X - p1.X) / 2);
                    pa1.Y = (int)(p2.Y + Math.Abs(p2.Y - p1.Y) / 2 - iLen1);
                    pa2.X = (int)(p1.X + Math.Abs(p2.X - p1.X) / 2);
                    pa2.Y = (int)(p2.Y + Math.Abs(p2.Y - p1.Y) / 2 + iLen1);
                }
                if (p2.X < p1.X && p2.Y > p1.Y)//���ϵ�����
                {
                    pa1.X = (int)(p2.X + Math.Abs(p2.X - p1.X) / 2);
                    pa1.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2 - iLen1);
                    pa2.X = (int)(p2.X + Math.Abs(p2.X - p1.X) / 2);
                    pa2.Y = (int)(p1.Y + Math.Abs(p2.Y - p1.Y) / 2 + iLen1);
                }
            }
            double iLen3 = Math.Pow(Math.Pow(p3.X - pa1.X, 2) + Math.Pow(p3.Y - pa1.Y, 2), 0.5) + Math.Pow(Math.Pow(p3.X - pa2.X, 2) + Math.Pow(p3.Y - pa2.Y, 2), 0.5);
            //p3�������������ľ����
            if (Math.Abs(iLen3-iLen2) < 5)
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
            return IsInEllipse(this.getP1(), this.getP2(), testPoint);
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
            EllipseShape copyEllipseShape = new EllipseShape();
            copyEllipseShape.setP1(this.getP1());//�������
            copyEllipseShape.setP2(this.getP2());//�����յ�
            copyEllipseShape.penColor = this.penColor;
            copyEllipseShape.penwidth = this.penwidth;
            return copyEllipseShape;
        }
    }
}
