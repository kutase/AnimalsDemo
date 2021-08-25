namespace AnimalsDemo
{
    public interface IScreen
    {
        ScreenType ScreenType { get; }
        
        void Show();
        void Hide();
    }
}
