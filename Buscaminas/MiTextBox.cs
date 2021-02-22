using System.Windows.Forms;

namespace Buscaminas
{
  
        class MiTextBox : TextBox
        {
            public int i { get; set; }
            public int j { get; set; }

            public MiTextBox(int i, int j)
            {
                this.i = i;
                this.j = j;

            }
        
    }
}
