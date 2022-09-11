using System.Windows.Media.Imaging;
using WpfMath;

namespace Meg.Core.Presentations.Latex
{
    public class LatexFileRenderer
    {
        private const string Font = "Consolas";
        private const double FontSize = 20.0;
        private const double ImageDpi = 192.0;

        public LatexFileRenderer(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath));
            }

            FilePath = filePath;
        }

        public string FilePath { get; }

        public void WriteToFile(string latex)
        {
            if (string.IsNullOrWhiteSpace(latex))
            {
                throw new ArgumentException($"'{nameof(latex)}' cannot be null or whitespace.", nameof(latex));
            }

            WriteToFileInternal(latex);
        }

        private static string ApplyLatexCommands(string latex) => @$"\colorbox[rgb]{{1,1,1}}{{{latex}}}";

        private void WriteToFileInternal(string latex)
        {
            latex = ApplyLatexCommands(latex);

            var parser = new TexFormulaParser();
            var parsedLatex = parser.Parse(latex);
            var renderer = parsedLatex.GetRenderer(TexStyle.Display, FontSize, Font);
            var bitmap = renderer.RenderToBitmap(0.0, 0.0, ImageDpi);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using var stream = new FileStream(FilePath, FileMode.Create);
            encoder.Save(stream);
        }
    }
}
