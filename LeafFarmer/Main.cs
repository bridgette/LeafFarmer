
using System.Linq;
using System.Windows.Forms;

namespace LeafFarmer
{
    public partial class LeafFarmer : Form
    {
        public LeafFarmer()
        {
            InitializeComponent();
            WindowInformation desktop = WindowsFinder.GetAllWindowsTree();
            WindowInformation leafBlowerWindow = desktop.ChildWindows.Where(w => w.Caption == "Leaf Blower Revolution").First();
            statusLabel.Text += "\nFound Leaf Blower Revolution window!";

            WindowsFinder.SetForegroundWindow(leafBlowerWindow);
            statusLabel.Text += "\nSet Leaf Blower Revolution to foreground!";

            CursorMover.MovePointer(leafBlowerWindow, new RandomMovementGenerator());
            statusLabel.Text += "\nStarting cursor random walk!";
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
    }
}
