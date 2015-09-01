using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class PieModel
    {
        public PieModel()
        {
            Pie1 = new Pie1Model();
            Pie2 = new Pie2Model();
        }
        public Pie1Model Pie1 { get; set; }

        public Pie2Model Pie2 { get; set; }
    }

    public class Pie1Model
    {
        public int 总报警次数 { get; set; }
        public int 高I限报警次数 { get; set; }
        public int 高II限报警次数 { get; set; }
        public int 高III限报警次数 { get; set; }
        public int 低I限报警次数 { get; set; }
        public int 低II限报警次数 { get; set; }
        public int 低III限报警次数 { get; set; }
    }

    public class Pie2Model
    {
        public int 专业报警次数 { get; set; }

        public int 已处理 { get; set; }

        public int 未处理 { get; set; }
    }
}