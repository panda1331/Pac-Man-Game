using System.Reflection;

namespace pacman.Logic;

public class GhostDrawer : IGhostDrawing
{
    private readonly Image _image;
    private readonly Image _frightenedImage;
    public GhostDrawer(string normalGhostName, string frightenedGhostImage)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(normalGhostName))
        {
            _image = Image.FromStream(stream);
        }

        using (Stream stream = assembly.GetManifestResourceStream(frightenedGhostImage))
        {
            _frightenedImage = Image.FromStream(stream);
        }
    }
    public void Draw(Graphics g, Ghost ghost, Map map)
    {
        RectangleF rect = new RectangleF(ghost.X, ghost.Y, map.cellSize, map.cellSize);
        if (ghost.CurrentMode == GhostMode.Frightened || ghost.CurrentMode == GhostMode.Eaten)
        {
            g.DrawImage(_frightenedImage, rect);
        }
        else
        {
             g.DrawImage(_image, rect);
        }
    }
}
