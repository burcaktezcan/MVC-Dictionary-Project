using DataAccessLayer.Repositories;

namespace MvcDictionary.Helpers
{
    public class Repositoryfactory
    {
        static WordRepositoryJson _repoWord;
        public static IRepositoryWord CreateRepo(string tip)
        {
            if (_repoWord == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        _repoWord = new WordRepositoryJson();
                    }
                    return _repoWord;
                }
                else

                    return null;
            }
            else
                return _repoWord;
        }
    }
}
