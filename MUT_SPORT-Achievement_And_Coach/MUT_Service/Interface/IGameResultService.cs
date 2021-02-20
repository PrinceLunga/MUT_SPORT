using MUT_MODELS;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUT_Service.Interface
{
    public interface IGameResultService
    {
        public void AddGameResult(GameResultModel model);
        public List<GameResultModel> GetGameResults();
        public GameResultModel GetGameResultID(int Id);
        public void UpdateGameResults(GameResultModel gameResultModel);
        bool GameResultExist(int id);
    }
}
