//Download by http://www.NewXing.com
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CAD
{
    public partial class CADFrame : Form
    {
        private BaseTool currentTool = null;//��ǰ��Ӧ�ù���
        private ArrayList currentShapes = null;//��ǰ��ʾ��ͼ�μ���
        private Hashtable registerToolMap = null;//��ǰע��Ĺ��߼���
        private ArrayList historyShapes = null;//��ʷͼ�εĿ��ռ���

        public  Color clr = Color.Black;
        public  int lineWidth = 1;

        public const string LINETOOL_REGISTERNAME = "LINETOOL_REGISTERNAME";
        public const string HANDTOOL_REGISTERNAME = "HANDTOOL_REGISTERNAME";
        public const string RECTANGLET0OL_REGISTERNAME = "RECTANGLET0OL_REGISTERNAME";
        public const string ELLIPSETOOL_REGISTERNAME = "ELLIPSETOOL_REGISTERNAME";
        public const string CIRCLETOOL_REGISTERNAME = "CIRCLETOOL_REGISTERNAME";

        public CADFrame()
        {
            InitializeComponent();
            currentShapes = new ArrayList();//ʵ����ǰ��ʾ��ͼ�μ��϶���
            registerToolMap = new Hashtable();//ע�Ṥ�ߵļ��϶���
            historyShapes = new ArrayList();//��ʷͼ�εĿ��ռ��϶���
            this.registerTool(LINETOOL_REGISTERNAME, new LineTool());//ע���߹���
            this.registerTool(HANDTOOL_REGISTERNAME, new HandTool());//ע��ץȡ����
            this.registerTool(RECTANGLET0OL_REGISTERNAME, new RectangleTool());//ע����ι���
            this.registerTool(ELLIPSETOOL_REGISTERNAME, new EllipseTool());//ע����Բ����
            this.registerTool(CIRCLETOOL_REGISTERNAME, new CircleTool());//ע��Բ�ι���
            this.record();
        }

        public ArrayList getCurrentShapes()
        {
            return currentShapes;
        }

        public void setCurrentShapes(ArrayList currentShapes)
        {
            this.currentShapes = currentShapes;
        }

        public BaseTool getCurrentTool()
        {
            return currentTool;
        }

        public void setCurrentTool(BaseTool currentTool)
        {
            this.currentTool = currentTool;
        }

        public Hashtable getRegisterToolMap()
        {
            return registerToolMap;
        }

        public void setRegisterToolMap(Hashtable registerToolMap)
        {
            this.registerToolMap = registerToolMap;
        }

        public ArrayList getHistoryShape()
        {
            return historyShapes;
        }

        public void setHistoryShapes(ArrayList historyShapes)
        {
            this.historyShapes = historyShapes;
        }

        public void registerTool(string registerName, BaseTool registerTool)//ע�Ṥ��
        {
            this.getRegisterToolMap().Add(registerName, registerTool);
            registerTool.setRefCADPanel(this);
        }

        public void useTool(string registerName)//Ӧ�ù���
        {
            if (this.getCurrentTool() != null) this.getCurrentTool().unSet();//ж��֮ǰ�Ĺ���
            BaseTool setTool = (BaseTool)this.getRegisterToolMap()[registerName];//��������Ҫ�õĹ���
            if (setTool != null)
            {
                setTool.set();
                this.setCurrentTool(setTool);//װ�ع���
            }
        }

        int undoIndex = 0;//���˵�����
        public void record()//���ձ���ķ��� 
        {
            if (undoIndex > 0)//���л���ʱ����ջ��˻�ÿ���
            {
                while (undoIndex != 0)
                {
                    this.getHistoryShape().RemoveAt(this.getHistoryShape().Count - 1);
                    undoIndex--;
                }
            }
            this.getHistoryShape().Add(this.cloneShapArray(this.getCurrentShapes()));//�������
        }
        public void redo()//����
        {
            if (undoIndex > 0)//���л���ʱ�ſ�����
            {
                undoIndex--;//����ʷ����ȡ�ص���ǰͼ����
                this.setCurrentShapes(this.cloneShapArray((ArrayList)this.getHistoryShape()[this.getHistoryShape().Count - 1 - undoIndex]));
            }
            this.Refresh();
        }

        public void undo()//����
        {
            if ((this.getHistoryShape().Count - 1 - undoIndex) > 0)//��ʷ�����л�����ʷ���ܻ���
            {
                undoIndex++;//����ʷ����ȡ�ص���ǰͼ����
                this.setCurrentShapes((this.cloneShapArray((ArrayList)this.getHistoryShape()[this.getHistoryShape().Count - 1 - undoIndex])));
            }
            this.Refresh();
        }

        public ArrayList cloneShapArray(ArrayList shapeArrayList)//ͼ�μ�������
        {
            ArrayList returnShapeArrayList = new ArrayList();
            for (int i = 0; i < shapeArrayList.Count; i++)
            {
                returnShapeArrayList.Add(((BaseShape)shapeArrayList[i]).copySelf());
            }
            return returnShapeArrayList;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            this.useTool(LINETOOL_REGISTERNAME);
        }

        private void btnHand_Click(object sender, EventArgs e)
        {
            this.useTool(HANDTOOL_REGISTERNAME);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            this.useTool(RECTANGLET0OL_REGISTERNAME);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            this.useTool(ELLIPSETOOL_REGISTERNAME);
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            this.useTool(CIRCLETOOL_REGISTERNAME);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.redo();
        }

        public void clear()
        {
            undoIndex = 0;
            this.setHistoryShapes(new ArrayList());
            this.setCurrentShapes(new ArrayList());
            this.record();
            this.pictureBox1.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void save(string filePath)
        {
            Stream s = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter b = new BinaryFormatter();
            for (int i = 0; i < this.getCurrentShapes().Count; i++)
            {
                b.Serialize(s,this.getCurrentShapes()[i]);
            }
            s.Close();
        }

        public void load(string filePath)
        {
            Stream s = File.Open(filePath, FileMode.Open, FileAccess.Read);
            BinaryFormatter c = new BinaryFormatter();
            ArrayList newShapes = new ArrayList();
            bool forFlat = true;
            for (int i = 0; forFlat; i++)
            {
                try
                {
                    newShapes.Add(c.Deserialize(s));
                }
                catch
                {
                    forFlat = false;
                }
            }
            s.Close();
            this.setCurrentShapes(newShapes);
            this.setHistoryShapes(new ArrayList());
            this.record();
            undoIndex = 0;
            this.pictureBox1.Refresh();
        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                load(openFileDialog1.FileName);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                save(saveFileDialog1.FileName);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    for (int i = 0; i < currentShapes.Count; i++)
        //    {
        //        ((BaseShape)currentShapes[i]).superDraw(g,this);
        //    }
        //}
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < currentShapes.Count; i++)
            {
                
                string Type=((BaseShape)currentShapes[i]).GetType().ToString();
                switch (Type)
                {
                    case "CAD.LineShape":
                        g.DrawLine(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP1(), ((BaseShape)currentShapes[i]).getP2());
                        break;
                    case "CAD.RectangleShape":
                        g.DrawRectangle(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP1().X, ((BaseShape)currentShapes[i]).getP1().Y, (((BaseShape)currentShapes[i]).getP2().X - ((BaseShape)currentShapes[i]).getP1().X), (((BaseShape)currentShapes[i]).getP2().Y - ((BaseShape)currentShapes[i]).getP1().Y));
                        g.DrawRectangle(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP1().X, ((BaseShape)currentShapes[i]).getP2().Y, (((BaseShape)currentShapes[i]).getP2().X - ((BaseShape)currentShapes[i]).getP1().X), (((BaseShape)currentShapes[i]).getP1().Y - ((BaseShape)currentShapes[i]).getP2().Y));
                        g.DrawRectangle(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP2().X, ((BaseShape)currentShapes[i]).getP2().Y, (((BaseShape)currentShapes[i]).getP1().X - ((BaseShape)currentShapes[i]).getP2().X), (((BaseShape)currentShapes[i]).getP1().Y - ((BaseShape)currentShapes[i]).getP2().Y));
                        g.DrawRectangle(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP2().X, ((BaseShape)currentShapes[i]).getP1().Y, (((BaseShape)currentShapes[i]).getP1().X - ((BaseShape)currentShapes[i]).getP2().X), (((BaseShape)currentShapes[i]).getP2().Y - ((BaseShape)currentShapes[i]).getP1().Y));
                        break;
                    case "CAD.EllipseShape":
                        g.DrawEllipse(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP1().X, ((BaseShape)currentShapes[i]).getP1().Y, (((BaseShape)currentShapes[i]).getP2().X - ((BaseShape)currentShapes[i]).getP1().X), (((BaseShape)currentShapes[i]).getP2().Y - ((BaseShape)currentShapes[i]).getP1().Y));
                        break;
                    case "CAD.CircleShape":
                        int r = (int)Math.Pow(Math.Pow(((BaseShape)currentShapes[i]).getP2().X - ((BaseShape)currentShapes[i]).getP1().X, 2) + Math.Pow(((BaseShape)currentShapes[i]).getP2().Y - ((BaseShape)currentShapes[i]).getP1().Y, 2), 0.5);
                        g.DrawEllipse(new Pen(((BaseShape)currentShapes[i]).penColor, ((BaseShape)currentShapes[i]).penwidth), ((BaseShape)currentShapes[i]).getP1().X-r, ((BaseShape)currentShapes[i]).getP1().Y-r, 2*r,2*r);
                        break;
                        g.
                }
                ((BaseShape)currentShapes[i]).superDraw(g);
            }
        }

        bool isMouseDown = false;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            if (this.getCurrentTool() != null) this.getCurrentTool().superMouseDown(sender, e,this);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (this.getCurrentTool() != null) this.getCurrentTool().superMouseDrag(sender, e);
            }
            else
            {
                if (this.getCurrentTool() != null) this.getCurrentTool().superMouseMove(sender, e);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (this.getCurrentTool() != null) this.getCurrentTool().superMouseUp(sender, e);
        }

        private void txtLineWidth_TextChanged(object sender, EventArgs e)
        {

            Bitmap bit = new Bitmap(picLineWidth.Width, picLineWidth.Height);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(Color.Black, int.Parse(this.txtLineWidth.Text));
            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = 0;
            p1.Y = picLineWidth.Height / 2;
            p2.X = picLineWidth.Width;
            p2.Y = picLineWidth.Height / 2;
            g.DrawLine(pen, p1, p2);
            picLineWidth.Image = bit;
            this.tbarLineWidth.Value = int.Parse(this.txtLineWidth.Text);
            lineWidth = int.Parse(this.txtLineWidth.Text);
        }

        private void tbarLineWidth_Scroll(object sender, EventArgs e)
        {
            this.txtLineWidth.Text = tbarLineWidth.Value.ToString();
        }

        private void CADFrame_Load(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(picLineWidth.Width, picLineWidth.Height);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(Color.Black, 1);
            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = 0;
            p1.Y = picLineWidth.Height / 2;
            p2.X = picLineWidth.Width;
            p2.Y = picLineWidth.Height / 2;
            g.DrawLine(pen, p1, p2);
            picLineWidth.Image = bit;
            picCurrentColor.BackColor = clr;
        }

        private void rectColor()
        {
            Bitmap bit = new Bitmap(30, 27);
            Graphics g = Graphics.FromImage(bit);
            Pen pen = new Pen(Color.Gray, 1);
            Point p1 = new Point();
            Point p2 = new Point();
            p1.X = 0;
            p1.Y = 15;
            p2.X = 15;
            p2.Y = 14;
            g.DrawLine(pen, p1, p2);
            picLineWidth.Image = bit;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            clr = Color.Black;
            picCurrentColor.BackColor = clr;
        }

        private void White_Click(object sender, EventArgs e)
        {
            clr = Color.White;
            picCurrentColor.BackColor = clr;
        }

        private void Red_Click(object sender, EventArgs e)
        {
            clr = Color.Red;
            picCurrentColor.BackColor = clr;
        }

        private void Green_Click(object sender, EventArgs e)
        {
            clr = Color.Green;
            picCurrentColor.BackColor = clr;
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            clr = Color.Blue;
            picCurrentColor.BackColor = clr;
        }

        private void Cyan_Click(object sender, EventArgs e)
        {
            clr = Color.Cyan;
            picCurrentColor.BackColor = clr;
        }

        private void Magente_Click(object sender, EventArgs e)
        {
            clr = Color.Magenta;
            picCurrentColor.BackColor = clr;
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            clr = Color.Yellow;
            picCurrentColor.BackColor = clr;
        }

        private void btnMoreColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                clr = colorDialog1.Color;
                picCurrentColor.BackColor = clr;
            }
        }

        
    }
}