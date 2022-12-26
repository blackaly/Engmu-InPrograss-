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
        Image<Bgra, byte> BlurMask(Bitmap bm, int maskWidth, int maskHeight);
        Image<Gray, byte> SobelMask(Bitmap bm, double thresh, double threshLinking);


    }
}
