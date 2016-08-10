//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CAD
{
    [Serializable]
    class LineShape : BaseShape
    {
        public static bool IsInLine(Point p1, Point p2, Point p3)//�ж����λ��p3�Ƿ����߶�p1��p2�ϣ�0.1��Χ�ڣ�������Ƿ����棬���򷵻ؼ�
        {
            double iLen1 = Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2);
            double iLen2 = Math.Pow(p1.X - p3.X, 2) + Math.Pow(p1.Y - p3.Y, 2);
            double iLen3 = Math.Pow(p2.X - p3.X, 2) + Math.Pow(p2.Y - p3.Y, 2);

            if (Math.Pow(iLen2, 0.5) + Math.Pow(iLen3, 0.5) - Math.Pow(iLen1, 0.5) < .1)
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
            return IsInLine(this.getP1(), this.getP2(), testPoint);
        }

        public override void draw(Graphics g)//��д��ͼ
        {
            g.DrawLine(new Pen(Color.Black,1), this.getP1(), this.getP2());
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
            LineShape copyLineShape=new LineShape();
            copyLineShape.setP1(this.getP1());//�������
            copyLineShape.setP2(this.getP2());//�����յ�
            copyLineShape.penColor = this.penColor;
            copyLineShape.penwidth = this.penwidth;
            return copyLineShape;
        }
    }
}
