//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CAD
{
    [Serializable]
    class RectangleShape : BaseShape
    {
        public static bool IsInRectangle(Point p1, Point p2, Point p3)//�ж����λ��p3�Ƿ����߶�p1��p2�ϣ�0.1��Χ�ڣ�������Ƿ����棬���򷵻ؼ�
        {
            double iLen1 = Math.Abs(p1.Y - p2.Y);//���εĸ�
            double iLen2 = Math.Abs(p1.X - p2.X);//���εĿ�
            double iLen3,iLen4,iLen5,iLen6;

            if (p2.X > p1.X && p2.Y > p1.Y)
            {
                iLen3 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3���������ߵľ���
                iLen4 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5);
                //p3��������ϱߵľ���
                iLen5 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ұߵľ���
                iLen6 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������±ߵľ���
                if ((iLen3 - iLen1) < .1 || (iLen4 - iLen2) < .1 || (iLen5 - iLen1) < .1 || (iLen6 - iLen2) < .1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (p2.X > p1.X && p2.Y < p1.Y)
            {
                iLen3 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3���������ߵľ���
                iLen4 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ϱߵľ���
                iLen5 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ұߵľ���
                iLen6 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5);
                //p3��������±ߵľ���
                if ((iLen3 - iLen1) < .1 || (iLen4 - iLen2) < .1 || (iLen5 - iLen1) < .1 || (iLen6 - iLen2) < .1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (p2.X < p1.X && p2.Y < p1.Y)
            {
                iLen5 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3���������ߵľ���
                iLen4 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ϱߵľ���
                iLen3 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ұߵľ���
                iLen6 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5);
                //p3��������±ߵľ���
                if ((iLen3 - iLen1) < .1 || (iLen4 - iLen2) < .1 || (iLen5 - iLen1) < .1 || (iLen6 - iLen2) < .1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                iLen5 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3���������ߵľ���
                iLen6 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5) + Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ϱߵľ���
                iLen3 = Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p2.Y, 2), 0.5);
                //p3��������ұߵľ���
                iLen4 = Math.Pow(Math.Pow(p1.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5) + Math.Pow(Math.Pow(p2.X - p3.X, 2) + Math.Pow(p3.Y - p1.Y, 2), 0.5);
                //p3��������±ߵľ���
                if ((iLen3 - iLen1) < .1 || (iLen4 - iLen2) < .1 || (iLen5 - iLen1) < .1 || (iLen6 - iLen2) < .1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override bool catchShape(Point testPoint)//��дͼ�εĲ�׽���������testPoint��ͼ����Χ�������棬���򷵻ؼ�
        {
            return IsInRectangle(this.getP1(), this.getP2(), testPoint);
        }

        public override void draw(Graphics g)//��д��ͼ
        {
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
            RectangleShape copyRectangleShape=new RectangleShape();
            copyRectangleShape.setP1(this.getP1());//�������
            copyRectangleShape.setP2(this.getP2());//�����յ�
            copyRectangleShape.penColor = this.penColor;
            copyRectangleShape.penwidth = this.penwidth;
            return copyRectangleShape;
        }
    }
}
