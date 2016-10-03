using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirEditor
{
    public partial class InfoForm : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        public void setInfo(Point pt, CellInfo info )
        {
            labelInfo.Text = @"当前位置：" + pt.ToString();
            int libIndexFront = info.FrontIndex;
            int indexFront = (info.FrontImage & 0x7FFF) - 1;
            Image image = getIndexMap(libIndexFront, indexFront);
            this.imageFront.Image = image;
            if( image != null )
            {
                labelFront.Text = @"上层图片大小:" + image.Size.ToString();
                this.imageFront.Size = image.Size;
            }
            else
            {
                labelFront.Text = @"上层没有图片";
            }
            

            
            int libIndexMiddle = info.MiddleIndex;
            int indexMiddle = info.MiddleImage - 1;
            image = getIndexMap(libIndexMiddle, indexMiddle);
            this.imageMiddle.Image = image;
            if (image != null)
            {
                labelMiddle.Text = @"中间图片大小:" + image.Size.ToString();
                this.imageMiddle.Size = image.Size;
            }
            else
            {
                labelMiddle.Text = @"中间没有图片";
            }

            int libIndexBack = info.BackIndex;
            int indexBack = (info.BackImage & 0x1FFFF) - 1;
            image = getIndexMap(libIndexBack, indexBack);
            this.imageBack.Image = image;
            if (image != null)
            {
                labelBack.Text = @"底层图片大小:" + image.Size.ToString();
                this.imageBack.Size = image.Size;
            }
            else
            {
                labelBack.Text = @"底层没有图片";
            }


            byte light = info.Light;

            
        }

        public Bitmap getIndexMap(int libIndex, int index )
        {

            if (libIndex < 0 || libIndex >= Libraries.MapLibs.Length || Libraries.MapLibs[libIndex]._images == null) return null;
            if (index < 0 || index >= Libraries.MapLibs[libIndex]._images.Count) return null;
            Libraries.MapLibs[libIndex].CheckImage(index);
            MImage mi = Libraries.MapLibs[libIndex]._images[index];
            return mi.Image;
            

        }
    }
}
