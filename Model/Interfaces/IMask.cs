using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engmu.Model.Interfaces
{
    public interface IMask
    {
        Image<Bgra, byte> Mask(Bitmap bm, int maskWidth, int maskHeight);

    }
}
