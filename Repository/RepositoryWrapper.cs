using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ISpHighScoreRepository _spHighScore;
        private IMpHighScoreRepository _mpHighScore;

        public ISpHighScoreRepository SpHighScore
        {
            get
            {
                if (_spHighScore == null)
                {
                    _spHighScore = new SpHighScoreRepository(_repositoryContext);
                }

                return _spHighScore;
            }
        }

        public IMpHighScoreRepository MpHighScore
        {
            get
            {
                if (_mpHighScore == null)
                {
                    _mpHighScore = new MpHighScoreRepository(_repositoryContext);
                }

                return _mpHighScore;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}