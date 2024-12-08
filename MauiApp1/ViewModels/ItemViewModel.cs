namespace MauiApp1.ViewModels;

public class ItemViewModel
{
    public ItemViewModel(
        string name,
        string description,
        string image,
        bool isLocked)
    {
        Name = name;
        Description = description;
        Thumbnail = ImageSource.FromFile($"../Images/{image}_icon.png");
        Photo = ImageSource.FromFile($"../Images/{image}.png");
        IsLocked = isLocked;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public ImageSource Thumbnail { get; private set; }
    public ImageSource Photo { get; private set; }
    public bool IsLocked { get; private set; }
}