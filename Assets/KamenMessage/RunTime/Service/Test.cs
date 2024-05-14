using System;
using KamenMessage.RunTime.Service.Basic.Message;
using KamenMessage.RunTime.Service.Basic.model;
using UnityEngine;

namespace KamenMessage.RunTime.Service
{
    public class Test : MonoBehaviour
    {
        private Skill001 mSkill001;
        private void Start()
        {
            mSkill001 = new Skill001();
            MessageService.Instance.Register<BattleRoundEndDto>(OnBattleRoundEnd);
        }

        public void OnBattleRoundEnd(BattleRoundEndDto roundEndDto)
        {
            Debug.Log($"Battle Round End RoundId:{roundEndDto.Round}");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                MessageService.Instance.Dispatch(new BattleRoundEndDto() {Round = 2});
            }
        }
    }

    public class Skill001 : ManualModel
    {
        public Skill001()
        {
            EntrustDisposable(Register<BattleRoundEndDto>(OnBattleRoundEnd));
        }

        public void OnBattleRoundEnd(BattleRoundEndDto roundEndDto)
        {
            Debug.Log($"Skill001 Trigger Battle Round End RoundId:{roundEndDto.Round}");
        }
    }
    public class BattleRoundEndDto : MessageModel
    {
        public int Round { get; set; }
    }
}