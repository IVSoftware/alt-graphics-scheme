Your question is whether there's another way to use `Graphics.DrawImage` in order to draw the entire screen quickly enough to serve as an animation. One "other way" would be to invoke it _indirectly_ by detecting changes to the `myBool` property and modifying the `BackgroundImage` property of the main form in response to that. If `myBool` is true, the animation consists of iterating an array of images using `BeginInvoke` so that at least the UI thread will only be blocked during individual frame draws not the entire animation.

This would avoid any potential circularity that might be occurring in the `Paint` event handler as it is coded now.

When I tested this approach it seemed pretty zippy, but you may have to actually [clone]() my sample to see whether it's fast enough for your application.

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