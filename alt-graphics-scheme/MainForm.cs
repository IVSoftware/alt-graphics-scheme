using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alt_graphics_scheme
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true; // Smoother if true but compare performance with/without.
            var dir = 
                Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Backgrounds");

            _backgrounds =
                Directory
                .GetFiles(dir)
                .Select(_ => (Bitmap)Bitmap.FromFile(_))
                .ToArray();
            BackgroundImage = _backgrounds[0];
            checkBoxMyBool.CheckedChanged += (sender, e) => myBool = checkBoxMyBool.Checked;
        }
        private readonly Bitmap[] _backgrounds;
        public bool myBool
        {
            get => _myBool;
            set
            {
                if (!Equals(_myBool, value))
                {
                    _myBool = value;
                    _ = onMyBoolChanged();
                }
            }
        }
        bool _myBool = false;
        private async Task onMyBoolChanged()
        {
            if(myBool)
            {
                for (int i = 1; i < _backgrounds.Length; i++)
                {
                    BackgroundImage = _backgrounds[i];
                    await Task.Delay(100);
                }
            }
            else
            {
                BackgroundImage = _backgrounds[0];
            }
        }
    }
}
