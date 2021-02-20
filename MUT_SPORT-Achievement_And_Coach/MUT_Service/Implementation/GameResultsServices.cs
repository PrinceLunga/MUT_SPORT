using MUT_DataAccess.DataContext;
using MUT_DataAccess.DataModels;
using MUT_MODELS;
using MUT_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUT_Service.Implementation
{
    public class GameResultsServices : IGameResultService
    {
        private readonly MUTDbContext mUTDbContext;

        public GameResultsServices(MUTDbContext _mUTDbContext)
        {
            this.mUTDbContext = _mUTDbContext;
        }
        public void AddGameResult(GameResultModel model)
        {
            using (mUTDbContext)
            {
                var gameResult = new GameResult
                {
                    EventDate = DateTime.Now,
                    IsHomeWin = model.IsHomeWin,
                    AwayTeam = model.AwayTeam,
                    EventName = model.EventName,
                    HomeTeam = model.HomeTeam,
                    PointForHomeTeam = model.PointForHomeTeam,
                    PointsForAwayTeam = model.PointsForAwayTeam
                };

                mUTDbContext.Add(gameResult);
                mUTDbContext.SaveChanges();
            }
        }

        public bool GameResultExist(int id)
        {
            using (mUTDbContext)
            {
                var gameResult = mUTDbContext.GameResults.Find(id);

                if (gameResult != null)
                    return true;
                else
                    return false;
            }
        }

        public GameResultModel GetGameResultID(int Id)
        {
            using (mUTDbContext)
            {
                return mUTDbContext.GameResults.Where(x => x.Id == Id)
                    .Select(x => new GameResultModel
                    {
                        EventDate = DateTime.Now,
                        IsHomeWin = x.IsHomeWin,
                        PointForHomeTeam = x.PointForHomeTeam,
                        PointsForAwayTeam = x.PointsForAwayTeam,
                        HomeTeam = x.HomeTeam,
                        EventName = x.EventName,
                        AwayTeam = x.AwayTeam
                    }).SingleOrDefault();
            }
        }

        public List<GameResultModel> GetGameResults()
        {
            using (mUTDbContext)
            {
                return mUTDbContext.GameResults.Select(x => new GameResultModel
                {
                    EventDate = DateTime.Now,
                    IsHomeWin = x.IsHomeWin,
                    PointForHomeTeam = x.PointForHomeTeam,
                    PointsForAwayTeam = x.PointsForAwayTeam,
                    HomeTeam = x.HomeTeam,
                    EventName = x.EventName,
                    AwayTeam = x.AwayTeam
                }).ToList();
            }
        }

        public void UpdateGameResults(GameResultModel gameResultModel)
        {
            using (mUTDbContext)
            {
                var gameResult = mUTDbContext.GameResults.Find(gameResultModel.Id);

                if (gameResult != null)
                {
                    gameResult.EventDate = DateTime.Now;
                    gameResult.EventName = gameResultModel.EventName;
                    gameResult.HomeTeam = gameResultModel.HomeTeam;
                    gameResult.AwayTeam = gameResultModel.AwayTeam;
                    gameResult.PointForHomeTeam = gameResultModel.PointForHomeTeam;
                    gameResult.PointsForAwayTeam = gameResultModel.PointsForAwayTeam;
                    gameResult.IsHomeWin = gameResultModel.IsHomeWin;

                }
                mUTDbContext.GameResults.Add(gameResult);
                mUTDbContext.SaveChanges();
            }
        }

    }
}