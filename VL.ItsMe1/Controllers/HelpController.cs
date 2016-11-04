using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VL.ItsMe.Controllers
{
    public class HelpController : Controller
    {
        public class HelpInfo
        {
            public string Brief { get; internal set; }
            public string Detail { get; internal set; }
            public string Code { get; internal set; }
        }

        static List<HelpInfo> helps = new List<HelpInfo>()
        {
            new HelpInfo { Code="Who",Brief="我是谁?",Detail=
@"我是一名IT程序员,毕业于2012/
主要从事C#编程,擅长服务后台的业务逻辑处理
对编程及对象化设计有着深刻的领悟,
对各类新技术有着强大的学习能力,
定位是技术专家"},
            new HelpInfo { Code="What",Brief="我在做什么?",Detail="这是我的一个介绍用WebAPI,用于提供一种形式的信息输出,广而告之"},
            new HelpInfo { Code="Where",Brief="我在哪里?",Detail="居住地址:杭州市,西湖区,文二西路与古翠路交叉口"},
            new HelpInfo { Code="When",Brief="时间点?",Detail="毕业于2012,从事.NET编程至今"},
            new HelpInfo { Code="Why",Brief="为什么?",Detail="如果有项目需求或者招聘需求可以联系我"},
            new HelpInfo { Code="How",Brief="怎么做?",Detail="联系方式如下,手机:15158131226,邮箱:vlong638@163.com"},
        };
        static HelpInfo NotFound = new HelpInfo { Code = "", Brief = "对应的帮助项未能找到", Detail = "" };


        public IEnumerable<HelpInfo> Get()
        {
            return helps;
        }

        public HelpInfo Get(string code)
        {
            var product = helps.FirstOrDefault((p) => p.Code == code);
            if (product == null)
            {
                return NotFound;
            }
            return product;
        }
    }
}