
using KamenMessage.RunTime.Service;
using KamenMessage.RunTime.Service.RunTime.Basic.Controller;
using UnityEngine;

namespace Game.Controller
{
    public class BattleRoundEndController : AutoController<BattleRoundEndDto>
    {
        public override void Handle(BattleRoundEndDto msg)
        {
            Debug.LogError("Controller DoSomething");
        }
    }
}