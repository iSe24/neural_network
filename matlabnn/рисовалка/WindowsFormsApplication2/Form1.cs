using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;



public class frmScribble : System.Windows.Forms.Form
{
  private System.ComponentModel.Container components = null;
  private bool mouseDown = false;
  private Point lastPoint = Point.Empty;
  private string color = "white";
  private Graphics g;
  private Pen p;
  private GraphicsState gSaved;

    public frmScribble()
  {
        
        g = CreateGraphics();
        p = new Pen(Color.FromName(color));
        p.Width = 20;
  }
  protected override void OnMouseDown(MouseEventArgs e)
  {
        
    
    if (e.Button == MouseButtons.Right)
    {
            
      ContextMenu m = new ContextMenu();
      m.MenuItems.Add(0, new MenuItem("Подготовить к работе", new EventHandler(Get_ready)));
      m.MenuItems.Add(1, new MenuItem("Выгружаем", new EventHandler(Upload_this)));
      
      m.Show(this, new Point(e.X, e.Y));
    } 
    else
        {
            mouseDown = true;
        }
  }
  protected void Get_ready(object sender, EventArgs e)
   {
        g.Clear(Color.Black);
   }
  protected void Upload_this(object sender, EventArgs e)
  {
        Bitmap b = new Bitmap(this.Size.Width, this.Size.Height);
        Graphics g = Graphics.FromImage(b);
        g.CopyFromScreen(this.Location, new Point(0, 0), this.Size);
       
        Rectangle r = new Rectangle(8,31,280,260);
        Bitmap nb = new Bitmap(r.Width, r.Height);
        Graphics g1 = Graphics.FromImage(nb);
        g1.DrawImage(b, -r.X, -r.Y);
     
        Bitmap nb1 = new Bitmap(Image.FromHbitmap(nb.GetHbitmap()),16,16);
        nb1.Save("a2s.bmp");
        
        
    }
  

    protected override void OnMouseUp(MouseEventArgs e)
  {
    mouseDown = false;
  }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        Bitmap region = new Bitmap(320, 320);
        

            if (lastPoint.Equals(Point.Empty)) lastPoint = new Point(e.X, e.Y);
            if (mouseDown)
            {
                Point pMousePos = new Point(e.X, e.Y);
                g.DrawLine(p, pMousePos, lastPoint);
            }
            lastPoint = new Point(e.X, e.Y);
        
    }
    

  [STAThread]
  static void Main()
  {
    Application.Run(new frmScribble());
  }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // frmScribble
            // 
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.Name = "frmScribble";
            this.ResumeLayout(false);

    }
}