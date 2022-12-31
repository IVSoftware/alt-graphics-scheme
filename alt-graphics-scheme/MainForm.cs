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
            checkBoxMyBool.CheckedChanged += (sender, e) => MyBool = checkBoxMyBool.Checked;
        }
        bool _myBool = false;
        public bool MyBool
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
        private readonly Bitmap[] _backgrounds;

        private async Task onMyBoolChanged()
        {
            if(MyBool)
            {
                for (int i = 1; i < _backgrounds.Length; i++)
                {
                    var captureImage = _backgrounds[i];
                    BeginInvoke((MethodInvoker)delegate 
                    {
                        BackgroundImage = captureImage;
                    });
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
