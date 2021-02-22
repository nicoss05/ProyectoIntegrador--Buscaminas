using System.Windows.Forms;

namespace Buscaminas
{
    class MiButton : Button
    {
        public int i { get; set; }
        public int j { get; set; }

        public MiButton(int i, int j)
        {
            this.i = i;
            this.j = j;

        }
       
    }
}
