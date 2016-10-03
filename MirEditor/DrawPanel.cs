using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirEditor
{
    public partial class DrawPanel : UserControl
    {
        // 鼠标按下位置
        Point m_mousePos;
        Point m_drawBoxMousePos = new Point(0, 0);
        bool m_isMouseDown = false;

        Point m_drawBoxPos;

        int ScaleDelta = 12000;

        public DrawBox m_drawBox;

        // 选择的点
        public Point m_sel;

        // 绘制格子
        public bool m_isDrawGrid = false;
        // 绘制前景阻挡
        public bool m_isDrawBackLimit = false;
        // 绘制背景阻挡
        public bool m_isDrawFrontLimit = false;

        public DrawPanel()
        {
            InitializeComponent();
        }

        public void open( string filePath )
        {
            m_drawBox = new DrawBox(filePath, this.Width, this.Height);
            this.Invalidate();
        }

        private void drawGrids(Graphics g, bool isDraw)
        {
            if (!isDraw || this.m_drawBox == null)
            {
                return;
            }

            // 相对于格子
            Rectangle rcGrid = new Rectangle( 0, 0, m_drawBox.MapWidth, m_drawBox.MapHeight);
            rcGrid.Intersect( new Rectangle(-m_drawBox.DrawBoxX, -m_drawBox.DrawBoxY, this.Width, this.Height) );

            if( rcGrid.Width == 0 && rcGrid.Height == 0 )
            {
                return;
            }

            Pen red = new Pen(Color.Red);
            int drawBeginX = rcGrid.Left / m_drawBox.RealCellWidth;
            int drawEndX = rcGrid.Right / m_drawBox.RealCellWidth + ((rcGrid.Right % m_drawBox.RealCellWidth != 0) ? 1:0 );
            int drawBeginY = rcGrid.Top / m_drawBox.RealCellHeight;
            int drawEndY = rcGrid.Bottom / m_drawBox.RealCellHeight + ((rcGrid.Height % m_drawBox.RealCellHeight != 0) ? 1 : 0);

            int drawX = 0;
            int drawY = 0;

            Rectangle rcClip = rcGrid;
            rcClip.Offset(m_drawBox.m_drawBoxPos);
            rcClip.Width += 1;
            rcClip.Height += 1;
            g.SetClip(rcClip);
            
            
            // 绘制横向的
            for (int y = drawBeginY; y <= drawEndY; y++)
            {
                drawY = y * m_drawBox.RealCellHeight;
                Point pointA = new Point(0 +  m_drawBox.DrawBoxX, drawY + m_drawBox.DrawBoxY);
                Point pointB = new Point( drawEndX * m_drawBox.RealCellWidth + m_drawBox.DrawBoxX, drawY +  m_drawBox.DrawBoxY);
                g.DrawLine( red, pointA, pointB);

            }


            for (int x =  drawBeginX; x <= drawEndX; x++ )
            {
                drawX = x * m_drawBox.RealCellWidth;
                Point pointA = new Point(drawX + m_drawBox.DrawBoxX, m_drawBox.DrawBoxY);
                Point pointB = new Point(drawX + m_drawBox.DrawBoxX, drawEndY * m_drawBox.RealCellHeight + m_drawBox.DrawBoxY);

                g.DrawLine(red, pointA, pointB);

            }

            Pen white = new Pen(Color.White);
            Rectangle rcSel = new Rectangle(m_sel.X * m_drawBox.RealCellWidth + m_drawBox.DrawBoxX, m_sel.Y * m_drawBox.RealCellHeight + m_drawBox.DrawBoxY, m_drawBox.RealCellWidth, m_drawBox.RealCellHeight);
            // 绘制选择的框
            g.DrawRectangle(white, rcSel);
        }

        private void drawBackLimit(Graphics g, bool isDraw)
        {
            if (!isDraw || this.m_drawBox == null)
            {
                return;
            }

            // 相对于格子
            Rectangle rcGrid = new Rectangle(0, 0, m_drawBox.MapWidth, m_drawBox.MapHeight);
            rcGrid.Intersect(new Rectangle(-m_drawBox.DrawBoxX, -m_drawBox.DrawBoxY, this.Width, this.Height));

            if (rcGrid.Width == 0 && rcGrid.Height == 0)
            {
                return;
            }

            Brush brush = new SolidBrush(Color.FromArgb(100, Color.Blue));
            int drawBeginX = rcGrid.Left / m_drawBox.RealCellWidth;
            int drawEndX = rcGrid.Right / m_drawBox.RealCellWidth + ((rcGrid.Right % m_drawBox.RealCellWidth != 0) ? 1 : 0);
            int drawBeginY = rcGrid.Top / m_drawBox.RealCellHeight;
            int drawEndY = rcGrid.Bottom / m_drawBox.RealCellHeight + ((rcGrid.Height % m_drawBox.RealCellHeight != 0) ? 1 : 0);

            Rectangle rcClip = rcGrid;
            rcClip.Offset(m_drawBox.m_drawBoxPos);
            g.SetClip(rcClip);


            // 相对于与m_drawBoxPos所在的块
            CellInfo[,] M2CellInfo = this.m_drawBox.m_map.MapCells;
            int drawX = m_drawBoxPos.X;
            int drawY = m_drawBoxPos.Y;
            for (int y = drawBeginY; y < drawEndY; y++)
            {
                if (y >= m_drawBox.MapHeightNum || y < 0) continue; ;
                drawY = y * m_drawBox.RealCellHeight + m_drawBoxPos.Y;
                for (int x = drawBeginX; x < drawEndX; x++)
                {
                    if (x >= m_drawBox.MapWidthNum || x < 0) continue;

                    drawX = x * m_drawBox.RealCellWidth + m_drawBoxPos.X;

                    if ( ( M2CellInfo[x, y].BackImage & 0x20000000) != 0 )
                    {
                        g.FillRectangle(brush, new Rectangle(drawX, drawY, m_drawBox.RealCellWidth, m_drawBox.RealCellHeight));
                    }
                }
            }
        }

        private void drawFrontLimit(Graphics g, bool isDraw)
        {
            if (!isDraw || this.m_drawBox == null)
            {
                return;
            }

            // 相对于格子
            Rectangle rcGrid = new Rectangle(0, 0, m_drawBox.MapWidth, m_drawBox.MapHeight);
            rcGrid.Intersect(new Rectangle(-m_drawBox.DrawBoxX, -m_drawBox.DrawBoxY, this.Width, this.Height));

            if (rcGrid.Width == 0 && rcGrid.Height == 0)
            {
                return;
            }

            Brush brush = new SolidBrush(Color.FromArgb(100, Color.Red));
            int drawBeginX = rcGrid.Left / m_drawBox.RealCellWidth;
            int drawEndX = rcGrid.Right / m_drawBox.RealCellWidth + ((rcGrid.Right % m_drawBox.RealCellWidth != 0) ? 1 : 0);
            int drawBeginY = rcGrid.Top / m_drawBox.RealCellHeight;
            int drawEndY = rcGrid.Bottom / m_drawBox.RealCellHeight + ((rcGrid.Height % m_drawBox.RealCellHeight != 0) ? 1 : 0);

            Rectangle rcClip = rcGrid;
            rcClip.Offset(m_drawBox.m_drawBoxPos);
            g.SetClip(rcClip);


            // 相对于与m_drawBoxPos所在的块
            CellInfo[,] M2CellInfo = this.m_drawBox.m_map.MapCells;
            int drawX = m_drawBoxPos.X;
            int drawY = m_drawBoxPos.Y;
            for (int y = drawBeginY; y < drawEndY; y++)
            {
                if (y >= m_drawBox.MapHeightNum || y < 0) continue; ;
                drawY = y * m_drawBox.RealCellHeight + m_drawBoxPos.Y;
                for (int x = drawBeginX; x < drawEndX; x++)
                {
                    if (x >= m_drawBox.MapWidthNum || x < 0) continue;

                    drawX = x * m_drawBox.RealCellWidth + m_drawBoxPos.X;

                    if ((M2CellInfo[x, y].FrontImage & 0x8000) != 0)
                    {
                        g.FillRectangle(brush, new Rectangle(drawX, drawY, m_drawBox.RealCellWidth, m_drawBox.RealCellHeight));
                    }
                }
            }
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {

            if (this.m_drawBox == null)
            {
                return;
            }

            
            if( m_drawBoxPos != m_drawBox.m_drawBoxPos )
            {
                m_drawBox.setDrawBoxPos( m_drawBoxPos.X, m_drawBoxPos.Y );
            } 

            if (m_drawBox.Width != this.Width || m_drawBox.Height != this.Height)
            {
                m_drawBox.setSize(this.Width, this.Height);
            }

            if (ScaleDelta != m_drawBox.ScaleDelta)
            {
                m_drawBox.setScaleDelta(ScaleDelta);
            }

            Graphics g = e.Graphics;
            g.DrawImage(m_drawBox.m_bmp, 0, 0);

            drawBackLimit(g, m_isDrawBackLimit);
            drawFrontLimit(g, m_isDrawFrontLimit);
            drawGrids(g, m_isDrawGrid);


        }

        private void DrawPanel_Load(object sender, EventArgs e)
        {

            this.MouseWheel += new MouseEventHandler( DrawPanel_MouseWheel );
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);    // 不擦除背景
            this.SetStyle(ControlStyles.UserPaint, true);               // 使用自定义重绘
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);   // 双缓冲
            this.UpdateStyles();
        }

        private void DrawPanel_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void DrawPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // e.Delta
            if( m_drawBox != null )
            {
                ScaleDelta = ScaleDelta + e.Delta;
                this.Invalidate();
            }
            
        }


        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if( m_drawBox == null )
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                //System.Diagnostics.Trace.WriteLine("MOUSEDOWN");
                m_isMouseDown = true;
                m_mousePos = new Point(e.X, e.Y);
                m_drawBoxMousePos = m_drawBoxPos;
            }

        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if( m_drawBox == null )
            {
                return;
            }

            if ( m_isMouseDown )
            {
                m_drawBoxPos.X = e.X - m_mousePos.X + m_drawBoxMousePos.X;
                m_drawBoxPos.Y = e.Y - m_mousePos.Y + m_drawBoxMousePos.Y;
                this.Invalidate();
            }
            else
            {
                Point sel = new Point((e.X - m_drawBox.DrawBoxX) / m_drawBox.RealCellWidth, (e.Y - m_drawBox.DrawBoxY) / m_drawBox.RealCellHeight);
                if( sel.X < 0 ) sel.X = 0;
                if (sel.X >= m_drawBox.MapWidthNum - 1) sel.X = m_drawBox.MapWidthNum - 1;
                if (sel.Y < 0) sel.Y = 0;
                if (sel.Y >= m_drawBox.MapHeightNum - 1) sel.Y = m_drawBox.MapHeightNum - 1;

                if( sel != m_sel )
                {
                    m_sel = sel;

                    this.onSelChanged();
                    this.Invalidate();
                }
            }

        }

        public void onSelChanged()
        {
            MainForm.s_instance.onSelChanged( m_sel );
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                m_isMouseDown = false;
            }
        }


        public void redrawBmp()
        {
            if( this.m_drawBox == null )
            {
                return;
            }
            this.m_drawBox.redraw();
            this.Invalidate();
        }

        public void resetPos()
        {
            this.m_drawBoxPos = new Point(0, 0);
            this.Invalidate();
        }

        public void resetScaleDelta()
        {
            this.ScaleDelta = 12000;
            this.Invalidate();
        }

        public void setDrawBack(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_drawBox.m_isDrawBack = isDraw;
            this.m_drawBox.redraw();
            this.Invalidate();
        }

        public void setDrawMiddle(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_drawBox.m_isDrawMiddle = isDraw;
            this.m_drawBox.redraw();
            this.Invalidate();
        }

        public void setDrawFront(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_drawBox.m_isDrawFront = isDraw;
            this.m_drawBox.redraw();
            this.Invalidate();
        }

        public void setDrawGrid(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_isDrawGrid = isDraw;
            this.Invalidate();
        }

        public void setDrawFrontLimit(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_isDrawFrontLimit = isDraw;
            this.Invalidate();
        }

        public void setDrawBackLimit(bool isDraw)
        {
            if (this.m_drawBox == null)
            {
                return;
            }
            this.m_isDrawBackLimit = isDraw;
            this.Invalidate();
        }

        public CellInfo getCellInfo(Point pt)
        {
            if( this.m_drawBox == null )
            {
                return null;
            }

            int y = pt.Y;
            int x = pt.X;

            if (y >= m_drawBox.MapHeightNum || y < 0)
            {
                return null;
            }

            if (x >= m_drawBox.MapWidthNum || x < 0)
            {
                return null;
            }

            return m_drawBox.m_map.MapCells[x, y];
        }


    }


    public class DrawBox
    {
        // 缩放大小，为整数
        public static int SCALE_DELTA = 12000;

        // 绘制一块时需要额外读取的区域
        public const int MAX_DRAW_ADD = 36;
        public const int MAX_DRAW_DEL = 1;

        public int ScaleDelta = SCALE_DELTA;

        public const int CellWidth = 48;
        public const int CellHeight = 32;
        // 地图文件
        public MapReader m_map = null;
        // 所在绘制框在整个的偏移
        public Point m_drawBoxPos = new Point(0, 0);

        // 用于绘制的BMP,
        public Bitmap m_bmp;

        // 是否绘制背面
        public bool m_isDrawBack = true;
        // 是否绘制中间
        public bool m_isDrawMiddle = true;
        // 是否绘制前面
        public bool m_isDrawFront = true;

        public int Width
        {
            get
            {
                if (m_bmp != null)
                {
                    return m_bmp.Width;
                }
                return 0;
            }
        }
        public int Height
        {
            get
            {
                if (m_bmp != null)
                {
                    return m_bmp.Height;
                }
                return 0;
            }
        }

        public int MapWidthNum
        {
            get
            {
                return m_map.Width;
            }
        }

        public int MapHeightNum
        {
            get
            {
                return m_map.Height;
            }
        }

        public int MapWidth
        {
            get
            {
                return MapWidthNum * RealCellWidth;
            }
        }

        public int MapHeight
        {
            get
            {
                return MapHeightNum * RealCellHeight;
            }
        }

        // 被缩放以后的大小
        public int RealCellWidth
        {
            get
            {

                return CellWidth * ScaleDelta / SCALE_DELTA;
            }
        }

        public int RealCellHeight
        {
            get
            {
                return CellHeight * ScaleDelta / SCALE_DELTA;
            }
        }

        public int DrawBoxX
        {
            get
            {
                return m_drawBoxPos.X;
            }
        }

        public int DrawBoxY
        {
            get
            {
                return m_drawBoxPos.Y;
            }
        }

        // 构造一个分块绘制的BOX
        public DrawBox(string filePath, int w, int h)
        {
            open(filePath, w, h);
        }

        public void open(string filePath, int w, int h)
        {
            if (w <= 0) { w = 1; }
            if (h <= 0) { h = 1; }
            this.m_map = new MapReader(filePath);
            this.m_bmp = new Bitmap(w, h);
            drawRange(new Rectangle(0, 0, w, h));
        }

        public void redraw()
        {
            drawRange(new Rectangle(0, 0, this.Width, this.Height));
        }
        /*
        public bool[,] pointCell;
        public void createPointCell()
        {
            pointCell = new bool[this.Width, this.Height];
            for(int x=0; x<this.Width; x++)
            {
                for(int y=0; y<this.Height; y++ )
                {
                    pointCell[x, y] = false;
                }
            }
        }

        public bool isPointCellFull()
        {
            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    if( pointCell[x, y] == false)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        public void setPointCell(Rectangle dst)
        {
            if( null == pointCell )
            {
                return;

            }
            for (int x = dst.X; x < dst.Right; x++)
            {
                for (int y = dst.Y; y < dst.Bottom; y++)
                {
                    pointCell[x, y] = true;
                }
            }
        }
        */

        // 绘制不相交区域
        private void drawNonintersectRange(Rectangle dst)
        {
            // 有相交
            if (dst.Width > 0 && dst.Height > 0)
            {
                // 绘剩下的部分
                // 绘制多余的地方看看横线的在上面还是在下面
                if (dst.Y > 0)
                {
                    // 绘制上面和左边的
                    drawRange(new Rectangle(0, 0, this.Width, dst.Y));
                    
                    // 剩余区域
                    if (dst.X > 0)
                    {
                        // 剩余左边
                        drawRange(new Rectangle(0, dst.Y, dst.X, this.Height - dst.Y));
                    }
                    else if (this.Width > dst.Right )
                    {
                        // 剩余右边
                        drawRange(new Rectangle(dst.Right, dst.Y, this.Width - dst.Right, this.Height - dst.Y));
                    }

                }
                else if (this.Height >  dst.Bottom )
                {

                    drawRange(new Rectangle(0, dst.Bottom, this.Width, this.Height - dst.Bottom));
                    if (dst.X > 0)
                    {
                        // 剩余左边
                        drawRange(new Rectangle(0, 0, dst.X, dst.Bottom));
                    }
                    else if (this.Width > dst.Right )
                    {
                        // 剩余右边
                        drawRange(new Rectangle(dst.Right, 0, this.Width - dst.Right, dst.Bottom));
                    }
                }
                else if( ! ( dst.X == 0 && dst.Y == 0 && this.Height == dst.Height && this.Width == dst.Width) )
                {
                    // 横向折叠
                    if (dst.X > 0)
                    {
                        // 剩余左边
                        drawRange(new Rectangle(0, 0, dst.X, this.Height));
                    }
                    else if (this.Width > dst.Right )
                    {
                        // 剩余右边
                        drawRange(new Rectangle(dst.Right, 0, this.Width - dst.Right, this.Height));
                    }
                }

            }
            else
            {
                // 没有相交，直接绘制
                drawRange(new Rectangle(0, 0, this.Width, this.Height));
            }
        }

        

        // 设置初始点的偏移
        public void setDrawBoxPos(int x, int y)
        {
            if (m_drawBoxPos.X == x && m_drawBoxPos.Y == y)
            {
                return;
            }
            // 这里使用滚轴算法
            Rectangle dst = new Rectangle(0, 0, this.Width, this.Height);
            Rectangle src = dst;

            int offsetX = x - this.m_drawBoxPos.X;
            int offsetY = y - this.m_drawBoxPos.Y;
            src.Offset( offsetX, offsetY);
            dst.Intersect(src);

            this.m_drawBoxPos.X = x;
            this.m_drawBoxPos.Y = y;


            // createPointCell();

            if (dst.Width > 0 && dst.Height > 0)
            {
                // 拷贝原来的位置
                src = dst;
                src.Offset(-offsetX, -offsetY);

                Graphics g = Graphics.FromImage(m_bmp);
                g.SetClip(dst);

                // System.Diagnostics.Trace.WriteLine("begin copyRange dst=" + dst.ToString() + "src="+ src.ToString());
                // setPointCell(dst);

                g.DrawImage(this.m_bmp, dst, src, GraphicsUnit.Pixel);
                g.Dispose();
            }

            this.drawNonintersectRange(dst);

            /*
            System.Diagnostics.Trace.WriteLine("end copyRange");
            if( !isPointCellFull() )
            {
                System.Diagnostics.Trace.WriteLine("没填满");

            }
            */

            

        }

        public void setSize(int w, int h)
        {
            if (w <= 0) { w = 1; }
            if (h <= 0) { h = 1; }

            if (w != this.Width || h != this.Height)
            {
                Bitmap newBmp = new Bitmap(w, h);

                // 这里使用缩放算法
                Rectangle dst = new Rectangle(0, 0, w, h);
                Rectangle src = new Rectangle(0, 0, Width, Height);
                dst.Intersect(src);

                // 有相交
                if (dst.Width > 0 && dst.Height > 0)
                {
                    // 拷贝原来的位置
                    Graphics g = Graphics.FromImage(newBmp);
                    g.DrawImage(this.m_bmp, dst.X, dst.Y, dst, GraphicsUnit.Pixel);
                    g.Dispose();
                    this.m_bmp = newBmp;
                }

                this.drawNonintersectRange(dst);
            }

        }

        public void setScaleDelta(int delta)
        {
            ScaleDelta = delta;
            if (ScaleDelta < SCALE_DELTA / 10) ScaleDelta = SCALE_DELTA / 10;
            if (ScaleDelta > SCALE_DELTA * 10) ScaleDelta = SCALE_DELTA * 10;
            drawRange(new Rectangle(0, 0, this.Width, this.Height));
        }


        public void drawRange(Rectangle rc)
        {
            // setPointCell( rc );
            // System.Diagnostics.Trace.WriteLine("drawRange" + rc.ToString());
            if (m_bmp == null)
            {
                return;
            }
            Graphics g = Graphics.FromImage(m_bmp);
            g.SetClip(rc);
            g.Clear(SystemColors.Control);
            Rectangle rcBackgroud = rc;
            rcBackgroud.Intersect(new Rectangle(m_drawBoxPos.X, m_drawBoxPos.Y, m_map.Width * RealCellWidth, m_map.Height * RealCellHeight));
            if (rcBackgroud.Width > 0 && rc.Height > 0)
            {
                g.FillRectangle(new SolidBrush(Color.Black), rcBackgroud);
                g.SetClip(rcBackgroud);
                drawBack(g, rc, m_isDrawBack);
                drawMiddle(g, rc, m_isDrawMiddle);
                drawFront(g, rc, m_isDrawFront);
            }

            g.Dispose();
        }

        // 绘制背后区域
        void drawBack(Graphics g, Rectangle rc, bool isDraw)
        {
            if (!isDraw || this.m_map == null)
            {
                return;
            }

            // 相对于与m_drawBoxPos所在的块
            rc.Offset(m_drawBoxPos.X * -1, m_drawBoxPos.Y * -1);
            rc.Intersect(new Rectangle(0, 0, m_map.Width * RealCellWidth, m_map.Height * RealCellHeight));
            // 计算左边
            int drawBeginX = rc.Left / RealCellWidth;
            int drawBeginY = rc.Top / RealCellHeight;
            // 计算右边
            int drawEndX = rc.Right / RealCellWidth + ((rc.Right % RealCellWidth != 0) ? 1 : 0);
            int drawEndY = rc.Bottom / RealCellHeight + ((rc.Bottom % RealCellHeight != 0) ? 1 : 0);


            CellInfo[,] M2CellInfo = this.m_map.MapCells;
            int index;
            int libIndex;
            int drawX = m_drawBoxPos.X;
            int drawY = m_drawBoxPos.Y;
            for (int y = drawBeginY - MAX_DRAW_DEL; y < drawEndY; y++)
            {
                if (y % 2 != 0) continue;
                if (y >= m_map.Height || y < 0) continue; ;
                drawY = y * RealCellHeight + m_drawBoxPos.Y;
                for (int x = drawBeginX - MAX_DRAW_DEL; x < drawEndX; x++)
                {
                    if (x % 2 != 0) continue;
                    if (x >= m_map.Width || x < 0) continue;

                    drawX = x * RealCellWidth + m_drawBoxPos.X;
                    index = (M2CellInfo[x, y].BackImage & 0x1FFFFFFF) - 1;
                    libIndex = M2CellInfo[x, y].BackIndex;

                    if (libIndex < 0 || libIndex >= Libraries.MapLibs.Length || Libraries.MapLibs[libIndex]._images == null) continue;
                    if (index < 0 || index >= Libraries.MapLibs[libIndex]._images.Count) continue;

                    s_draw(g, libIndex, index, drawX, drawY, ScaleDelta);
                }
            }
        }

        // 绘制中间区域
        void drawMiddle(Graphics g, Rectangle rc, bool isDraw)
        {
            if (!isDraw || this.m_map == null)
            {
                return;
            }

            // 相对于与m_drawBoxPos所在的块
            rc.Offset(m_drawBoxPos.X * -1, m_drawBoxPos.Y * -1);
            rc.Intersect(new Rectangle(0, 0, m_map.Width * RealCellWidth, m_map.Height * RealCellHeight));
            // 计算左边
            int drawBeginX = rc.Left / RealCellWidth;
            int drawBeginY = rc.Top / RealCellHeight;
            // 计算右边
            int drawEndX = rc.Right / RealCellWidth + ((rc.Right % RealCellWidth != 0) ? 1 : 0);
            int drawEndY = rc.Bottom / RealCellHeight + ((rc.Bottom % RealCellHeight != 0) ? 1 : 0);

            CellInfo[,] M2CellInfo = this.m_map.MapCells;
            int index;
            int libIndex;
            int drawX = 0;
            int drawY = 0;
            int AnimationCount = 0;

            byte animation;
            //bool blend = false;
            for (int y = drawBeginY - MAX_DRAW_DEL; y < drawEndY + MAX_DRAW_ADD; y++)
            {
                if (y >= m_map.Height || y < 0) continue;

                for (int x = drawBeginX - MAX_DRAW_DEL; x < drawEndX + MAX_DRAW_ADD; x++)
                {
                    if (x >= m_map.Width || x < 0) continue;

                    drawX = x * RealCellWidth + m_drawBoxPos.X;

                    index = M2CellInfo[x, y].MiddleImage - 1;
                    libIndex = M2CellInfo[x, y].MiddleIndex;

                    if (libIndex < 0 || libIndex >= Libraries.MapLibs.Length || Libraries.MapLibs[libIndex]._images == null) continue;
                    if (index < 0 || index >= Libraries.MapLibs[libIndex]._images.Count) continue;

                    animation = M2CellInfo[x, y].MiddleAnimationFrame;
                    //blend = false;
                    if ((animation > 0) && (animation < 255))
                    {
                        if ((animation & 0x0f) > 0)
                        {
                            //blend = true;
                            animation &= 0x0f;
                        }
                        if (animation > 0)
                        {
                            var animationTick = M2CellInfo[x, y].MiddleAnimationTick;
                            index += AnimationCount % (animation + animation * animationTick) / (1 + animationTick);
                        }
                    }

                    var s = Libraries.MapLibs[libIndex].GetSize(index);
                    if ((s.Width != CellWidth || s.Height != CellHeight) &&
                        (s.Width != CellWidth * 2 || s.Height != CellHeight * 2))
                    {
                        drawY = (y + 1) * RealCellHeight + m_drawBoxPos.Y;
                        s_draw(g, libIndex, index, drawX, drawY - s.Height * ScaleDelta / SCALE_DELTA, ScaleDelta);
                    }
                    else
                    {
                        drawY = y * RealCellHeight + m_drawBoxPos.Y;
                        s_draw(g, libIndex, index, drawX, drawY, ScaleDelta);
                    }
                }
            }
        }

        // 绘制前面区域
        void drawFront(Graphics g, Rectangle rc, bool isDraw)
        {
            if (!isDraw || this.m_map == null)
            {
                return;
            }

            // 相对于与m_drawBoxPos所在的块
            rc.Offset(m_drawBoxPos.X * -1, m_drawBoxPos.Y * -1);
            rc.Intersect(new Rectangle(0, 0, m_map.Width * RealCellWidth, m_map.Height * RealCellHeight));
            // 计算左边
            int drawBeginX = rc.Left / RealCellWidth;
            int drawBeginY = rc.Top / RealCellHeight;
            // 计算右边
            int drawEndX = rc.Right / RealCellWidth + ((rc.Right % RealCellWidth != 0) ? 1 : 0);
            int drawEndY = rc.Bottom / RealCellHeight + ((rc.Bottom % RealCellHeight != 0) ? 1 : 0);


            CellInfo[,] M2CellInfo = this.m_map.MapCells;
            int index;
            int libIndex;
            byte animation;
            bool blend;

            int drawX = 0;
            int drawY = 0;
            int AnimationCount = 0;

            for (int y = drawBeginY - MAX_DRAW_DEL; y < drawEndY + MAX_DRAW_ADD; y++)
            {
                if (y >= m_map.Height || y < 0) continue;

                for (int x = drawBeginX - MAX_DRAW_DEL; x < drawEndX + MAX_DRAW_ADD; x++)
                {
                    if (x >= m_map.Width || x < 0) continue;


                    index = (M2CellInfo[x, y].FrontImage & 0x7FFF) - 1;
                    libIndex = M2CellInfo[x, y].FrontIndex;

                    if (libIndex < 0 || libIndex >= Libraries.MapLibs.Length || Libraries.MapLibs[libIndex]._images == null) continue;
                    if (index < 0 || index >= Libraries.MapLibs[libIndex]._images.Count) continue;


                    drawX = x * RealCellWidth + m_drawBoxPos.X;

                    animation = M2CellInfo[x, y].FrontAnimationFrame;
                    if ((animation & 0x80) > 0)
                    {
                        blend = true;
                        animation &= 0x7F;
                    }
                    else
                    {
                        blend = false;
                    }

                    if (animation > 0)
                    {
                        var animationTick = M2CellInfo[x, y].FrontAnimationTick;
                        index += AnimationCount % (animation + animation * animationTick) / (1 + animationTick);
                    }

                    var doorOffset = M2CellInfo[x, y].DoorOffset;
                    var s = Libraries.MapLibs[libIndex].GetSize(index);
                    //不是 48*32 或96*64 的地砖 是大物体
                    if ((s.Width != CellWidth || s.Height != CellHeight)
                        &&
                        (s.Width != CellWidth * 2 || s.Height != CellHeight * 2))
                    {
                        drawY = (y + 1) * RealCellHeight + m_drawBoxPos.Y;
                        //如果有动画
                        if (animation > 0)
                        {
                            //如果需要混合
                            if (blend)
                            {
                                //新盛大地图
                                if ((libIndex > 99) & (libIndex < 199))
                                {
                                    s_drawBlend(g, libIndex, index, drawX, drawY - 3 * RealCellHeight, ScaleDelta);
                                }
                                //老地图灯柱 index >= 2723 && index <= 2732
                                else
                                {
                                    s_drawBlend(g, libIndex, index, drawX, drawY - s.Height * ScaleDelta / SCALE_DELTA, ScaleDelta);
                                }
                            }
                            //不需要混合
                            else
                            {
                                s_draw(g, libIndex, index, drawX, drawY - s.Height * ScaleDelta / SCALE_DELTA, ScaleDelta);
                            }
                        }
                        //如果没动画 
                        else
                        {
                            s_draw(g, libIndex, index, drawX, drawY - s.Height * ScaleDelta / SCALE_DELTA, ScaleDelta);
                        }
                    }
                    //是 48*32 或96*64 的地砖
                    else
                    {
                        drawY = y * RealCellHeight + m_drawBoxPos.Y;
                        s_draw(g, libIndex, index, drawX, drawY, ScaleDelta);
                    }

                    
                    // 显示门打开
                    if ((doorOffset > 0))
                    {
                        drawY = (y + 1) * RealCellHeight + m_drawBoxPos.Y;
                        s_draw(g, libIndex, index + doorOffset, drawX, drawY - s.Height * ScaleDelta / SCALE_DELTA, ScaleDelta);
                    }
                    
                }
            }
        }



        // 内部绘制函数, 绘制和缩放绘制
        public static void s_draw(Graphics g, int libIndex, int index, int drawX, int drawY, int delta)
        {
            Libraries.MapLibs[libIndex].CheckImage(index);
            MImage mi = Libraries.MapLibs[libIndex]._images[index];
            if (mi.Image != null)
            {
                int x = drawX;
                int y = drawY;
                if (delta == SCALE_DELTA)
                {
                    g.DrawImage(mi.Image, x, y);
                }
                else
                {
                    Rectangle rcDest = new Rectangle(x, y, mi.Image.Width * delta / SCALE_DELTA, mi.Image.Height * delta / SCALE_DELTA);
                    Rectangle rcSrc = new Rectangle(0, 0, mi.Image.Width, mi.Image.Height);
                    // g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half ;
                    // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.DrawImage(mi.Image, rcDest, rcSrc, GraphicsUnit.Pixel);
                }
            }

        }

        // 内部绘制函数，透明绘制和缩放绘制
        private static void s_drawBlend(Graphics g, int libIndex, int index, int drawX, int drawY, int delta)
        {
            s_draw(g, libIndex, index, drawX, drawY, delta);
        }


        
    }

}
