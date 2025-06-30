namespace TRexGame.Engine.Entities
{
    public interface IGameComponent
    {
        public GameEntity MyGameEntity { get; set; }

        public void InitializeComponent();
    }
}
