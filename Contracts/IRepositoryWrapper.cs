namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ISpHighScoreRepository SpHighScore { get; }
        IMpHighScoreRepository MpHighScore { get; }
        void Save();
    }
}