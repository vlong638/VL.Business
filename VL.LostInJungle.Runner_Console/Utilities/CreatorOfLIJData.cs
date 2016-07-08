using System;
using System.Collections.Generic;
using VL.Common.DAS.Objects;
using VL.LostInJungle.Objects.Entities;
using VL.LostInJungle.Objects.Enums;
using VL.LostInJungle.Runner_Console.UserServiceReference;

namespace VL.LostInJungle.Runner_Console.Utilities
{
    /// <summary>
    /// 生成器:创建用工具
    /// </summary>
    public class CreatorOfLIJData
    {
        #region Area
        List<TArea> Areas = new List<TArea>()
        {
            //(\w+)\s+(\w+)\s+([\w,\.]+)
            //new TArea() { AreaId = Guid.NewGuid(), AreaName = "$1", AreaType = EAreaType.$2, AreaLevel = 1, Description = "$3", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "无主林地", AreaType = EAreaType.ForestLand, AreaLevel = 1, Description = "这是一片荒芜的地区,几乎没有生物出没的踪迹.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "无主草地", AreaType = EAreaType.GrassLand, AreaLevel = 1, Description = "这是一片荒芜的地区,几乎没有生物出没的踪迹.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "无主水域", AreaType = EAreaType.WaterArea, AreaLevel = 1, Description = "这是一片荒芜的地区,几乎没有生物出没的踪迹.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "无主石区", AreaType = EAreaType.MineArea, AreaLevel = 1, Description = "这是一片荒芜的地区,几乎没有生物出没的踪迹.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "无主沼地", AreaType = EAreaType.Swamp, AreaLevel = 1, Description = "这是一片荒芜的地区,几乎没有生物出没的踪迹.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "野性林地", AreaType = EAreaType.ForestLand, AreaLevel = 1, Description = "这片区域遍布着野性的气息,有着不少野兽出没.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "野性草地", AreaType = EAreaType.GrassLand, AreaLevel = 1, Description = "这片区域遍布着野性的气息,有着不少野兽出没.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "野性水域", AreaType = EAreaType.WaterArea, AreaLevel = 1, Description = "这片区域遍布着野性的气息,有着不少野兽出没.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "野性石区", AreaType = EAreaType.MineArea, AreaLevel = 1, Description = "这片区域遍布着野性的气息,有着不少野兽出没.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "野性沼地", AreaType = EAreaType.Swamp, AreaLevel = 1, Description = "这片区域遍布着野性的气息,有着不少野兽出没.", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "飞鸟之森", AreaType = EAreaType.ForestLand, AreaLevel = 1, Description = "这篇区域存在着某种霸主的气息", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "苍狼草原", AreaType = EAreaType.GrassLand, AreaLevel = 1, Description = "这篇区域存在着某种霸主的气息", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "巨蛇之渊", AreaType = EAreaType.WaterArea, AreaLevel = 1, Description = "这篇区域存在着某种霸主的气息", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "顽傀矿脉", AreaType = EAreaType.MineArea, AreaLevel = 1, Description = "这篇区域存在着某种霸主的气息", DescriptionEx = "" },
           new TArea() { AreaId = Guid.NewGuid(), AreaName = "黑鳄之沼", AreaType = EAreaType.Swamp, AreaLevel = 1, Description = "这篇区域存在着某种霸主的气息", DescriptionEx = "" },
        };
        #endregion

        #region Creature
        List<TPrototypeCreature> PrototypeCreatures = new List<TPrototypeCreature>()
        {
            //(\w+)\s+(\w+)\s+([\d,]+)
            //=>
            //new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.$2,Level=$6,Name="$1",CreatureUseType=ECreatureUseType.$3,Profession=EProfession.$4,Properties="$5",Qualities="",Skills=""},

            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.NightElf,Level=1,Name="暗夜精灵",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="16,14,24,24,22",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Human,Level=1,Name="人类",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="20,20,20,20,20",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Orc,Level=1,Name="兽人",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="24,24,18,16,18",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Minotaur,Level=1,Name="牛头人",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="26,26,14,18,16",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Dwarf,Level=1,Name="矮人",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="26,26,16,18,14",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Undead,Level=1,Name="亡灵",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="16,16,16,26,26",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Trolls,Level=1,Name="巨魔",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="22,26,24,14,14",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Dwarfism,Level=1,Name="侏儒",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="14,14,24,26,26",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.BloodElf,Level=1,Name="血精灵",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="16,14,22,22,26",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Delaney,Level=1,Name="德鲁伊",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="18,18,16,24,24",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Werewolf,Level=1,Name="狼人",CreatureUseType=ECreatureUseType.Player,Profession=EProfession.None,Properties="24,22,24,14,16",Qualities="",Skills=""},

            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Mouse,Level=1,Name="老鼠",CreatureUseType=ECreatureUseType.Monster,Profession=EProfession.None,Properties="2,2,6,2,2",Qualities="",Skills="1601"},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Pheasant,Level=2,Name="野鸡",CreatureUseType=ECreatureUseType.Monster,Profession=EProfession.None,Properties="6,6,6,2,2",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.WildBoar,Level=3,Name="野猪",CreatureUseType=ECreatureUseType.Monster,Profession=EProfession.None,Properties="10,15,5,2,2",Qualities="",Skills=""},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Snake,Level=4,Name="毒蛇",CreatureUseType=ECreatureUseType.Monster,Profession=EProfession.None,Properties="8,4,18,2,2",Qualities="",Skills="2601"},
            new TPrototypeCreature() { CreatureId=Guid.NewGuid(),CreatureType=ECreatureType.Bear,Level=5,Name="黑熊",CreatureUseType=ECreatureUseType.Monster,Profession=EProfession.None,Properties="16,12,8,2,2",Qualities="",Skills=""},
        };
        #endregion

        public void InitData(DbSession session, ContextOfLIJData dataContext, List<TUser> users)
        {
            session.Open();
            //创建Area
            if (dataContext.Areas.Count == 0)
            {
                foreach (var area in Areas)
                {
                    area.DbInsert(session);
                }
            }
            //创建PrototypeCreature
            if (dataContext.PrototypeCreatures.Count == 0)
            {
                foreach (var prototypeCreature in PrototypeCreatures)
                {
                    prototypeCreature.DbInsert(session);
                }
            }
            session.Close();
        }
    }
}
