using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using VL.Common.ORM.Objects;
using Dacai.MagicSquareAlgorithm.Objects.Enums;

namespace Dacai.MagicSquareAlgorithm.Objects.Entities
{
    [DataContract]
    public partial class TMSAlgorithmSettings : IPDMTBase
    {
        #region Properties
        [DataMember]
        public Guid AlgorithmId { get; set; }
        [DataMember]
        public ETopWeightType TopWeightType { get; set; }
        [DataMember]
        public ESubWeightType SubWeightType { get; set; }
        [DataMember]
        public EResultType ResultType { get; set; }
        [DataMember]
        public Int16 WeightValue { get; set; }
        #endregion

        #region Constructors
        public TMSAlgorithmSettings()
        {
        }
        public TMSAlgorithmSettings(IDataReader reader) : base(reader)
        {
        }
        #endregion

        #region Methods
        public override void Init(IDataReader reader)
        {
            this.AlgorithmId = new Guid(reader[nameof(this.AlgorithmId)].ToString());
            this.TopWeightType = (ETopWeightType)Enum.Parse(typeof(ETopWeightType), reader[nameof(this.TopWeightType)].ToString());
            this.SubWeightType = (ESubWeightType)Enum.Parse(typeof(ESubWeightType), reader[nameof(this.SubWeightType)].ToString());
            this.ResultType = (EResultType)Enum.Parse(typeof(EResultType), reader[nameof(this.ResultType)].ToString());
            this.WeightValue = Convert.ToInt16(reader[nameof(this.WeightValue)]);
        }
        public override void Init(IDataReader reader, List<string> fields)
        {
            if (fields.Contains(nameof(AlgorithmId)))
            {
                this.AlgorithmId = new Guid(reader[nameof(this.AlgorithmId)].ToString());
            }
            if (fields.Contains(nameof(TopWeightType)))
            {
                this.TopWeightType = (ETopWeightType)Enum.Parse(typeof(ETopWeightType), reader[nameof(this.TopWeightType)].ToString());
            }
            if (fields.Contains(nameof(SubWeightType)))
            {
                this.SubWeightType = (ESubWeightType)Enum.Parse(typeof(ESubWeightType), reader[nameof(this.SubWeightType)].ToString());
            }
            if (fields.Contains(nameof(ResultType)))
            {
                this.ResultType = (EResultType)Enum.Parse(typeof(EResultType), reader[nameof(this.ResultType)].ToString());
            }
            if (fields.Contains(nameof(WeightValue)))
            {
                this.WeightValue = Convert.ToInt16(reader[nameof(this.WeightValue)]);
            }
        }
        [DataMember]
        public override string TableName
        {
            get
            {
                return nameof(TMSAlgorithmSettings);
            }
        }
        #endregion
    }
}
